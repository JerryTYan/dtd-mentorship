using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DTD_Mentorship_Project.Models;



namespace DTD_Mentorship_Project.Pages
{


    public class MentorshipModel : PageModel
    {

        public User? CurrentUser { get; set; }



        public void OnGet()
        {
            //switch between mentee and mentor to see different stuff on page
            //ideally we use userid to get userdat from db, and then determine if page
            //is meant for mentor or mentee
            CurrentUser = new User {UserId = "45", UserType = "mentee"};
        }
    }
}