using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExLogg.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class StudentsRepository
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        //записи находятся в базе данных
        private readonly List<Student> _studentsList = new List<Student>()
        {
            new Student() { Id = 1, Name = "George", Age = 19 },
            new Student() { Id = 2, Name = "John", Age = 22 },
            new Student() { Id = 3, Name = "Mark", Age = 14 }
        };

        public List<Student> GetStudents()
        {
            logger.Trace("Произведено подключение к базе данных.");
            logger.Trace("Произведена выборка всех студентов");
            return _studentsList;
        }

        public Student GetStudentById(int id)
        {
            logger.Trace("Запрашиваемый id студента: " + id);
            logger.Trace("Попытка подключения к источнику данных");
            logger.Trace("Подключение прошло успешно. Затраченное время (мс): " + new TimeSpan(0, 0, 0, 0, 20).Milliseconds);
            var student = _studentsList.FirstOrDefault(x => x.Id == id);
            return student;
        }
    }
}
