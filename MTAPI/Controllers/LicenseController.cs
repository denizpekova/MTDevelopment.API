using BusinessLayer.Abstrack;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = licenseServices.GetAllLicenses();
            return Ok(result);

        }
        [HttpGet]
        [HttpGet("getById/{key}")]
        public IActionResult Get(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return BadRequest(new { success = false, message = "Lisans anahtarı boş olamaz." });
            }

            try
            {
                var result = licenseServices.GetLicenseByKey(key);
                if (result == null)
                {
                    return NotFound(new { success = false, message = "Lisans bulunamadı." });
                }
                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Lisans aranırken hata: {ex.Message}" });
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult createLisans([FromBody] license newLicense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var lisans = licenseServices.AddLicense(newLicense);
                return Ok(new { success = true, data = lisans, message = "Lisans başarıyla oluşturuldu." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Lisans oluşturulurken hata: {ex.Message}" });
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult updateLisans([FromBody] license updateLisans)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var lisansUpdate = licenseServices.UpdateLicense(updateLisans);
                if (lisansUpdate == null)
                {
                    return NotFound(new { success = false, message = "Güncellenecek lisans bulunamadı." });
                }
                return Ok(new { success = true, data = lisansUpdate, message = "Lisans başarıyla güncellendi." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Lisans güncellenirken hata: {ex.Message}" });
            }
        }

        [HttpDelete]
        [Route("delete/{key}")]
        public IActionResult deleteLisans(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return BadRequest(new { success = false, message = "Lisans anahtarı boş olamaz." });
            }
            try
            {
                licenseServices.DeleteLicense(key);
                return Ok(new { success = true, message = "Lisans başarıyla silindi." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Lisans silinirken hata: {ex.Message}" });
            }
        }

    }
}
