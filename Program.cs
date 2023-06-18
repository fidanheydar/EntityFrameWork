using ConsoleApp20.Context;
using ConsoleApp20.Models;
using System;

AcademyDbContext academyDbContext = new AcademyDbContext();

bool flag = true;
while (flag)
{
    Console.WriteLine("1.Create Group");
    Console.WriteLine("2.Delete Group");
    Console.WriteLine("3.Get All Groups");
    Console.WriteLine("4.Get Group By Id");
    Console.WriteLine("5.Create Student");
    Console.WriteLine("6.Delete Student");
    Console.WriteLine("7.Get All Students");
    Console.WriteLine("8.Get Student By Id");
    Console.WriteLine("9.Update Student");
    Console.WriteLine("10.Update Group");

    Console.Write("Enter: ");
    string selectMenu = Console.ReadLine();
    switch (selectMenu)
    {
        case "1":
            CreateGroup();
            break;
        case "2":
            DeleteGroup();
            break;
        case "3":
            GetAllGroup();
            break;
        case "4":
            GetGroupById();
            break;
        case "5":
            CreateStudent();
            break;
        case "6":
            DeleteStudent();
            break;
        case "7":
            GetAllStudent();
            break;
        case "8":
            GetStudentById();
            break;
        case "9":
            UpdateStudent();
            break;
        case "10":
            UpdateGroup();
            break;
            //default: Console.WriteLine("Enter the step correctly");
    }
}

void GetAllGroup()
{
    List<Group> groups= academyDbContext.Groups.ToList();
    foreach (Group group in groups)
    {
        Console.WriteLine(group.Name);
        Console.WriteLine(group.Id);
        Console.WriteLine(group.CreatedDate);


    }

}

void GetAllStudent()
{
    List<Student> students= academyDbContext.Students.ToList();
    foreach (Student student in students)
    {
        Console.WriteLine(student.Id+ " Name: " +student.Name + "Surname:" + student.Surname);
    }
}

void CreateGroup()
{

    Console.WriteLine("Enter the Name:");
    string  name=Console.ReadLine();
    Group group = new Group
    {
        Name = name,
        CreatedDate = DateTime.Now,
        

    };
    academyDbContext.Add(group);
    academyDbContext.SaveChanges();
}

void CreateStudent()
{
    Console.WriteLine("Enter the Name:");
    string name=Console.ReadLine();
    Console.WriteLine("Enter the Surname:");
    string surname = Console.ReadLine();
    Console.WriteLine("Enter the GroupId:");
    string strId = Console.ReadLine();
    Student student = new Student
    {
        Name = name,
        Surname=surname,
        CreatedDate = DateTime.Now,
        GroupId = int.Parse(strId),
        group = academyDbContext.Groups.Find(strId)
        
       

    };
    academyDbContext.Add(student);
    academyDbContext.SaveChanges();
}


void GetStudentById()
{
    Console.WriteLine("Enter id:");
    int getId = int.Parse(Console.ReadLine());
    Student student = academyDbContext.Students.FirstOrDefault(x => x.Id == getId);
    if (student == null)
    {
        Console.WriteLine("No search results were found");


    }
    else if (student.IsDeleted == true)
    {
        Console.WriteLine("Student is deleted");
    }
    else
    {
        Console.WriteLine(student.Id + " " +student.Name);
    }
}



void DeleteStudent()
{
    Console.WriteLine("Enter id:");
    int studentId= int.Parse(Console.ReadLine());
    Student student = academyDbContext.Students.Find(studentId);
    if (student == null)
    {
        Console.WriteLine("Id is not Correct");
    }
    else
    {
        student.IsDeleted = true;
        Console.WriteLine("Student successfully deleted");
        academyDbContext.SaveChanges();
    }
}

void DeleteGroup()
{
    Console.WriteLine("Enter Id");
    int groupId= int.Parse(Console.ReadLine());
    Group group = academyDbContext.Groups.Find(groupId);
    if (group == null)
    {
        Console.WriteLine("Id is not Correct");
    }
    else
    {
        group.IsDeleted = true;
        Console.WriteLine("Group successfully deleted");
        academyDbContext.SaveChanges();
    }
}
void GetGroupById()
{
    Console.WriteLine("Enter Id");
    int getgrId= int.Parse(Console.ReadLine());
    Group group = academyDbContext.Groups.FirstOrDefault(x => x.Id == getgrId);
    if (group == null)
    {
        Console.WriteLine("No search results were found");
    }
}

void UpdateStudent()
{
    Console.WriteLine("Enter Id");
    int studentId= int.Parse(Console.ReadLine());
    Student student = academyDbContext.Students.Find(studentId);
    if (student == null)
    {
        Console.WriteLine("Enter correct Id");
        
    }
    else
    {
        Console.WriteLine("Enter new student name:");
        string newName=Console.ReadLine();
        Console.WriteLine("Enter new student Surname:");
        string newSurname = Console.ReadLine();
        student.Name = newName;
        student.Surname = newSurname;
        student.UpdateDate = DateTime.Now;
        Console.WriteLine("Enter new GroupId:");
        string newGroupId = Console.ReadLine();
        Console.WriteLine("Updated Successfully");
        student.group = academyDbContext.Groups.Find(newGroupId);
        academyDbContext.SaveChanges();

    }
}
void UpdateGroup()
{
    Console.WriteLine("Enter Id");
    int groupId= int.Parse(Console.ReadLine());
    Group group= academyDbContext.Groups.Find(groupId);
    if (group == null)
    {
        Console.WriteLine("Enter correct Id");
    }
    else
    {
        Console.WriteLine("Enter new group name:");
        string newGrName = Console.ReadLine();
        group.Name = newGrName;
        group.UpdateDate = DateTime.Now;
        Console.WriteLine("Updated Successfully");
        academyDbContext.SaveChanges();


    }


}