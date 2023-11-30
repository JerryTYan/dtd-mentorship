using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DTD_Mentorship_Project.Pages
{
    public class UserModel
    {
        public string? UserId { get; set; }
        public string? UserType { get; set; }
    }

    public class MentorshipModel : PageModel
    {

        public UserModel? CurrentUser { get; set; }



        public void OnGet()
        {
            //switch between mentee and mentor to see different stuff on page
            //ideally we use userid to get userdat from db, and then determine if page
            //is meant for mentor or mentee
            CurrentUser = new UserModel {UserId = "45", UserType = "mentor"};
        }
    }
}