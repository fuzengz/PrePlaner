using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data.OleDb;
using System.Collections;

namespace FusionPrePlaner
{
    class Fb
    {
        public string FB { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string FZ01 { get; set; }
        public string FZ02 { get; set; }
    }

    class FBAccess
    {
        private static string getExcelOleDBConnectStr(string filePath)
        {
            //System.IO.DirectoryInfo topDir = System.IO.Directory.GetParent(System.Environment.CurrentDirectory);
            //string pathto = topDir.Parent.Parent.FullName;
            //filePath = pathto + Path.DirectorySeparatorChar + "'" +filePath + "'";
            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;"
                + "Data Source=\"" + @filePath + "\";" + "Extended Properties='Excel 12.0; HDR=Yes; IMEX=1'";
            
            return strConn;
        }
        /*
        private static ArrayList getExcelSheetNames(string filePath)
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
        }*/

        public static DataTable excelToDataSet(string filePath, string filterdata, string tobeOpenSheet)
        {
            string strConn = getExcelOleDBConnectStr(filePath);
            DataTable ds = null;
            OleDbConnection conn = new OleDbConnection(strConn);

            try
            {
                MessageBox.Show(strConn);
                //some error here
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

        private static void RemoveEmpty(DataTable dt)
        {
            List<DataRow> removelist = new List<DataRow>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool IsNull = true;
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (!string.IsNullOrEmpty(dt.Rows[i][j].ToString().Trim()))
                    {
                        IsNull = false;
                    }
                }
                if (IsNull)
                {
                    removelist.Add(dt.Rows[i]);
                }
            }
            for (int i = 0; i < removelist.Count; i++)
            {
                dt.Rows.Remove(removelist[i]);
            }
        }

        public static DataTable UpdateDatatableOne(DataTable DataTableOne)
        {
            RemoveEmpty(DataTableOne);
            for (int i = DataTableOne.Columns.Count - 1; i > 2; i--)
            {
                //add column structure in DataTableTwo to new DataTable
                DataTableOne.Columns.RemoveAt(i);
            }
            DataTableOne.Rows[0].Delete();
            DataTableOne.AcceptChanges();
            return DataTableOne;
        }

        public static DataTable GetDistinctPrimaryKeyColumnTable(DataTable dt, string[] PrimaryKeyColumns)
        {
            DataView dv = dt.DefaultView;
            DataTable dtDistinct = dv.ToTable(true, PrimaryKeyColumns);
            return dtDistinct;
        }

        public static DataTable updateDatatableTwo(DataTable DataTableTwo)
        {
            RemoveEmpty(DataTableTwo);
            for (int i = 54; i >= 0; i--)
            {
                DataTableTwo.Rows.RemoveAt(i);
            }
            for (int i = DataTableTwo.Columns.Count - 1; i >= 0; i--)
            {
                if (i > 9)
                {
                    DataTableTwo.Columns.RemoveAt(i);
                }
                else if (i > 2 && i < 9)
                {
                    DataTableTwo.Columns.RemoveAt(i);
                }
                else if (i == 1)
                {
                    DataTableTwo.Columns.RemoveAt(i);
                }
            }
            return DataTableTwo;
        }

        public static DataTable MergeDataTable(DataTable DataTableOne, DataTable DataTableTwo)
        {
            DataTable newDataTable = DataTableTwo.Clone();
            for (int i = 1; i < DataTableTwo.Columns.Count; i++)
            {
                //add column structure in DataTableTwo to new DataTable
                newDataTable.Columns.Add(DataTableTwo.Columns[i].ColumnName);
            }
            object[] obj = new object[newDataTable.Columns.Count];
            //add datas in DataTableOne
            for (int i = 0; i < DataTableTwo.Rows.Count; i++)
            {
                DataTableOne.Rows[i].ItemArray.CopyTo(obj, 0);
                newDataTable.Rows.Add(obj);
            }
            if (DataTableOne.Rows.Count >= DataTableTwo.Rows.Count)
            {
                for (int i = 0; i < DataTableTwo.Rows.Count; i++)
                {
                    for (int j = 0; j < DataTableTwo.Columns.Count - 1; j++)
                    {
                        newDataTable.Rows[i][j + DataTableOne.Columns.Count] = DataTableTwo.Rows[i][j + 1].ToString();
                    }
                }
            }
            else
            {
                DataRow dr3;
                //add new rows to new datatable
                for (int i = 0; i < DataTableTwo.Rows.Count - DataTableOne.Rows.Count; i++)
                {
                    dr3 = newDataTable.NewRow();
                    newDataTable.Rows.Add(dr3);
                }
                for (int i = 0; i < DataTableTwo.Rows.Count; i++)
                {
                    for (int j = 0; j < DataTableTwo.Columns.Count; j++)
                    {
                        newDataTable.Rows[i][j + DataTableOne.Columns.Count] = DataTableTwo.Rows[i][j].ToString();
                    }
                }
            }
            return newDataTable;
        }

    }
}
