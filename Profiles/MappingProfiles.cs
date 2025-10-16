using AutoMapper;
using Quan_Ly_Sinh_Vien.Models;
using Quan_Ly_Sinh_Vien.Dtos;

namespace Quan_Ly_Sinh_Vien.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Class, ClassDto>();
            CreateMap<CreateClassDto, Class>();
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.ClassName, opt => opt.MapFrom(src => src.Class.Name));
            CreateMap<CreateStudentDto, Student>();
            CreateMap<UpdateStudentDto, Student>()
                .ForMember(dest => dest.ClassId, opt => opt.Ignore());
        }
    }
}