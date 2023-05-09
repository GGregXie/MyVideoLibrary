using System;
using System.Globalization;

namespace com.gestapoghost.entertainment.entity
{
    public class Clip : BaseEntity
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Scene { get; set; }
        public String Title { get; set; }
        public DateTime Date { get; set; }
        public String Description { get; set; }
        private String _Pic;
        public String Pic 
        { 
            get 
            {
                return this._Pic; 
            } 
            set 
            { 
                this._Pic = value; OnPropertyChanged("Pic"); 
            } 
        }
        private String _FilePath;
        public String FilePath
        {
            get { return this._FilePath; }
            set
            {
                this._FilePath = value;
                OnPropertyChanged("FilePath");
            }
        }
        public int Start { get; set; }
        public int Code { get; set; }
        private int _Size { get; set; }
        public int Size 
        { 
            get 
            { 
                return _Size; 
            } 
            set 
            { 
                this._Size = value;
                OnPropertyChanged("Pic_Size");
            } 
        }
        private int _Finish;
        public int Finish
        {
            get
            {
                return this._Finish;
            }
            set
            {
                this._Finish = value;
                OnPropertyChanged("Pic_Finish");
            }
        }
        public String ClipUrl { get; set; }
        public String Pic_Finish
        {
            get
            {
                if (this._Finish == 1)
                    return "FINISH";
                else if (this._Finish == 2)
                    return "NSP";
                else if (this._Finish == 3)
                    return "XCI";
                else if (this._Finish == 4)
                    return "CIA";
                else if (this._Finish == 5)
                    return "NSZ";
                else
                    return "";
            }
        }
        public String Pic_Size
        {
            get
            {
                if (this.Size == 480)
                    return "480";
                else if (this.Size == 720)
                    return "720";
                else if (this.Size == 1080)
                    return "1080";
                else
                    return "";
            }
        }
        public String NumberTitle
        {
            get
            {
                return "" + this.Number + ". " + this.Title;
            }
        }
        public String SceneTitle
        {
            get
            {
                return "" + this.Scene + ". " + this.Title;
            }
        }

        public String NumberDateTitle
        {
            get
            {
                return "[" + this.Number + "][" + this.Date.ToString("yyyyMMdd", DateTimeFormatInfo.InvariantInfo) + "]. " + this.Title;
            }
        }

        public Clip()
        { }

        public Clip(Clip _Clip)
        {
            this.Id = _Clip.Id;
            this.Number = _Clip.Number;
            this.Scene = _Clip.Scene;
            this.Title = _Clip.Title;
            this.Date = _Clip.Date;
            this.Description = _Clip.Description;
            this._Pic = _Clip.Pic;
            this._FilePath = _Clip.FilePath;
            this.Start = _Clip.Start;
            this.Code = _Clip.Code;
            this._Size = _Clip.Size;
            this._Finish = _Clip.Finish;
            this.ClipUrl = _Clip.ClipUrl;
        }
    }
}
