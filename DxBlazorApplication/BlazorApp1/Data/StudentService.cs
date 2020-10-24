using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorApp1.Data
{
    public class StudentService
    {
        private HttpClient _client { get; set; }

        public StudentService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Student>> GetStudentAllAsync()
        {
            List<Student> students = new List<Student>();

            students = await _client.GetFromJsonAsync<List<Student>>("/api/students"); //GET READ

            return students;
        }

        public async Task<Student> GetStudentById(int id)
        {
            List<Student> students = new List<Student>();
            Student student = new Student();

            students = await _client.GetFromJsonAsync<List<Student>>("/api/students"); //GET READ

            student = students.First(x => x.Id == id);

            return student;
        }

        public async Task Insert(IDictionary<string, object> newValue)
        {
            List<Student> students = new List<Student>();
            Student addedStudent = new Student();

            addedStudent = DictionaryToStudent(addedStudent, newValue);
            students.Add(addedStudent);

            await _client.PostAsJsonAsync("/api/students", students);
        }

        public async Task Update(Student student, IDictionary<string, object> newValue)
        {
            List<Student> students = new List<Student>();

            Student updatedStudent = DictionaryToStudent(student, newValue);
            students.Add(student);

            await _client.PutAsJsonAsync("/api/students", students);
        }

        public async Task Delete(Student student)
        {
            await _client.DeleteAsync("/api/students/" + student.Id);
        }

        // IDictionary를 Student 객체로 변환
        public Student DictionaryToStudent(Student student, IDictionary<string, object> newValue)
        {
            if (newValue.ContainsKey("Grade")) { student.Grade = int.Parse(newValue["Grade"].ToString()); }
            if (newValue.ContainsKey("Cclass")) { student.Cclass = int.Parse(newValue["Cclass"].ToString()); }
            if (newValue.ContainsKey("No")) { student.No = newValue["No"].ToString(); }
            if (newValue.ContainsKey("Name")) { student.Name = newValue["Name"].ToString(); }
            if (newValue.ContainsKey("Score")) { student.Score = newValue["Score"].ToString(); }

            return student;
        }
    }
}
