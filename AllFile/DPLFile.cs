using System.IO;

namespace com.gestapoghost.entertainment.AllFile
{
    class DPLFile
    {
        public static void CreatePlayDPL(string filepath, int start)
        {

            StreamWriter playDPL = new StreamWriter(System.Environment.CurrentDirectory + "/Logs/play.dpl");
            playDPL.WriteLine("DAUMPLAYLIST");
            playDPL.WriteLine("playname=" + filepath);
            playDPL.WriteLine("playtime=" + (start * 1000).ToString());
            playDPL.WriteLine("topindex=0");
            playDPL.WriteLine("saveplaypos=1");
            playDPL.WriteLine(@"1*file*" + filepath);
            playDPL.WriteLine("1*title*Test1");
            playDPL.WriteLine("1*played*0");
            playDPL.WriteLine("1*duration2*5866433");
            playDPL.WriteLine("1*start*3460215");
            playDPL.Close();

        }

        public static void PlayDPL()
        {
            //MessageBox.Show(System.IO.Directory.GetCurrentDirectory());
            //System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory() + "\\Resources\\play.dpl");
            System.Diagnostics.Process.Start(System.Environment.CurrentDirectory + "/Logs/play.dpl");
        }




    }
}
