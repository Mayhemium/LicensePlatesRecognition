using System;
using System.Collections.Generic;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RegistrationPlates.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegistrationsController : ControllerBase
    {

        private readonly IRegistrationsService _registrationsService;

        public RegistrationsController(IRegistrationsService registrationsService)
        {
            _registrationsService = registrationsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetRegistrations()
        {
            try
            {
                return Ok(_registrationsService.GetRegistrations());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{code}")]
        public ActionResult<bool> CheckDatabase(string code)
        {
            try
            {
                return Ok(_registrationsService.Exists(code));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpPost("{code}")]
        public ActionResult<string> AddRegistration(string code)
        {
            try
            {
                _registrationsService.AddRegistration(code);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpDelete("{code}")]
        public ActionResult<string> DeleteRegistration(string code)
        {
            try
            {
                _registrationsService.DeleteRegistration(code);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}