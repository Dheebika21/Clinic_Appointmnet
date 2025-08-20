using Clinic_Appointmnet.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic_Appointmnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("allowcors")]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentDbContext _context;
        public AppointmentController(AppointmentDbContext contexts)
        {
            _context = contexts;
        }

        public IActionResult GetAppointment()
        {
            var list = ( from appointment in _context.Appointments
                         join patient in _context.Patients on appointment.PatientId equals patient.PatientId
                         select new
                         {
                             Appointment = appointment.AppointmentId,
                             Patient = patient.PatientName,
                             appointmentdate = appointment.AppointmentTime,
                             status = appointment.Status
                         }).ToList();
            return Ok(list);
        }

        [Route("ChgangeStatus")]
        [HttpGet]
        public IActionResult ChangeStatus(int appointmentid)
        {
            var data = _context.Appointments.SingleOrDefault(a => a.AppointmentId == appointmentid);
            data.Status = true;
            _context.SaveChanges();
                return Ok(data);
        }

        [Route("GetPatients")]
        [HttpGet]
        public IActionResult GetPatients()
        {
            var patientlist = _context.Patients.ToList();
            return Ok(patientlist);
        }

        [Route("CreateNewAppointment")]
        [HttpPost]
        public IActionResult CretaeNewAppointment(AppointmentModel obj)
        {
            var IsPatientExist = _context.Patients.SingleOrDefault(p => p.PatientId == obj.PatientId);
            if (IsPatientExist == null)
            {
                Patient _newPatient = new Patient()
                {
                    PatientName = obj.PatientName,
                    contact = obj.contact
                };
                _context.Patients.Add(_newPatient);
                _context.SaveChanges();


                Appointment _newAppointment = new Appointment()
                {
                    PatientId = _newPatient.PatientId,
                    DoctorId = obj.DoctorId,
                    DoctorName = obj.DoctorName,
                    Department = obj.Department,
                    AppointmentTime = obj.AppointmentTime,
                    Status = false
                };
                _context.Appointments.Add(_newAppointment);
                _context.SaveChanges();
            }
            else
            {

                Appointment _newAppointment = new Appointment()
                {
                    PatientId = IsPatientExist.PatientId,
                    DoctorId = obj.DoctorId,
                    DoctorName = obj.DoctorName,
                    Department = obj.Department,
                    AppointmentTime = obj.AppointmentTime,
                    Status = false
                };
                _context.Appointments.Add(_newAppointment);
                _context.SaveChanges();
            }

            return Ok("Appointment Created");

        }
    }
}

