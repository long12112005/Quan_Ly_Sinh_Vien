using AutoMapper;
using StudentClassApi.Models;
using StudentClassApi.Dtos;

namespace StudentClassApi.Profiles
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