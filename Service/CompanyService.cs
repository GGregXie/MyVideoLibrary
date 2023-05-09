using com.gestapoghost.entertainment.Dao.MySQL;
using com.gestapoghost.entertainment.entity;
using System;

namespace com.gestapoghost.entertainment.service
{
    public class CompanyService
    {
        private static CompanyService companyService = null;

        public static CompanyService GetCompanyService()
        {
            if (companyService == null)
            {
                companyService = new CompanyService();
            }
            return companyService;
        }

        public void DeleteCompanyById(int companyId)
        {
            CompanyDao.GetCompanyDao().DeleteCompany(companyId);
        }

        public bool SaveOrUpdateCompany(Company _Company)
        {
            if (_Company.Id == 0)
            {
                try
                {
                    CompanyDao.GetCompanyDao().CreateCompany(_Company.Name, _Company.Pic, _Company.Type);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            else
            {
                try
                {
                    CompanyDao.GetCompanyDao().UpdateCompany(_Company.Id, _Company.Name, _Company.Pic, _Company.Type);
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }
    }
}
