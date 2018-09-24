﻿using AutoMapper;
using LearningSystem.Core.Entities;
using LearningSystem.Core.Services;
using LearningSystem.Web.Helpers;
using LearningSystem.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningSystem.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private ICourseService courseService;

        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet("get/{id}")]
        public IActionResult Get(int id)
        {
            var course = this.courseService.GetCourse(id);
            return Ok(course);
        }

        [AuthorizeUserType(UserType.Trainer)]
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var courses = this.courseService.GetAll();
            return Ok(courses);
        }

        [AuthorizeUserType(UserType.Trainer)]
        [HttpPost("insert")]
        public IActionResult Insert(CourseRequest course)
        {
            var courseModel = Mapper.Map<Course>(course);
            this.courseService.Insert(courseModel);
            return Ok();
        }

        [AuthorizeUserType(UserType.Trainer)]
        [HttpPut("edit/{id}")]
        public IActionResult Edit(CourseRequest course)
        {
            var courseModel = Mapper.Map<Course>(course);
            this.courseService.Edit(courseModel);
            return Ok();
        }

        [AuthorizeUserType(UserType.Trainer)]
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            this.courseService.Delete(id);
            return Ok();
        }
    }
}
