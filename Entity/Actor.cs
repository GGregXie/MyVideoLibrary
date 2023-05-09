using System;

namespace com.gestapoghost.entertainment.entity
{
    public class Actor : BaseEntity
    {
        public int Id { get; set; }
        private String _Name;
        public String Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
                OnPropertyChanged("Name");
            }
        }
        private String _Pic;
        public String Pic
        {
            get
            {
                return this._Pic;
            }
            set
            {
                this._Pic = value;
                OnPropertyChanged("Pic");
            }
        }

        private int _Count;
        public int Count
        {
            get
            {
                return this._Count;
            }
            set
            {
                this._Count = value;
                OnPropertyChanged("Count");
            }
        }

        public String CountName
        {
            get
            {
                return "[" + this._Count + "]. " + this._Name;
            }
        }
    }
}
