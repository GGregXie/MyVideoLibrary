using com.gestapoghost.entertainment.AllFile;
using com.gestapoghost.entertainment.entity;
using System.IO;
using System.Windows;

namespace com.gestapoghost.entertainment.tools
{
    public class ComicTools
    {
        public static void Playing(Clip _Clip)
        {
            if (_Clip.Finish == 0)
            {
                if (File.Exists(_Clip.FilePath))
                {
                    System.Diagnostics.Process.Start(@"C:\Program Files\CDisplayEx\CDisplayEx.exe", _Clip.FilePath);
                }
                else
                {
                    MessageBox.Show("文件不存在");
                }
            }
            else if (_Clip.Finish == 4)
            {
                if (File.Exists("X:/OtherRoms/" + VideoFile.intToMd5(_Clip.Id) + ".cia"))
                {
                    System.Diagnostics.Process.Start(@"C:\Program Files\CDisplayEx\CDisplayEx.exe", "X:/OtherRoms/" + VideoFile.intToMd5(_Clip.Id) + ".cia");
                }
                else
                {
                    MessageBox.Show("文件不存在");
                }
            }
            else
            {
                MessageBox.Show("Finish异常");
            }
        }
    }
}
