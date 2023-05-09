using System;
using System.Windows.Media.Imaging;

namespace com.gestapoghost.movie.Entity
{
    public class ClipEntity
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Scene { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public BitmapImage Pic { get; set; }
        public string FilePath { get; set; }
        public int Start { get; set; }
        public int Code { get; set;  }
        public int Size { get; set;  }

        public int Finish { get; set; }
        public string ClipUrl { get; set; }
    }
}
