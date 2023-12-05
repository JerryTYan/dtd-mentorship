using DTD_Mentorship_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DTD_Mentorship_Project.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DBContext _dbContext;


        public IndexModel(Models.DBContext db, ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if(_dbContext.Find<Models.User>("Jerry") == null)
            {
                //seed the area table
                _dbContext.Add(new Models.Area
                {
                    AreaId = 1,
                    AreaName = "Data Science"
                });

                _dbContext.Add(new Models.Area
                {
                    AreaId = 2,
                    AreaName = "Software Development"
                });

                _dbContext.Add(new Models.Area
                {
                    AreaId = 3,
                    AreaName= "UI/UX"
                });

                _dbContext.Add(new Models.Area
                {
                    AreaId = 4,
                    AreaName = "Project Management"
                });

                //seed the interns
                _dbContext.Add(new Models.User
                {
                    FirstName = "Jerry",
                    LastName = "Yan",
                    Email = "Jerry@gmail.com",
                    Password = "abcd",
                    Intern = true,
                    Mentor = false,
                    Mentorship = false,
                    UserId = 1
                }) ;

                _dbContext.Add(new Models.User
                {
                    FirstName = "Eduardo",
                    LastName = "Glavez",
                    Email = "EG@gmail.com",
                    Password = "abcdhuj",
                    Intern = true,
                    Mentor = false,
                    Mentorship = false,
                    UserId = 2
                });

                _dbContext.Add(new Models.User
                {
                    FirstName = "Ivan",
                    LastName = "Flores",
                    Email = "Ivan@gmail.com",
                    Password = "abcdbgh",
                    Intern = true,
                    Mentor = false,
                    Mentorship = false,
                    UserId = 3
                });

                _dbContext.Add(new Models.User
                {
                    FirstName = "Jorge",
                    LastName = "Gaytan",
                    Email = "Jorge@gmail.com",
                    Password = "abcd123",
                    Intern = true,
                    Mentor = false,
                    Mentorship = false,
                    UserId = 4
                });

                _dbContext.Add(new Models.User
                {
                    FirstName = "Kathy",
                    LastName = "Aj",
                    Email = "Kathy@gmail.com",
                    Password = "abcdnugh",
                    Intern = true,
                    Mentor = false,
                    Mentorship = false,
                    UserId = 5
                });

                //seed the mentors users

                _dbContext.Add(new Models.User
                {
                    FirstName = "John",
                    LastName = "Birkenstock",
                    Email = "John@gmail.com",
                    Password = "birke",
                    Intern = false,
                    Mentor = true,
                    Mentorship = false,
                    UserId = 6
                });

                _dbContext.Add(new Models.User
                {
                    FirstName = "Melton",
                    LastName = "Johns",
                    Email = "Melton@gmail.com",
                    Password = "johns",
                    Intern = false,
                    Mentor = true,
                    Mentorship = false,
                    UserId = 7
                });

                _dbContext.Add(new Models.User
                {
                    FirstName = "Marvin",
                    LastName = "Elias",
                    Email = "Marvin@gmail.com",
                    Password = "elias",
                    Intern = false,
                    Mentor = true,
                    Mentorship = false,
                    UserId = 8
                });


                _dbContext.Add(new Models.User
                {
                    FirstName = "Arnold",
                    LastName = "Palmer",
                    Email = "Arnold@gmail.com",
                    Password = "Palmer",
                    Intern = false,
                    Mentor = true,
                    Mentorship = false,
                    UserId = 9
                });


                _dbContext.Add(new Models.User
                {
                    FirstName = "Jetson",
                    LastName = "Brians",
                    Email = "Jetson@gmail.com",
                    Password = "brinas",
                    Intern = false,
                    Mentor = true,
                    Mentorship = false,
                    UserId = 10
                });





            }
            

        }
    }
}