using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quan_Ly_Sinh_Vien.Models;
using Quan_Ly_Sinh_Vien.DTOs;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using Quan_ly_sinh_vien.Data;


namespace Quan_Ly_Sinh_Vien.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public StudentsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<StudentDto>> Create(CreateStudentDto createDto)
        {
            var cls = await _context.Classes.FindAsync(createDto.ClassId);
            if (cls == null) return BadRequest($"Class with id {createDto.ClassId} not found.");

            var student = _mapper.Map<Student>(createDto);
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            await _context.Entry(student).Reference(s => s.Class).LoadAsync();
            var dto = _mapper.Map<StudentDto>(student);
            return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0) pageNumber = 1;
            if (pageSize <= 0) pageSize = 10;

            var totalItems = await _context.Students.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var students = await _context.Students
                .Include(s => s.Class)
                .OrderBy(s => s.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var dtos = _mapper.Map<IEnumerable<StudentDto>>(students);
            var response = new
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = totalPages,
                Items = dtos
            };
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetById(int id)
        {
            var student = await _context.Students.Include(s => s.Class).FirstOrDefaultAsync(s => s.Id == id);
            if (student == null) return NotFound();
            return Ok(_mapper.Map<StudentDto>(student));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateStudentDto updateDto)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null) return NotFound();

            _mapper.Map(updateDto, student);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}