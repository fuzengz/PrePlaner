﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using System.IO;
namespace FusionPrePlaner
{
    class RestAPIAccess
    {

       

        public static string ExecuteRestAPI_CURL(string username, string password,string restApi_Url, string opType, string cmd)
        {
            Process p = new Process();
            string url = Config.Instance.RestApi_Path;
            

            p.StartInfo = new ProcessStartInfo();
            p.StartInfo.FileName = System.Environment.CurrentDirectory + "\\curl\\curl.exe";         
            p.StartInfo.Arguments = string.Format("curl -u {0}:{1} -X {2} -H \"Content-Type: application/json\" \"{3}{4}\"",username,password, opType, restApi_Url, cmd);
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;

            try
            {
                p.Start();
            }
            catch (System.Exception exp)
            {
                return p.StandardError.ReadToEnd();
            }
            string resaultValue = p.StandardOutput.ReadToEnd();
            
            p.WaitForExit();
            p.Close();
            return resaultValue;

        }


        public static string ExecuteRestAPI_CURL_POST(string username, string password, string restApi_Url, string cmd, string jsonstring)
        {
            Process p = new Process();
            string url = Config.Instance.RestApi_Path;


            p.StartInfo = new ProcessStartInfo();
            p.StartInfo.FileName = System.Environment.CurrentDirectory + "\\curl\\curl.exe";
        //    p.StartInfo.Arguments = string.Format("curl  -D- -u {0}:{1} -X POST -H 'Content-Type: application/json'  --data {2} --url '{3}{4}'", username, password, jsonstring, restApi_Url,cmd);
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;


            try
            {
                p.Start();
            }
            catch (System.Exception exp)
            {
                return p.StandardError.ReadToEnd();
            }
            string resaultValue = p.StandardOutput.ReadToEnd();

            p.WaitForExit();
            p.Close();
            return resaultValue;

        }
        /*
        public static string ExecuteRestAPI(string opType, string cmd)
        {
           // var req = HttpWebRequest.Create(@"https://jiradc.int.net.nokia.com/rest/api/latest/search?jql=cf[29790]=1312");
            var req = HttpWebRequest.Create(@"https://jiradc.int.net.nokia.com/rest/api/latest/issue/FCA_FZAP-2645");
            req.ContentType = "application/json";

            req.Method = "GET";
          
          
            req.Credentials = new NetworkCredential("fuzengz", "Password9$");
 

          //  req.Headers.Add("Authorization", "Basic reallylongstring");
            string retval = null ;
            using (WebResponse wr = req.GetResponse())
            {
                StreamReader reader = new StreamReader(wr.GetResponseStream());
                retval = reader.ReadToEnd();
                // Console application output  
                Console.WriteLine(reader.ReadToEnd());
            }
            return retval;
        }
        */
    }
}
