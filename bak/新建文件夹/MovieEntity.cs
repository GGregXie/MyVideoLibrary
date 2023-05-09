using System;
using System.Windows.Media.Imaging;

namespace com.gestapoghost.movie.Entity
{
    public class MovieEntity
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public BitmapImage Pic_front { get; set; }
        public BitmapImage Pic_back { get; set; }
        public int Source { get; set;  }
        public int Code { get; set; }
    }
}
