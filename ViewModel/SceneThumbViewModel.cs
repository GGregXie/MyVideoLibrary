using com.gestapoghost.entertainment.entity;


namespace com.gestapoghost.entertainment.viewmodel
{
    public class SceneThumbViewModel : BaseViewModel
    {
        public Company Company { get; set; }
        public Series Series { get; set; }
        public Movie Movie { get; set; }
        public Clip Scene { get; set; }

        public SceneThumbViewModel(Company __Company, Series __Series, Movie __Movie, Clip __Clip)
        {
            this.Company = __Company;
            this.Series = __Series;
            this.Movie = __Movie;
            this.Scene = __Clip;

        }

    }
}
