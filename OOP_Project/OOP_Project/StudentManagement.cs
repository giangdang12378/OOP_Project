using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;
using System.Xml;

namespace projekt
{
    // Delegate và sự kiện cho việc thêm, xóa sinh viên
    public delegate void StudentEventHandler(object sender, StudentEventArgs e);

    public class StudentEventArgs : EventArgs
    {
        public Student Student { get; private set; }
        public StudentEventArgs(Student student)
        {
            Student = student;
        }
    }

    public class StudentNotFoundException : Exception
    {
        public StudentNotFoundException(string message) : base(message) { }
    }

    // Lớp StudentManagementSystem (Quản lý sinh viên)
    public class StudentManagementSystem : IStudentManagement
    {
        //Add student dictionary
        public static Dictionary<string, Student> AddStudentdictionary()
        {
            Init.Read();
            Dictionary<string, Student> studentDictionary = new Dictionary<string, Student>();
            foreach (Student student in Init.students)
            {
                studentDictionary.Add(student.Id, student);
            }
            return studentDictionary;
        }

        private Dictionary<string, Student> studentDictionary = AddStudentdictionary();

        // Sự kiện cho việc thêm và xóa sinh viên
        public event StudentEventHandler StudentAdded;
        public event StudentEventHandler StudentRemoved;

        // Thêm sinh viên
        public void AddStudent(Student student)
        {
            studentDictionary[student.Id] = student;
            Console.WriteLine("Thêm sinh viên thành công.");

            // Kích hoạt sự kiện khi thêm sinh viên
            StudentAdded?.Invoke(this, new StudentEventArgs(student));
        }

        // Xóa sinh viên
        public void RemoveStudent(string studentID)
        {
            Student student = FindStudentByID(studentID);
            studentDictionary.Remove(studentID);
            Console.WriteLine("Xóa sinh viên thành công.");

            // Kích hoạt sự kiện khi xóa sinh viên
            StudentRemoved?.Invoke(this, new StudentEventArgs(student));
        }

        // Sửa thông tin sinh viên
        public void EditStudent(string studentID, Student updatedStudent)
        {
            Student student = FindStudentByID(studentID);
            student.Name = updatedStudent.Name;
            student.Email = updatedStudent.Email;
            student.PhoneNumber = updatedStudent.PhoneNumber;
            student.GPA = updatedStudent.GPA;
            student.ĐRL = updatedStudent.ĐRL;
            student.Bday = updatedStudent.Bday;
            student.Gender = updatedStudent.Gender;
            student.CourseIDs = updatedStudent.CourseIDs;
            student.DepartmentID = updatedStudent.DepartmentID;
            student.ClassID = updatedStudent.ClassID;
            Console.WriteLine("Cập nhật sinh viên thành công.");
        }

        // Hiển thị danh sách sinh viên
        public List<Student> DisplayStudentList()
        {

            return new List<Student>(studentDictionary.Values);
        }

        // Tìm kiếm sinh viên theo ID
        public Student FindStudentByID(string studentID)
        {
            Student student = studentDictionary.Values.FirstOrDefault(s => s.Id == studentID);

            if (student != null)
            {
                return student;
            }
            else
            {
                throw new StudentNotFoundException($"Sinh viên với ID {studentID} không tồn tại.");
            }
        }


        // Tìm sinh viên theo thuộc tính bất kỳ
        public List<Student> FindEntitiesByProperty<T>(string propertyName, T value)
        {
            List<Student> result = new List<Student>();

            foreach (Student student in studentDictionary.Values)
            {
                PropertyInfo property = typeof(Student).GetProperty(propertyName);
                if (property != null)
                {
                    var propertyValue = property.GetValue(student);
                    if (EqualityComparer<T>.Default.Equals((T)propertyValue, value))
                    {
                        result.Add(student);
                    }
                }
            }

            return result;
        }


        // Sort students by Name
        public List<Student> SortStudentsByName()
        {
            List<Student> studentsList = new List<Student>(studentDictionary.Values);
            studentsList.Sort(CompareByName);
            return studentsList;
        }

        private int CompareByName(Student x, Student y)
        {
            return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
        }

        public List<Student> SortStudentsByDRL()
        {
            List<Student> studentsList = new List<Student>(studentDictionary.Values);
            studentsList.Sort(CompareByDRL);
            return studentsList;
        }

        private int CompareByDRL(Student x, Student y)
        {
            return y.ĐRL.CompareTo(x.ĐRL); // Sort in descending order
        }

        // Sort students by GPA
        public List<Student> SortStudentsByGPA()
        {
            List<Student> studentsList = new List<Student>(studentDictionary.Values);
            studentsList.Sort(CompareByGPA);
            return studentsList;
        }

        private int CompareByGPA(Student x, Student y)
        {
            return y.GPA.CompareTo(x.GPA); // Sort in descending order
        }
        // Sắp xếp sinh viên theo niên khóa
        public List<Student> SortStudentsBySchoolYear()
        {
            List<Student> studentsList = new List<Student>(studentDictionary.Values);
            studentsList.Sort(CompareBySchoolYear);
            return studentsList;
        }

        // Phương thức so sánh theo niên khóa
        private int CompareBySchoolYear(Student x, Student y)
        {
            return x.SchoolYear.CompareTo(y.SchoolYear); // Sắp xếp tăng dần theo niên khóa
        }

    }
}
