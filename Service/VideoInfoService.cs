using com.gestapoghost.entertainment.AllFile;
using com.gestapoghost.entertainment.entity;
using MediaInfoLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace com.gestapoghost.entertainment.service
{
    public class VideoInfoService
    {
        private static VideoInfoService _VideoInfoService = null;

        public static VideoInfoService GetVideoInfoService()
        {
            if (_VideoInfoService == null)
            {
                _VideoInfoService = new VideoInfoService();
            }
            return _VideoInfoService;
        }

        public void UpdateAllClipVideoInfo()
        {
            MediaInfo mediaInfo = new MediaInfo();
            ObservableCollection<Clip> clips = null;
            clips = ClipService.GetClipService().GetAllHasVideoClips();
            for (int i = 0; i < clips.Count; i++)
            {
                Clip clip = clips[i];

                if (File.Exists("Y:/Roms/Games/NSP/" + VideoFile.intToMd5(clip.Id) + ".nsp"))
                {
                    mediaInfo.Open("Y:/Roms/Games/NSP/" + VideoFile.intToMd5(clip.Id) + ".nsp");
                    ClipService.GetClipService().SetClipSizeById(clip.Id, int.Parse(mediaInfo.Get(StreamKind.Video, 0, "Height")));
                    Console.WriteLine("当前：" + (i + 1).ToString() + "/" + clips.Count.ToString());
                }
                else if (File.Exists("Y:/Roms/Games/XCI/" + VideoFile.intToMd5(clip.Id) + ".xci"))
                {
                    mediaInfo.Open("Y:/Roms/Games/XCI/" + VideoFile.intToMd5(clip.Id) + ".xci");
                    ClipService.GetClipService().SetClipSizeById(clip.Id, int.Parse(mediaInfo.Get(StreamKind.Video, 0, "Height")));
                    Console.WriteLine("当前：" + (i + 1).ToString() + "/" + clips.Count.ToString());
                }
                else 
                {

                }
            }

        }


    }
}
