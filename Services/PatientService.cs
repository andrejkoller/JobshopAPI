using Microsoft.EntityFrameworkCore;
using PatientViewerAPI.Data;
using PatientViewerAPI.Models;

namespace PatientViewerAPI.Services
{
    public class PatientService(PatientViewerDbContext context)
    {
        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            return await context.Patients.ToListAsync();
        }
    }
}
