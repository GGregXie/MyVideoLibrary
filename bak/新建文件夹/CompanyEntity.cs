using System;
using System.Windows.Media.Imaging;

namespace com.gestapoghost.movie.Entity
{
    public class CompanyEntity
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public BitmapImage Pic { get; set; }
        public int Type { get; set; }

    }
}
