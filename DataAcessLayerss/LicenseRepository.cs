using DataAcessLayerss.Context;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcessLayerss
{
    public class LicenseRepository : ILicenseRepository
    {
        private readonly AppDbContext dbContexts;

        public LicenseRepository(AppDbContext dbContexts)
        {
            this.dbContexts = dbContexts;
        }

        public license AddLicense(license license)
        {
            dbContexts.Licenses.Add(license);
            dbContexts.SaveChanges();
            return license;
        }

        public void DeleteLicense(string licenseKey)
        {
            var lisans = GetLicenseByKey(licenseKey);
            if (lisans != null)
            {
                dbContexts.Licenses.Remove(lisans);
                dbContexts.SaveChanges();
            }
        }

        public List<license> GetAllLicenses()
        {
            return dbContexts.Licenses.ToList();
        }

        public license getLicenseByID(int ID)
        {
            return dbContexts.Licenses.Find(ID);
        }

        public license GetLicenseByKey(string licenseKey)
        {
            return dbContexts.Licenses.FirstOrDefault(l => l.LicenseKey == licenseKey);
        }



        public license UpdateLicense(license license)
        {
            dbContexts.Licenses.Update(license);
            dbContexts.SaveChanges();
            return license;

        }
    }
}
