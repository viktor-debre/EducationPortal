﻿namespace EducationPortal.UI.Services.Interfaces
{
    public interface ICourseEditService
    {
        public Task<List<CourseView>> GetCourses();

        public Task SetCourse(CourseView course);

        public Task RemoveCourse(CourseView course);

        public Task UpdateCourse(CourseView course);

        public Task<CourseView> GetByIdCourse(int id);
    }
}
