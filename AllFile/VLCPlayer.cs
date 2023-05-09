using System;
using System.Diagnostics;
using System.IO;

namespace com.gestapoghost.entertainment.AllFile
{
    class VLCPlayer
    {

        public static void play(string videourl, int start)
        {

            string sIDMPath = @"C:\Program Files\VideoLAN\VLC\vlc.exe";
            string sCmd = string.Format(@"""{0}"" ""{1}""", sIDMPath, videourl);
            RunCmd(sCmd);
        }

        public static void RunCmd(string cmd)
        {
            string CmdPath = @"C:\Windows\System32\cmd.exe";
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
