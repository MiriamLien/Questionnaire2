using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace questionnaire.Helpers
{
    public class Logger
    {
        private const string _savePath = "D:\\ccc\\Logs\\log.log";

        /// <summary> 紀錄錯誤 </summary>
        /// <param name="moduleName"></param>
        /// <param name="ex"></param>
        public static void WriteLog(string moduleName, Exception ex)
        {
            // -----
            // yyyy/MM/dd HH:mm:ss
            //   Module Name
            //   Error Content
            // -----

            string content =
$@"-----
{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}
    {moduleName}
    {ex.ToString()}
-----
";
            CreateFile();
            File.AppendAllText(Logger._savePath, content);
        }

        //創建檔案
        static void CreateFile()
        {
            if (!Directory.Exists("D:\\ccc\\Logs"))
            {
                Directory.CreateDirectory("D:\\ccc\\Logs");
            }

            if (!File.Exists("D:\\ccc\\Logs\\log.log"))
            {
                //File.Create會傳回FileStream值,導致檔案運作
                FileStream shutdown = File.Create("D:\\ccc\\Logs\\log.log");
                //將FileStream關閉,才能進行檔案刪除
                shutdown.Close();
            }
        }
    }
}