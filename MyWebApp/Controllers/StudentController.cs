using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using System.Xml;
using System.Xml.Serialization;

namespace MyWebApp.Controllers
{
    public class StudentController : Controller
    {
        /// <summary>
        /// Students List
        /// </summary>
        public List<StudentModel> Students = new List<StudentModel>();

        /// <summary>
        /// Count for Adding "id" for every student
        /// </summary>
        int count = 1;

        /// <summary>
        /// Filepath for student xml document
        /// </summary>
        string filePath = @"students.xml";

        public StudentController()
        {
            if (!System.IO.File.Exists(filePath))
            {
                XmlDocument xmlDocument = new XmlDocument();

                XmlDeclaration xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDocument.AppendChild(xmlDeclaration);

                XmlElement root = xmlDocument.CreateElement("root");
                xmlDocument.AppendChild(root);

                xmlDocument.Save("students.xml");
            }

            DeSerializerStudentsFromXml();
        }

        /// <summary>
        /// Showing the Students
        /// </summary>
        /// <returns></returns>
        public IActionResult List()
        {
            return View(Students);
        }

        /// <summary>
        /// Create a Student, the id creating auto
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public IActionResult Create(StudentModel student)
        {
            if (student.Id == null || student.Name == null || 
                student.SureName == null || student.Age == null || student.Points == null)
            {
                return View();
            }
            student.Id = count;
            count++;

            Students.Add(student);

            SerializerStudentsToXml();

            return RedirectToAction("List");
        }

        /// <summary>
        /// Editing the Student values
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public IActionResult Edit(StudentModel student)
        {
            if (student.Id == null || student.Name == null ||
                student.SureName == null || student.Age == null || student.Points == null)
            {
                return View();
            }

            foreach (StudentModel studentModel in Students)
            {
                if (student.Id == studentModel.Id)
                {
                    int indexOfStudent = Students.IndexOf(studentModel);

                    Students[indexOfStudent].Name = student.Name;
                    Students[indexOfStudent].SureName = student.SureName;
                    Students[indexOfStudent].Age = student.Age;
                    Students[indexOfStudent].Points = student.Points;

                    SerializerStudentsToXml();

                    return RedirectToAction("List");
                }
            }
            return View();
        }

        /// <summary>
        /// Delete the Student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public IActionResult Delete(StudentModel student)
        {
            if (student.Id == null)
            {
                return View();
            }

            foreach (StudentModel studentModel in Students)
            {
                if (student.Id == studentModel.Id)
                {
                    int indexOfStudent = Students.IndexOf(studentModel);

                    Students.RemoveAt(indexOfStudent);
                    
                    SerializerStudentsToXml();

                    return RedirectToAction("List");
                }
            }

            return View();
        }

        /// <summary>
        /// Serialize the List of Students to XML File
        /// </summary>
        private void SerializerStudentsToXml()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<StudentModel>));

                using (TextWriter textWriter = new StreamWriter(filePath))
                {
                    xmlSerializer.Serialize(textWriter, Students);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Found errors" + ex.Message);
            }
        }

        /// <summary>
        /// Deserialize XML file to LIst of Students
        /// </summary>
        private void DeSerializerStudentsFromXml()
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<StudentModel>));

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    Students = (List<StudentModel>)xmlSerializer.Deserialize(fileStream);  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
