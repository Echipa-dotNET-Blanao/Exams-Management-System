namespace Domain.Domain.Entities
{
    public class Student
    {
        public Student(){}

        public Student(char id, string email, string passwordBase, string passwordHash, string fullName, int studyYear,
            char studyGroup)
        {
            this.id = id;
            this.email = email;
            this.passwordBase = passwordBase;
            this.passwordHash = passwordHash;
            this.fullName = fullName;
            this.studyYear = studyYear;
            this.studyGroup = studyGroup;

        }

        public char id { set; get; }
        public string email { set; get; }
        public string passwordBase { set; get; }
        public string passwordHash { set; get; }
        public string fullName { set; get; }
        public int studyYear { set; get; }
        public char studyGroup { set; get; }
    }
}