using Dashboard.Data;
using Dashboard.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {

        private readonly AppDbContext _context;
        public AppointmentsController(AppDbContext context)
        {
            _context = context;
            
        }
        [HttpGet]

        public async Task<IActionResult> Get()

        {

            var data = await _context.Appointments

                .Include(a => a.Patient)

                .Include(a => a.Doctor)

                .ToListAsync();



            return Ok(data);

        }



        [HttpPost]

        public async Task<IActionResult> Create(Appointment appointment)

        {

            _context.Appointments.Add(appointment);

            await _context.SaveChangesAsync();

            return Ok(appointment);

        }
    }
}
