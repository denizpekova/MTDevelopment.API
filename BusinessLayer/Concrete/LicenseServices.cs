using BusinessLayer.Abstrack;
using DataAcessLayerss;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class LicenseServices : ILicenseServices
    {
        private readonly ILicenseRepository licenseRepository;

        public LicenseServices(ILicenseRepository licenseRepository)
        {
            this.licenseRepository = licenseRepository;
        }

        public license AddLicense(license license)
        {
            return licenseRepository.AddLicense(license);
        }

        public void DeleteLicense(string licenseKey)
        {
            licenseRepository.DeleteLicense(licenseKey);
        }

        public List<license> GetAllLicenses()
        {
            return licenseRepository.GetAllLicenses();
        }

        public license getLicenseByID(int ID)
        {
            return licenseRepository.getLicenseByID(ID);
        }

        public license GetLicenseByKey(string licenseKey)
        {
            return licenseRepository.GetLicenseByKey(licenseKey);
        }


        public license UpdateLicense(license license)
        {
            return licenseRepository.UpdateLicense(license);
        }
    }
}
