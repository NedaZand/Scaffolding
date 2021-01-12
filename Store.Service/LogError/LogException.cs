using System;
using System.IO;
using context = System.Web.HttpContext;

namespace Store.Service
{

    public static class LogException
    {

        private static String ErrorlineNo, Errormsg, extype, exurl, hostIp, ErrorLocation, HostAdd;

        public static void Write(Exception ex, string method = "")
        {
            var line = Environment.NewLine;

            ErrorlineNo = ex.StackTrace.Substring(ex.StackTrace.Length - 7, 7);
            Errormsg = ex.GetType().Name.ToString();
            extype = ex.GetType().ToString();
            exurl = context.Current.Request.Url.ToString();
            ErrorLocation = ex.Message.ToString();
          

            try
            {
                if (ex.InnerException != null)
                {
                    if(ex.InnerException.InnerException!=null)

                        ErrorLocation = ex.InnerException.InnerException.Message;
                }
                    string filepath = context.Current.Server.MapPath("~/ExceptionLogFile/");  //Text File Path

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);

                }
                filepath = filepath + DateTime.Today.ToString("dd-MM-yy  hh-mm-ss") + ".txt";   //Text File Name
                if (!File.Exists(filepath))
                {
                    File.Create(filepath).Dispose();
                }
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    string error = "Log Written Date:" + " " + DateTime.Now.ToString() + line +
                        "Error Line No :" + " " + ErrorlineNo + line +
                        "Error Method Name :" + " " + method + line +
                        "Error Message:" + " " + Errormsg + line +
                        "Exception Type:" + " " + extype + line +
                        "Error Location :" + " " + ErrorLocation + line +
                        "Error Page Url:" + " " + exurl + line +
                        "User Host IP:" + " " + hostIp + line;
                    sw.WriteLine("----------- Exception Details on " + " " + DateTime.Now.ToString() + " -----------------");
                    sw.WriteLine(line);
                    sw.WriteLine(error);
                    sw.WriteLine("-----------------------------------------*End*------------------------------------------");
                    sw.WriteLine(line);
                    sw.Flush();
                    sw.Close();

                }

            }
            catch (Exception e)
            {
                e.ToString();

            }
        }

    }
}
