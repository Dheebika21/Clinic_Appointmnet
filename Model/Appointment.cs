using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_Appointmnet.Model
{
    public class AppointmentDbContext:DbContext
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options) 
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }

    [Table("Patient")]
    public class Patient
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int PatientId { get; set; }

        public string PatientName { get; set; }

        public int contact {  get; set; }
    }

    [Table("Appointment")]
    public class Appointment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int PatientId { get; set; }
        public int AppointmentId { get; set; }

        public int DoctorId { get; set; }

        public string DoctorName { get; set; }

        public StringComparer Department { get; set; }

        public DateTime AppointmentTime { get; set; }

        public bool Status { get; set; }

    }

    public class AppointmentModel
    {
        public int AppointmentId { get; set; }

        public int PatientId { get; set; }

        public string PatientName { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }

        public StringComparer Department { get; set; }
        public DateTime AppointmentTime { get; set; }
        public int contact { get; set; }


    }
}
