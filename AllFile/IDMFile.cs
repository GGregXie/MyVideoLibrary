using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.gestapoghost.entertainment.AllFile
{
    public class IDMFile
    {

        public static void IDMDownloadXhamster(string videourl, string VideoOutPutPath, string VideoFileName)
        {
            string sIDMPath = @"C:\Program Files (x86)\Internet Download Manager\IDMan.exe";
            string sCmd = string.Format(@"""{0}"" /d ""{1}"" /p ""{2}"" /f ""{3}""", sIDMPath, videourl, VideoOutPutPath, VideoFileName);
            RunCmd(sCmd);
        }

        public static void IDMDownloadJFF(string videourl, string VideoOutPutPath)
        {
            string sIDMPath = @"C:\Program Files (x86)\Internet Download Manager\IDMan.exe";
            string sCmd = string.Format(@"""{0}"" /d ""{1}"" /p {2}", sIDMPath, videourl, VideoOutPutPath);
            RunCmd(sCmd);
        }

        public static void RunCmd(string cmd)
        {
            string CmdPath = @"C:\Windows\System32\cmd.exe";
            cmd = cmd.Trim().TrimEnd('&') + "&exit";//要加exit命令，否则后面调用ReadtoEnd()命令会假死
            using (Process p = new Process())
            {
                Console.WriteLine(cmd);
                p.StartInfo.FileName = CmdPath;

                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.Start();

                p.StandardInput.WriteLine(cmd);
                p.StandardInput.AutoFlush = true;

                p.WaitForExit();
                p.Close();
            }
        }
    }

}
