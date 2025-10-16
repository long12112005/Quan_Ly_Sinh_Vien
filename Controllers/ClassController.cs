using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentClassApi.Data;
using StudentClassApi.Models;
using StudentClassApi.Dtos;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;


namespace StudentClassApi.Controllers
{
    [ApiController]
    [Route("api/classes")]
    public class ClassesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ClassesController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassDto>>> GetAll()
        {
            var classes = await _context.Classes.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<ClassDto>>(classes));
        }

        [HttpPost]
        public async Task<ActionResult<ClassDto>> Create(CreateClassDto createDto)
        {
            var cls = _mapper.Map<Class>(createDto);
            _context.Classes.Add(cls);
            await _context.SaveChangesAsync();
            var dto = _mapper.Map<ClassDto>(cls);
            return CreatedAtAction(nameof(GetAll), new { id = dto.Id }, dto);
        }

        [HttpGet("{classId}/students")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudentsInClass(int classId)
        {
            var students = await _context.Students
                .Where(s => s.ClassId == classId)
                .Include(s => s.Class)
                .ToListAsync();

            if (!students.Any()) return NotFound();
            return Ok(_mapper.Map<IEnumerable<StudentDto>>(students));
        }
    }
}