using System;
using System.IO;
using Infrastructure.Extensions;
using Infrastructure.Extensions.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;

namespace RegistrationPlates.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PictureRecognitionController : Controller
    {
        private readonly ILicensePlateReader _licensePlateReader;
        private readonly IHostingEnvironment _environment;

        public PictureRecognitionController(ILicensePlateReader licensePlateReader, IHostingEnvironment environment)
        {
            _licensePlateReader = licensePlateReader;
            _environment = environment;
        }

        [HttpGet]
        public ActionResult GetCode([FromForm] IFormFile picture)
        {
            return Ok(_licensePlateReader.Read(picture.OpenReadStream(),_environment.WebRootPath));
            try
            {
                
               
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost]
        public ActionResult<string> AddCode([FromForm] IFormFile picture)
        {
            try
            {
                return Ok(picture.Name);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}