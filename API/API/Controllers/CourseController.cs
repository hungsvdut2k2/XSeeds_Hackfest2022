﻿using API.Models;
using API.Models.ModelDBs;
using API.Models.ModelDTOs;
using API.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace API.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IStudentService _studentService;
        private readonly IStudentCourseService _studentCourseService;

        public CourseController(ICourseService courseService, IStudentCourseService studentCourseService, IStudentService studentService)
        {
            this._courseService = courseService;
            this._studentCourseService = studentCourseService;
            this._studentService = studentService;
        }
        [HttpGet("student/{Course_Id}")]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudentInCourse(int Course_Id)
        {
            Course course = await _courseService.GetCourseById(Course_Id);
            if(course == null)
            {
                return BadRequest("Not Found");
            }
            IEnumerable<StudentsCourses> studentsCourses = await _studentCourseService.GetByCourseId(Course_Id);
            List<Student> students = new List<Student>();
            foreach(var item in studentsCourses)
            {
                Student temp =  await _studentService.GetStudentById(item.Student_Id);
                students.Add(temp);
            }
            return Ok(students);
        }
        [HttpPost("register/{Course_Id}/{Student_Id}")]
        public async Task<ActionResult> RegisterCourse(int Course_Id, int Student_Id)
        {
            Student student = await _studentService.GetStudentById(Student_Id);
            Course course =  await _courseService.GetCourseById(Course_Id);
            var new_middle_object = new StudentsCourses
            {
                Student = student,
                Course = course,
                Start_At = DateTime.Now,
            };
            await _studentCourseService.AddAsync(new_middle_object);
            return Ok();
        }
        [HttpGet("student/register/{Student_Id}")]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllRegisterdCourse(int Student_Id)
        {
            IEnumerable<StudentsCourses> middle_object = await _studentCourseService.GetByStudentId(Student_Id);
            List<Course> courses = new List<Course>();
            foreach(var item in middle_object)
            {
                courses.Add(item.Course);
            }
            return Ok(courses);
        }
        [HttpGet("student/completed/{Student_Id}")]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllCompletedCourse(int Student_Id)
        {
            IEnumerable<StudentsCourses> middle_object = await _studentCourseService.GetByStudentId(Student_Id);
            List<Course> completedCourses = new List<Course>();
            foreach(var item in middle_object)
            {
                if(item.Finish_At != null)
                {
                    completedCourses.Add(item.Course);
                }
            }
            return Ok(completedCourses);
        }
        [HttpGet("student/star/{Student_Id}")]
        public async Task<ActionResult<int>> GetStarsOfStudent(int Student_Id)
        {
            IEnumerable<StudentsCourses> middle_object = await _studentCourseService.GetByStudentId(Student_Id);
            int totalStar = 0;
            foreach (var item in middle_object)
            {
                if (item.Finish_At != null)
                {
                    totalStar += item.Star_Get_From_Course;
                }
            }
            return Ok(totalStar);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllCourses()
        {
            var result = await _courseService.GetAllAsync();
            return Ok(result);
        }
        [HttpGet]
        [Route("{Course_Id}")]
        public async Task<ActionResult<Course>> GetCourseById(int Course_Id)
        {
            return Ok(await _courseService.GetCourseById(Course_Id));
        }
        [HttpPost]

        public async Task<ActionResult> AddCourse([FromBody] CourseDTO request)
        {
            var newCourse = new Course
            {
                Course_Name = request.Course_Name,
                EstimateDay = request.EstimateDay,
                Max_Bonus_Star = request.Max_Bonus_Star,
                Type = request.Type
            };
            await _courseService.AddAsync(newCourse);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> UpdateCourse([FromBody] CourseDTO request)
        {
            Course course = await _courseService.GetCourseById(request.Course_Id);
            if (course == null)
            {
                return BadRequest();
            }
            course.EstimateDay = request.EstimateDay;
            course.Max_Bonus_Star = request.Max_Bonus_Star;
            course.Type = request.Type;
            course.Course_Name = request.Course_Name;
            _courseService.Update(course);
            return Ok("Update Successfully");
        }
        [HttpDelete("{Course_Id}")]
        public async Task<ActionResult> DeleteCourse(int Course_Id)
        {
            var course = await _courseService.GetCourseById(Course_Id);
            if (course == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _courseService.Delete(course);
            return Ok("Delete Successfully");
        }

    }
}
