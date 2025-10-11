using Microsoft.AspNetCore.Mvc;
using PatientViewerAPI.Services;

namespace PatientViewerAPI.Controllers
{
    public class PatientController(PatientService service) : Controller
    {
        [HttpGet("api/patients")]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await service.GetAllPatientsAsync();
            return patients == null || patients.Count == 0 ? NotFound("No patients found.") : Ok(patients);
        }
    }
}
