using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinicSystem.Models;
using ClinicSystem.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClinicSystem.Entities;
namespace ClinicSystem.Controllers
{
    [EnableCors("allow")]
    [ApiController]
    [AllowAnonymous]
    public class PreAppointmentController : ControllerBase
    {
        private readonly IPreAppointmentRep rep;

        public PreAppointmentController(IPreAppointmentRep rep)
        {
            this.rep = rep;
        }

        [Route("[controller]/[Action]/{DoctorId}")]
        [HttpGet]
        public IActionResult GetTodayAppointments(string DoctorId)
        {
            return Ok(rep.GetTodayAppointments(DoctorId));
        }

        [Route("[controller]/[Action]")]
        [HttpGet]
        public IActionResult GetAppointmentsToCancel()
        {
            return Ok(rep.GetAppointmentsToCancel());
        }

        [Route("[controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult GetAppointmentDetails(int id)
        {
            return Ok(rep.GetAppointmentDetails(id));
        }


        [Route("[controller]/[Action]/{DoctorId}")]
        [HttpGet]
        public IActionResult GetDoctorCalendar(string DoctorId)
        {
            return Ok(rep.GetDoctorCalendar(DoctorId));
        }

        [Route("[controller]/[Action]/{phone}")]
        [HttpGet]
        public IActionResult PatientNotAttend(string phone)
        {
            return Ok(rep.PatientNotAttend(phone));
        }

        [Route("[controller]/[Action]/{phone}")]
        [HttpGet]
        public IActionResult GetPatientUpcomingAppointments(string phone)
        {
            return Ok(rep.GetPatientUpcomingAppointments(phone));
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult EditAppointment([FromBody] EditAppointmentModel obj)
        {
            return Ok(rep.EditAppointment(obj));
        }

        [Route("[controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult GetPatientAppointmentById(int id)
        {
            return Ok(rep.GetPatientAppointmentById(id));
        }

        [Route("[controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult DeleteAppointment(int id)
        {
            return Ok(rep.DeleteAppointment(id));
        }

        [Route("[controller]/[Action]/{phone}")]
        [HttpGet]
        public IActionResult GetPatientAppointmentByPhoneNumber(string phone)
        {
            return Ok(rep.GetPatientAppointmentByPhoneNumber(phone));
        }

        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult CreateAppointment(CreateAppointmentModel obj)
        {
            return Ok(rep.CreateAppointment(obj));
        }


        [Route("[controller]/[Action]")]
        [HttpPost]
        public IActionResult GetDoctorAvailableTimes(GetDoctorAvailableTimeModel obj)
        {
            return Ok(rep.GetDoctorAvailableTimes(obj));
        }


        [Route("[controller]/[Action]/{id}")]
        [HttpGet]
        public IActionResult GetDoctorAvailableDates(string id)
        {
            return Ok(rep.GetDoctorAvailableDates(id));
        }

     

        [Route("[controller]/[Action]/{phone}")]
        [HttpGet]
        public IActionResult GetPatientByPhoneNumber(string phone)
        {
            return Ok(rep.GetPatientByPhoneNumber(phone));
        }

        [Route("[controller]/[Action]")]
        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(rep.GetDoctors());
        }


    }
}
