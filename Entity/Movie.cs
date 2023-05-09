using System;

namespace com.gestapoghost.entertainment.entity
{
    public class Movie
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public DateTime Date { get; set; }
        public String Description { get; set; }
        public String Pic_Front { get; set; }
        public String Pic_Back { get; set; }
        public int Source { get; set; }
        public int Code { get; set; }

        public String Pic_Code 
        {
            get 
            {
                if (this.Code == 1)
                    return "NVENC";
                else if (this.Code == 2)
                    return "HEVC";
                else
                    return "";
            }
        }
        public String Pic_Source 
        {
            get
            {
                if (this.Source == 1)
                    return "DVD";
                else if (this.Source == 2)
                    return "BluRay";
                else if (this.Source == 3)
                    return "WEB";
                else if (this.Source == 4)
                    return "DVDRemux";
                else if (this.Source == 5)
                    return "BDRemux";
                else
                    return "";
            }
        }
    }
}
