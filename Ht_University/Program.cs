using Ht_university.Models;
using Ht_university.Repositories;

using System;
using System.Collections.Generic;

namespace Ht_university
{
    class Program
    {
        private static string _connectionString = @"Data Source=DESKTOP-F74K818\SQLEXPRESS01;Initial Catalog=University;Pooling=true;Integrated Security=SSPI";

        static void Main(string[] args)
        {
            IStudentRepository studentRepository = new StudentRawSqlRepository(_connectionString);
            IGroupsRepository groupsRepository = new GroupsRawSqlRepository(_connectionString);
            IStudentInGroupRepository studentInGroupRepository = new StudentInGroupRawSqlRepository(_connectionString);


            Console.WriteLine("Доступные команды:");
            Console.WriteLine("add-student - добавить студента");
            Console.WriteLine("add-group - добавить группу");
            Console.WriteLine("add-student-in-group - добавить студента в группу");
            Console.WriteLine("get-students - вывести список студентов");
            Console.WriteLine("get-groups - вывести список групп");
            Console.WriteLine("get-students-by-group-id - вывести студентов по Id группы");
            Console.WriteLine("exit - выйти из приложения");
            while (true)
            {
                string command = Console.ReadLine();

                if (command == "add-student")
                {
                    Console.WriteLine("Введите имя студента");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите возраст студента");
                    int age = Convert.ToInt32(Console.ReadLine());

                    studentRepository.Add(new Student
                    {
                        Name = name,
                        Age = age
                    });
                    if (name == null)
                    {
                        Console.WriteLine("Имя студента введено неверно");
                        return;
                    }
                    if (age < 1)
                    {
                        Console.WriteLine("Возраст студента введен неверно");
                        return;
                    }
                    Console.WriteLine("Успешно добавлено");
                }
                else if (command == "add-group")
                {
                    Console.WriteLine("Введите группу");
                    string name = Console.ReadLine();
                    groupsRepository.Add(new Groups
                    {
                        Name = name
                    });
                    if (name == null)
                    {
                        Console.WriteLine("Группа введена неверно");
                        return;
                    }
                    Console.WriteLine("Успешно добавлено");
                }
                else if (command == "add-student-in-group")
                {
                    try
                    {
                        Console.WriteLine("Введите id студента");
                        int studentId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите id группы");
                        int groupsId = Convert.ToInt32(Console.ReadLine());
                        
                        if(studentId < 1)
                        {
                            Console.WriteLine("id студента введен неверно");
                            return;
                        }
                        if (groupsId < 1)
                        {
                            Console.WriteLine(" id группы введен неверно");
                            return;
                        }
                        studentInGroupRepository.Add(new StudentInGroup
                        {
                            StudentId = studentId,
                            GroupsId = groupsId
                        });
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine(" id введен неверно");
                        return;
                    }
                   
                    Console.WriteLine("Успешно добавлено");

                }
                else if (command == "get-students")
                {
                    List<Student> students = studentRepository.GetAll();
                    foreach (Student student in students)
                    {
                        Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}");
                    }
                    Console.WriteLine("Успешно выведено");
                }
                else if (command == "get-groups")
                {
                    List<Groups> groups = groupsRepository.GetAll();
                    foreach (Groups groups1 in groups)
                    {
                        Console.WriteLine($"Id: {groups1.Id}, Name: {groups1.Name}");
                    }
                    Console.WriteLine("Успешно выведено");
                }
                else if (command == "get-students-by-group-id")
                {
                    try
                    {
                        Console.WriteLine("Введите id группы");
                        int groupId = int.Parse(Console.ReadLine());
                        Student student = new Student();
                        List<StudentInGroup> studentsInGroup = studentInGroupRepository.Get(groupId);
                        if (studentsInGroup.Count == 0)
                        {
                            Console.WriteLine("Студента нет в группе");
                        }
                        foreach (StudentInGroup studentInGroup in studentsInGroup)
                        {
                            student = studentRepository.GetStudent(studentInGroup.StudentId);
                            Console.WriteLine($"Id: {studentInGroup.StudentId}, name: {student.Name}");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("id группы введен неверно");
                        return;

                    }
                    
                }

                else if (command == "exit")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Команда не найдена");
                }
                }
            }
        }
    }

