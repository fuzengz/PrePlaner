using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Collections;
using System.Windows.Forms;

namespace FusionPrePlaner
{
    class FeatureBuild
    {
        /*start to add for show FB data*/
        public static string getExcelOleDBConnectStr(string filePath)
        {
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;"
               + "Data Source=" + @filePath + ";" + "Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'";

            return strConn;
        }

        public static ArrayList getExcelSheetNames(string filePath)
        {
            ArrayList arrayNames = new ArrayList();
            string strConn = getExcelOleDBConnectStr(filePath);
            DataTable tb = null;

            try
            {
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                tb = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                foreach (System.Data.DataRow drow in tb.Rows)
                {
                    string sheetName = drow["TABLE_NAME"].ToString().Trim();
                    int pos = sheetName.LastIndexOf('$');
                    if (pos != -1 && (sheetName == "cap" || sheetName == "Dates"))
                    {
                        arrayNames.Add(sheetName.Substring(0, pos));
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return arrayNames;

        }

        public static DataTable excelToDataSet(string filePath, string filterdata, string tobeOpenSheet)
        {
            string strConn = getExcelOleDBConnectStr(filePath);
            DataTable ds = null;
            OleDbConnection conn = new OleDbConnection(strConn);

            try
            {
                conn.Open();
                string strExcel = "";
                OleDbDataAdapter myCommand = null;
                strExcel = "select * from [" + tobeOpenSheet + "$]";
                myCommand = new OleDbDataAdapter(strExcel, strConn);
                ds = new DataTable();

                myCommand.Fill(ds);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ds;
        }



        public static DataTable FormatDataTableDates(DataTable dtDates)
        {
            DataView dv = dtDates.DefaultView;
            var PrimaryKeyColumns = new string[] { "Feature Build", "Start Date", "End Date" };
            DataTable dtDistinct = dv.ToTable(true, PrimaryKeyColumns);
            dtDistinct.Columns[0].ColumnName = "FB";
            return dtDistinct;
        }



        public static DataTable FormatDataTableCap(DataTable dtCap)
        {

            for (int j = dtCap.Columns.Count - 1; j >= 0; j--)
            {
                string colName = dtCap.Rows[0][j].ToString().Trim();

                if (colName == "Capacities")
                {
                    dtCap.Columns[j].ColumnName = "FB";
                }
                else if (colName.StartsWith("FT_") && colName.EndsWith("_Dev"))
                {
                    dtCap.Columns[j].ColumnName = colName.Replace("FT_",string.Empty).Replace("_Dev",string.Empty);
                }
                else
                {
                    dtCap.Columns.RemoveAt(j);
                }

            }
            for (int i = dtCap.Rows.Count - 1; i >= 0; i--)
            {
                if (!dtCap.Rows[i]["FB"].ToString().Trim().StartsWith("fb"))
                {
                    dtCap.Rows.RemoveAt(i);
                }
            }
            return dtCap;
        }

        public static DataTable MergeDataTable(DataTable dtDates, DataTable dtCap)
        {
            for (int j = 1; j < dtDates.Columns.Count; j++)
            {
                dtCap.Columns.Add(dtDates.Columns[j].ColumnName, dtDates.Columns[j].DataType);
            }
            for (int i = 0; i < dtCap.Rows.Count; i++)
            {
                var filter = "FB='" + dtCap.Rows[i]["FB"].ToString() + "'";
                var rows = dtDates.Select(filter);
                if (rows.Length > 0)
                {
                    dtCap.Rows[i]["Start Date"] = rows[0]["Start Date"];
                    dtCap.Rows[i]["End Date"] = rows[0]["End Date"];
                }

            }
            for (int i = dtCap.Rows.Count -1; i >=0; i--)
            {
                DateTime dtStart, dtEnd;
                DateTime dtnow = System.DateTime.Now;
                try
                {
                    dtStart = (DateTime)dtCap.Rows[i]["Start Date"];
                    dtEnd = (DateTime)dtCap.Rows[i]["End Date"];
                    if (dtStart < dtnow && dtEnd <dtnow)
                    {
                        dtCap.Rows.RemoveAt(i);
                    }
                }
                catch
                {
                    dtCap.Rows.RemoveAt(i);
                }
 
            }

            for (int i = dtCap.Rows.Count - 1; i >= 0; i--)
            {

                dtCap.Rows[i]["FB"] = dtCap.Rows[i]["FB"].ToString().Replace("fb", string.Empty).Replace(".", string.Empty);
            }
            return dtCap;

        }
    }
}
