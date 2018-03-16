using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoWebAPI.Models.Entities;
using TodoWebAPI.ViewModels;


namespace TodoWebAPI.Utility
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {

            CreateMap<RegistrationViewModel, AppUser>()
                .ReverseMap();

            //Department
            //CreateMap<Department, DepartmentViewModelCreate>()
            //    .ReverseMap();

            //CreateMap<Department, DepartmentViewModel>()
            //    .ReverseMap();

            //// Course
            //CreateMap<Course, CourseViewModelShow>()
            //   .ReverseMap();

            //CreateMap<Course, CourseViewModelCreate>()
            //   .ReverseMap();

            ////Student
            //CreateMap<Student, StudentViewModel>()
            //  .ReverseMap();

        }

    }
}
