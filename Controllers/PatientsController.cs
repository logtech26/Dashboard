using Dashboard.Data;
using Dashboard.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public PatientsController(AppDbContext context) {
            _appDbContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _appDbContext.Patients.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            var patient = await _appDbContext.Patients.FindAsync(id);
            if(patient == null) return NotFound();
            return Ok(patient);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Patient patient)
        {
            _appDbContext.Patients.Add(patient);
            await _appDbContext.SaveChangesAsync();
            return Ok(patient);
        }
    }
}
