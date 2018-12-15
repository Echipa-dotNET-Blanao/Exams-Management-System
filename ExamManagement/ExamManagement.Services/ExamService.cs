using ExamManagement.Core.Entities;
namespace ExamManagement.Services
{
    public class ExamService : Core.Interfaces.Services.IExamService
    {
        private Core.Interfaces.Repositories.IExamRepository _examRepository;
        private Core.Interfaces.Repositories.IGradeRepository _gradeRepostory;
        private Core.Interfaces.Repositories.ICourseRepository _courseRepository;
        private Core.Interfaces.Repositories.IStudentRepository _studentRepository;
        private Core.Interfaces.Services.IMailService _mailService;

        public ExamService(Core.Interfaces.Repositories.IExamRepository examRepository, Core.Interfaces.Repositories.IGradeRepository gradeRepository,
            Core.Interfaces.Repositories.ICourseRepository courseRepository, Core.Interfaces.Repositories.IStudentRepository studentRepository,
            Core.Interfaces.Services.IMailService mailService)
        {
            _examRepository = examRepository;
            _gradeRepostory = gradeRepository;
            _courseRepository = courseRepository;
            _studentRepository = studentRepository;
            _mailService = mailService;
        }
        public void CreateExam(Exam exam)
        {
            _examRepository.Add(exam);

            foreach (var stud in _studentRepository.GetAll())
            {
                foreach (var course in _courseRepository.GetAll())
                {
                    if (stud.studyYear == course.studyYear && course.id == exam.id)
                    {
                        Grade grade = new Grade(stud.id, exam.courseId, 0, 0);
                        _gradeRepostory.Add(grade);
                        continue;
                    }
                }
            }
        }

        public void StartExam(int examId)
        {
            Exam exam = _examRepository.GetById(examId);
            string token = "";
            System.Random r = new System.Random();
            for (int i = 0; i < 8; i++)
            {
                char c = ' ';
                int character = r.Next(0, 61);
                if (character <= 25)
                {
                    c = (char)(65 + character);
                }
                else if (character <= 51)
                {
                    c = (char)(97 + character - 26);
                }
                else
                {
                    c = (char)(48 + character - 52);
                }
                token += c;
            }
            exam.started = true;
            exam.token = token;
            _examRepository.Update(exam.id, exam);
        }

        public void CloseExam(int examId)
        {
            Exam exam = _examRepository.GetById(examId);
            exam.finished = true;
            _examRepository.Update(exam.id, exam);
        }


        public void PublishGrades(int examID)
        {
            Exam selectedExam = _examRepository.GetById(examID);
            selectedExam.gradesPublished = true;
            foreach (var student in _studentRepository.GetAll())
            {
                foreach (var course in _courseRepository.GetAll())
                {
                    if (student.studyYear != course.studyYear) continue;
                    foreach (var exam in _examRepository.GetAll())
                    {
                        if (exam.courseId != course.id || exam.id != examID) continue;
                        foreach (var grade in _gradeRepostory.GetAll())
                        {
                            if (grade.examId != exam.id || grade.studentId != student.id) continue;
                            _mailService.SendEmail(student.email, $"Your grade on {course.title}",
                            $"Your paper has been graded with {grade.grade} points!");
                        }
                    }
                }
            }
        }
        // Eliminate the separate functionality of Start/Close Exam/Publish Grades 
        public void ManageExam(int examId, Core.Interfaces.Enums.ManageExamTask task)
        {
            switch (task)
            {
                case Core.Interfaces.Enums.ManageExamTask.Start:
                    StartExam(examId);
                    break;
                case Core.Interfaces.Enums.ManageExamTask.End:
                    CloseExam(examId);
                    break;
                case Core.Interfaces.Enums.ManageExamTask.PublishGrades:
                    PublishGrades(examId);
                    break;
            }
        }
    }
}