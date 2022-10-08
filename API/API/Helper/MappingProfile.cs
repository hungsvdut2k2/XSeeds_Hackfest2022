using API.Models.ModelDBs;
using API.Models.ModelDTOs;
using AutoMapper;

namespace API.Helper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDTO>();
            CreateMap<CourseDTO, Course>();

        }
    }
}
