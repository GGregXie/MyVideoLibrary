using com.gestapoghost.entertainment.entity;
using com.gestapoghost.entertainment.service;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace com.gestapoghost.entertainment.viewmodel
{
    public class CompanyPageViewModel
    {
        private ObservableCollection<Company> _Companies;
        public ObservableCollection<Company> Companies
        {
            get { return _Companies; }
            set { _Companies = value; }
        }

        public CompanyPageViewModel(int _CompanyTypeId)
        {
            this._Companies = WebService.GetWebService().GetAllCompaniesFromWeb(_CompanyTypeId);
        }
    }
}
