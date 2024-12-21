namespace MVC_ITI.Models
{
	public class StudentBL
	{
		List<Student> students;
        public StudentBL()
        {
            students = new List<Student>();
            students.Add(new Student() { Id = 1,Name =" fawzy"     , ImgURL = "1.jpg" });
			students.Add(new Student() { Id = 2,Name = "mohammmed" , ImgURL = "1.jpg" });
			students.Add(new Student() { Id = 3,Name = "Rana"      , ImgURL = "2.png"});
			students.Add(new Student() { Id = 4,Name = "Fayza"     , ImgURL = "2.png"});
		}
		public List<Student> Getall()
		{
			return students;
		}
		public Student GetById(int id)
		{
			return students.FirstOrDefault(s=> s.Id==id);
		}
    }
}
