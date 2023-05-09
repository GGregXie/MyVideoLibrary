using com.gestapoghost.entertainment.entity;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;

namespace com.gestapoghost.entertainment.AllFile
{
    public class VideoFile
    {
        private string PlayerPath;
        private string PlayerName;
        private string Argument;
        private string playerPathName;


        public VideoFile()
        {
            this.playerPathName = System.AppDomain.CurrentDomain.BaseDirectory + "Resources/Tools/PotPlayer64/PotPlayerMini64.exe";
            this.Argument = Argument;
            FileInfo fi = new FileInfo(playerPathName);
            this.PlayerPath = fi.DirectoryName;
        }
        public void play()
        {
            Process currentProcess = Process.GetCurrentProcess();
            foreach (Process process2 in Process.GetProcessesByName("PotPlayerMini"))
            {
                if (process2.Id != currentProcess.Id)
                {
                    process2.Kill();
                    Thread.Sleep(100);
                }
            }
            Write();
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = this.playerPathName; //"PotPlayerMini.exe";
            process.StartInfo.WorkingDirectory = this.playerPathName;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Arguments = this.Argument;
            process.Start();
        }
        public void play(string Argument)
        {
            this.Argument = Argument;
            Process currentProcess = Process.GetCurrentProcess();
            foreach (Process process2 in Process.GetProcessesByName("PotPlayerMini"))
            {
                if (process2.Id != currentProcess.Id)
                {
                    process2.Kill();
                    Thread.Sleep(100);
                }
            }
            Write();
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = this.playerPathName; //"PotPlayerMini.exe";
            process.StartInfo.WorkingDirectory = this.playerPathName;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.Arguments = this.Argument;
            process.Start();
        }
        public void Write()
        {
            string pList = Path.Combine(this.PlayerPath, "Playlist");
            //pList = pList + "\\PotPlayerMini.dpl";
            pList = "E:/Game/Logs/PotPlayerMini.dpl";
            FileStream fs = new FileStream(pList, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            sw.WriteLine("DAUMPLAYLIST");
            sw.WriteLine("topindex=0");
            sw.WriteLine(string.Format("1*file*{0}", this.Argument));
            sw.WriteLine("1*played*0");
            sw.Close();
            fs.Close();
        }

        public static string intToMd5(int clip_id)
        {
            byte[] pasArray = System.Text.Encoding.Default.GetBytes(clip_id.ToString());
            pasArray = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(pasArray);
            string rMd5Str = "";
            foreach (byte ibyte in pasArray)
                rMd5Str += ibyte.ToString("x").PadLeft(2, '0');
            return rMd5Str;
        }

    }
}
