using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
namespace BusinessLayer.Abstrack
{
    public interface ILicenseServices
    {

        List<license> GetAllLicenses();
        license AddLicense(license license);
        license GetLicenseByKey(string licenseKey);
        license UpdateLicense(license license);
        license getLicenseByID(int ID);
        void DeleteLicense(string licenseKey);
    }
}
