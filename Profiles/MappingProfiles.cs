using AutoMapper;
using Quan_Ly_Sinh_Vien.Models;
using Quan_Ly_Sinh_Vien.DTOs;

namespace Quan_Ly_Sinh_Vien.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // --------- Class Mapping ----------
            CreateMap<Class, ClassDto>();
            CreateMap<CreateClassDto, Class>();

            // --------- Student Mapping ----------
            CreateMap<CreateStudentDto, Student>();
            CreateMap<UpdateStudentDto, Student>();

            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.Class.Name));
        }
    }
}
