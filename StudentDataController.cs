using Microsoft.AspNetCore.Mvc;
using StudentDetails.Data;
using StudentDetails.Models;

namespace StudentDetails.Controllers
{
    public class StudentDataController : Controller
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentDataController(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        public IActionResult Index()
        {
            return View(_studentDbContext.Students.ToList());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add([Bind("Id,FullName,DateofBirth,Gender,Email,Location,PhoneNumber")]StudentData data)
        {
            if (data != null)
            {
                _studentDbContext.Students.Add(data);
                _studentDbContext.SaveChanges();
                return RedirectToAction("Index");


            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            var prod=_studentDbContext.Students.FirstOrDefault(x => x.Id == id);
            return View(prod);
        }

        [HttpPost]
        public IActionResult Edit(StudentData student)
        {
            var stud=_studentDbContext.Students.Find(student.Id);
            if (stud != null)
            {
                stud.FullName = student.FullName;
                stud.DateofBirth = student.DateofBirth;
                stud.Gender = student.Gender;
                stud.Email = student.Email;
                stud.Location = student.Location;
                stud.PhoneNumber = student.PhoneNumber;

                _studentDbContext.SaveChanges();
                return View(stud);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            var studen = _studentDbContext.Students.FirstOrDefault(x => x.Id == id);

            if(studen != null)
            {
                _studentDbContext.Students.Remove(studen);
                _studentDbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

    }
}
