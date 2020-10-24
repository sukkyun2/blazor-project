using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Model;

namespace WebApplication5
{
    public class StudentContext
    {
        public string _connectString { get; set; }

        public StudentContext(string connectString)
        {
            _connectString = connectString;
        }

        private MySqlConnection GetConnection()
        {
            //return new MySqlConnection(_connectString);
            return new MySqlConnection("Server=localhost;Port=3306;Database=connectdb;Uid=root;Pwd=5748");
        }

        //insert
        public void Create(List<Student> students)
        {
            string sql = @"INSERT INTO student (grade, cclass, no, name, score) 
                                 VALUES (@grade, @cclass, @no, @name, @score)";

            if (students != null)
            {
                using (IDbConnection db = GetConnection())
                {
                    db.Open();

                    for (int i = 0; i < students.Count; i++)
                    {
                        if (students[i].Id > 0) { continue; }  // 이미 Insert된 Student는 생략, 추가로 작성된 Row만 저장
                        Dapper.SqlMapper.Query<Student>(db, sql, students[i]);
                    }

                    db.Close();
                }
            }
        }

        //select
        public List<Student> Read()
        {
            List<Student> students = new List<Student>();

            using (IDbConnection db = GetConnection())
            {
                db.Open();

                students = Dapper.SqlMapper.Query<Student>(db, @"SELECT 
                                                                      id,
                                                                      grade,
                                                                      cclass,
                                                                      no,
                                                                      name,
                                                                      score
                                                                  FROM student") as List<Student>;

                db.Close();
            }

            return students;
        }

        //update
        public void Update(List<Student> changedStudents)
        {
            string sql = @"UPDATE student 
                                       SET
                                           cclass = @cclass,
                                           no = @no, 
                                           name = @name, 
                                           score = @score
                                        WHERE
                                           id=@id";

            if (changedStudents != null) // update할 데이터가 있다면
            {
                using (IDbConnection db = GetConnection())
                {
                    db.Open();

                    for (int i = 0; i < changedStudents.Count; i++)
                    {
                        Dapper.SqlMapper.Query<Student>(db, sql, changedStudents[i]);
                    }

                    db.Close();
                }
            }
        }

        //delete
        public void Remove(int selectedRowId)
        {

            string sql = @"DELETE FROM 
                                 student
                           WHERE 
                                id = @id";

            using (IDbConnection db = GetConnection())
            {
                db.Open();

                Dapper.SqlMapper.Query<Student>(db, sql, new { id = selectedRowId });

                db.Close();
            }
        }
    }

}
