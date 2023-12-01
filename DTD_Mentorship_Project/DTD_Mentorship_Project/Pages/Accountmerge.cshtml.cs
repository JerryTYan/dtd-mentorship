using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DTD_Mentorship_Project.Models;


namespace DTD_Mentorship_Project.Pages
{
    public class AccountmergeModel : PageModel
    {
        public User? CurrentUser { get; set; }

        public void OnGet()
        {
            //userdat from db, and then determine if page
            //is meant for mentor or mentee, if the form submission is successful 
            //then the user will now be a mentor
            CurrentUser = new User { UserId = "45", UserType = "mentee" };
        }
    }
}