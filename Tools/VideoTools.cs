
using com.gestapoghost.entertainment.AllFile;
using com.gestapoghost.entertainment.entity;
using com.gestapoghost.entertainment.viewmodel;
using System.IO;
using System.Windows;

namespace com.gestapoghost.entertainment.tools
{
    public class VideoTools
    {
        public static void Playing(Clip _Clip, ClipPageViewModel _ClipPageViewModel)
        {
            if (_Clip.Finish == 0)
            {
                if (File.Exists(_Clip.FilePath))
                {
                    DPLFile.CreatePlayDPL(_Clip.FilePath, _Clip.Start);
                    DPLFile.PlayDPL();
                }
                else
                {
                    MessageBox.Show("文件不存在");
                }
            }
            else if (_Clip.Finish == 2)
            {
                if (_ClipPageViewModel == null)
                {
                    if (File.Exists("Y:/Roms/Games/NSP/" + VideoFile.intToMd5(_Clip.Id) + ".nsp"))
                    {
                        DPLFile.CreatePlayDPL("Y:/Roms/Games/NSP/" + VideoFile.intToMd5(_Clip.Id) + ".nsp", _Clip.Start);
                        DPLFile.PlayDPL();
                    }
                    else
                    {
                        MessageBox.Show("文件不存在");
                    }
                }
                else if (_ClipPageViewModel.Company.Id == 9 || _ClipPageViewModel.Company.Id == 134 || _ClipPageViewModel.Company.Id == 288 || _ClipPageViewModel.Company.Id == 70 || _ClipPageViewModel.Company.Id == 124 || _ClipPageViewModel.Company.Id == 164 || _ClipPageViewModel.Company.Id > 999)
                {
                    string file_path = "";
                    if (_ClipPageViewModel.Series == null) file_path = "U:/" + _ClipPageViewModel.Company.Name + "/";
                    else file_path = "U:/" + _ClipPageViewModel.Company.Name + "/" + _ClipPageViewModel.Series.Name + "/";

                    if (File.Exists(file_path + _Clip.Number + "_" + VideoFile.intToMd5(_Clip.Id) + ".mp4"))
                    {
                        DPLFile.CreatePlayDPL(file_path + _Clip.Number + "_" + VideoFile.intToMd5(_Clip.Id) + ".mp4", _Clip.Start);
                        DPLFile.PlayDPL();
                    }
                    else
                        MessageBox.Show("文件不存在");
                }
                else
                {
                    if (File.Exists("Y:/Roms/Games/NSP/" + VideoFile.intToMd5(_Clip.Id) + ".nsp"))
                    {
                        DPLFile.CreatePlayDPL("Y:/Roms/Games/NSP/" + VideoFile.intToMd5(_Clip.Id) + ".nsp", _Clip.Start);
                        DPLFile.PlayDPL();
                    }
                    else
                    {
                        MessageBox.Show("文件不存在");
                    }
                }
            }
            else if (_Clip.Finish == 3)
            {
                if (_ClipPageViewModel == null)
                {
                    if (File.Exists("Y:/Roms/Games/XCI/" + VideoFile.intToMd5(_Clip.Id) + ".xci"))
                    {
                        DPLFile.CreatePlayDPL("Y:/Roms/Games/XCI/" + VideoFile.intToMd5(_Clip.Id) + ".xci", _Clip.Start);
                        DPLFile.PlayDPL();
                    }
                    else
                    {
                        MessageBox.Show("文件不存在");
                    }
                }
                else if (_ClipPageViewModel.Company.Id == 9 || _ClipPageViewModel.Company.Id == 134 || _ClipPageViewModel.Company.Id == 288 || _ClipPageViewModel.Company.Id == 70 || _ClipPageViewModel.Company.Id == 124 || _ClipPageViewModel.Company.Id == 164 || _ClipPageViewModel.Company.Id > 999)
                {
                    string file_path = "";
                    if (_ClipPageViewModel.Series == null) file_path = "U:/" + _ClipPageViewModel.Company.Name + "/";
                    else file_path = "U:/" + _ClipPageViewModel.Company.Name + "/" + _ClipPageViewModel.Series.Name + "/";

                    if (File.Exists(file_path + _Clip.Number + "_" + VideoFile.intToMd5(_Clip.Id) + ".mkv"))
                    {
                        DPLFile.CreatePlayDPL(file_path + _Clip.Number + "_" + VideoFile.intToMd5(_Clip.Id) + ".mkv", _Clip.Start);
                        DPLFile.PlayDPL();
                    }
                    else
                        MessageBox.Show("文件不存在");
                }
                else
                {
                    if (File.Exists("Y:/Roms/Games/XCI/" + VideoFile.intToMd5(_Clip.Id) + ".xci"))
                    {
                        DPLFile.CreatePlayDPL("Y:/Roms/Games/XCI/" + VideoFile.intToMd5(_Clip.Id) + ".xci", _Clip.Start);
                        DPLFile.PlayDPL();
                    }
                    else
                    {
                        MessageBox.Show("文件不存在");
                    }
                }
            }
            else if (_Clip.Finish == 5)
            {
                if (_ClipPageViewModel == null)
                {
                    if (File.Exists("Y:/Roms/Games/NSZ/" + VideoFile.intToMd5(_Clip.Id) + ".nsz"))
                    {
                        DPLFile.CreatePlayDPL("Y:/Roms/Games/NSZ/" + VideoFile.intToMd5(_Clip.Id) + ".nsz", _Clip.Start);
                        DPLFile.PlayDPL();
                    }
                    else
                    {
                        MessageBox.Show("文件不存在");
                    }
                }
                else if (_ClipPageViewModel.Company.Id == 9 || _ClipPageViewModel.Company.Id == 134 || _ClipPageViewModel.Company.Id == 288 || _ClipPageViewModel.Company.Id == 70 || _ClipPageViewModel.Company.Id == 124 || _ClipPageViewModel.Company.Id == 164 || _ClipPageViewModel.Company.Id > 999)
                {
                    string file_path = "";
                    if (_ClipPageViewModel.Series == null) file_path = "U:/" + _ClipPageViewModel.Company.Name + "/";
                    else file_path = "U:/" + _ClipPageViewModel.Company.Name + "/" + _ClipPageViewModel.Series.Name + "/";

                    if (File.Exists(file_path + _Clip.Number + "_" + VideoFile.intToMd5(_Clip.Id) + ".wmv"))
                    {
                        DPLFile.CreatePlayDPL(file_path + _Clip.Number + "_" + VideoFile.intToMd5(_Clip.Id) + ".wmv", _Clip.Start);
                        DPLFile.PlayDPL();
                    }
                    else
                        MessageBox.Show("文件不存在");
                }
                else
                {
                    if (File.Exists("Y:/Roms/Games/NSZ/" + VideoFile.intToMd5(_Clip.Id) + ".nsz"))
                    {
                        DPLFile.CreatePlayDPL("Y:/Roms/Games/NSZ/" + VideoFile.intToMd5(_Clip.Id) + ".nsz", _Clip.Start);
                        DPLFile.PlayDPL();
                    }
                    else
                    {
                        MessageBox.Show("文件不存在");
                    }
                }
            }
            else
            {
                MessageBox.Show("播放异常");
            }
        }

    }
}
