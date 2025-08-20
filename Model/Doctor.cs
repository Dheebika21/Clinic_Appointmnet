using Microsoft.EntityFrameworkCore;

namespace Clinic_Appointmnet.Model
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        public string DoctorName { get; set; }

        public ICollection<Appointment> Appointments { get; set; }


    }
}
