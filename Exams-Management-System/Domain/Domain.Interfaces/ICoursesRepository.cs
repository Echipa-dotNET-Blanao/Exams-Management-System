using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.Interfaces
{
    public interface ICoursesRepository
    {
        string getExamCourseById(int id);
    }
}
