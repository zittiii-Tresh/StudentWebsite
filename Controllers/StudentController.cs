using Microsoft.AspNetCore.Mvc;
using StudentWebsite.Models;

namespace StudentWebsite.Controllers
{
    public class StudentController : Controller
    {
        private static List <Student> students = new List<Student>();
        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.StudentID = students.Count + 1;
                students.Add(student);
                return RedirectToAction("Create");
            }
            return View(student);
        }

        public IActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(p => p.StudentID == id);
            if (student == null)
                return NotFound();
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(int id, Student student)
        {
            if (id != student.StudentID)
                return NotFound();

            if (ModelState.IsValid)
            {
                var existingStudent = students.FirstOrDefault(p => p.StudentID == id);
                if (existingStudent == null)
                    return NotFound();

                // Update pet details
                existingStudent.StudentName = student.StudentName;
                existingStudent.StudentAge = student.StudentAge;
                existingStudent.StudentBirthday = student.StudentBirthday;
                existingStudent.StudentYearSection = student.StudentYearSection;

                return RedirectToAction("Index");
            }
            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(p => p.StudentID == id);
            if (student == null)
                return NotFound();
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = students.FirstOrDefault(p => p.StudentID == id);
            if (student != null)
            {
                students.Remove(student);
            }
            return RedirectToAction("Index");
        }




    }
}
