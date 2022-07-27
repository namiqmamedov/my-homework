using Core.Entities;
using Core.Helpers;
using DataAccess.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App.Controller
{
    public class TeacherController
    {
        private TeacherRepository _teacherRepository;
        public TeacherController()
        {
            _teacherRepository = new TeacherRepository();
        }

        #region Create Teacher
        public void CreateTecaher()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Enter teacher name");
            string name = Console.ReadLine();

            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Enter teacher surname");
            string surname = Console.ReadLine();

            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, "Enter teacher age");
            string age = Console.ReadLine();
            int teacherAge;
            bool result = int.TryParse(age, out teacherAge);

            var teacher = new Teacher
            {
                Name = name,
                Surname = surname,
                Age = teacherAge,
            };

            _teacherRepository.Create(teacher);
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"Name:{teacher.Name}, Surname:{teacher.Surname}, Age:{teacher.Age}");
        }
        #endregion

        #region Delete Teacher
        public void DeleteTeacher()
        {
            ConsoleHelper.WriteTextWithColor(ConsoleColor.Yellow, "Enter teacher name");
            string name = Console.ReadLine();
            var teacher = _teacherRepository.Get(t => t.Name.ToLower() == t.Name.ToLower());
            if (teacher != null)
            {
                _teacherRepository.Delete(teacher);
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Green, $"{name} is deleted");
            }
            else
            {
                ConsoleHelper.WriteTextWithColor(ConsoleColor.Red, "This teacher doesn't exist");
            }
        }
        #endregion



    }
}
