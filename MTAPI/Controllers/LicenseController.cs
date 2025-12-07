using BusinessLayer.Abstrack;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTAPI.Extansions;
using MTAPI.Models;

namespace MTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        private readonly ILicenseServices licenseServices;
        public LicenseController(ILicenseServices licenseServices)
        {
            this.licenseServices = licenseServices;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = licenseServices.GetAllLicenses();
            return Ok(result);
                  
        }

        [HttpGet("getById/{key}")]
        public IActionResult Get(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return BadRequest();
            }

            var result = licenseServices.GetLicenseByKey(key);
            if (result == null)
              throw new GlobalNotFoundException(key);

            return Ok();      
        }

        [HttpPost("create")]
        public IActionResult createLisans([FromBody] license newLicense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

       
            var lisans = licenseServices.AddLicense(newLicense);
            return Ok(lisans);
           
        }

        [HttpPut("update/{id}")]
        public IActionResult updateLisans(int id, [FromBody] license updateLisans)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var lisansByKey = licenseServices.getLicenseByID(id);
            if (lisansByKey == null)
                 throw new GlobalNotFoundException(id);

            


            lisansByKey.LicenseKey = updateLisans.LicenseKey;
            lisansByKey.AllowedIp = updateLisans.AllowedIp;
            lisansByKey.ServerName = updateLisans.ServerName;
            lisansByKey.Status = updateLisans.Status;
            lisansByKey.ExpireDate = updateLisans.ExpireDate;

            var lisansUpdate = licenseServices.UpdateLicense(lisansByKey);

            return Ok(lisansByKey);          
        }

        [HttpDelete("delete/{key}")]
        public IActionResult deleteLisans(string key)
        {
            if (string.IsNullOrEmpty(key))
                return BadRequest(ModelState);



            licenseServices.DeleteLicense(key);
            return NoContent();
         }
    }
}
