
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace ImageLable
{
    public class LogTraceListener : TraceListener
    {
        static string logfile;
        FixedTimeAction ChangeFile;
        DateTime logTime;
        public LogTraceListener()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\";
            if (!Directory.Exists(basePath))//如果Logs文件夹不存在则创建
            {
                Directory.CreateDirectory(basePath);
            }
            logTime = DateTime.Now;
            logfile = basePath + string.Format("Log-{0}.txt", logTime.ToString("yyyyMMdd"));
            ChangeFile = new FixedTimeAction(new DateTime(1, 1, 1, 0, 0, 0, DateTimeKind.Local), "day");
            ChangeFile.DoEvent += () => { logfile = basePath + string.Format("Log-{0}.txt", logTime.ToString("yyyyMMdd")); };
        }
        public override void Write(string message)
        {
            message = Format(message, "");
            File.AppendAllText(logfile, message);
        }



        public override void Write(object obj)
        {

            string message = Format(obj, "");
            File.AppendAllText(logfile, message);
        }

        public override void Write(object obj, string category)
        {

            string message = Format(obj, category);
            File.AppendAllText(logfile, message);
        }

        public override void WriteLine(string message)
        {
 
            message = Format(message + "\r\n", "");
            File.AppendAllText(logfile, message);
        }

        public override void WriteLine(object obj)
        {

            string message = Format(obj, "");
            File.AppendAllText(logfile, message + "\r\n");
        }

        public override void WriteLine(object obj, string category)
        {

            string message = Format(obj, category);
            File.AppendAllText(logfile, message + "\r\n");
        }

        private string Format(object o, string category)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat(" {0} ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (!string.IsNullOrEmpty(category))//参数 category不为空
            {
                stringBuilder.AppendFormat("[{0}]", category);
            }
            if (o is Exception)//如果传入的o是异常类对象
            {
                var t = o as Exception;
                stringBuilder.Append(t.Message + "\n\r");//追加Message 和 StackTrace，即异常信息和异常位置
                stringBuilder.Append(t.StackTrace + "\r\n");
            }
            else
            {
                stringBuilder.Append(o.ToString());
            }
            return stringBuilder.ToString();
        }

        //private void DateModified()
        //{
        //    if (logTime.Date != DateTime.Now.Date)
        //    {
        //        string basePath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\";
        //        if (!Directory.Exists(basePath))//如果Logs文件夹不存在则创建
        //        {
        //            Directory.CreateDirectory(basePath);
        //        }
        //        logTime = DateTime.Now;
        //        logfile = basePath + string.Format("Log-{0}.txt", logTime.ToString("yyyyMMdd"));
        //    }
        //}
    }

    public class FixedTimeAction
    {
        System.Threading.Timer timer, timer1;
        DateTime ExecTime;
        int hour;
        public event Action DoEvent;


        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="StartExecTime">执行时间 只需传入时分秒</param>
        /// <param name="interval">间隔时间，day,week,month,year</param>
        public FixedTimeAction(DateTime StartExecTime, string interval)
        {
            TimeSpan period;
            ExecTime = StartExecTime;
            hour = ExecTime.Hour == 0 ? 24 : ExecTime.Hour;
            switch (interval)
            {
                case "day":
                    period = TimeSpan.FromDays(1);
                    break;
                case "week":
                    period = TimeSpan.FromDays(7);
                    break;
                case "month":
                    period = TimeSpan.FromDays(30);
                    break;
                case "year":
                    period = TimeSpan.FromDays(365);
                    break;
                default:
                    throw new InvalidOperationException("传入非法的时间间隔参数，请传入day,week,month,year  string类型");                   
            }
            timer = new System.Threading.Timer(Dotime, null, TimeSpan.FromSeconds(10), TimeSpan.FromMinutes(60));
            timer1 = new System.Threading.Timer(Exec, null, System.Threading.Timeout.Infinite, 3000);
        }

        private void Exec(object state)
        {
            if (DateTime.Now.Minute == ExecTime.Minute)
            {
                DoEvent?.Invoke();
            }
        }

        private void Dotime(object state)
        {
            if (DateTime.Now.Hour - hour == -1)
            {
                timer1.Change(1000, 3000);
            }
            else
            {
                timer1.Change(-1, 3000);
            }
        }
    }
}
