using Dashboard.Data;
using Dashboard.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public DoctorsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        [HttpGet]

       public async Task<IActionResult> Get()

        {

            return Ok(await _appDbContext.doctors.ToListAsync());

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var doctor = await _appDbContext.doctors.FindAsync(id);
            if (doctor == null) return NotFound();
            return Ok(doctor);
            }


        [HttpPost]
        public async Task<IActionResult> AddNewDoctor(Doctor doctor)
        {
            _appDbContext.doctors.Add(doctor);
            await _appDbContext.SaveChangesAsync();
            return Ok(doctor);
        }





    }
}
