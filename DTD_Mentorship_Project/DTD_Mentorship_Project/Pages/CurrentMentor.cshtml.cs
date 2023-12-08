using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DTD_Mentorship_Project.Pages
{
    public class CurrentMentorSelectModel : PageModel
    {
         public string? MentorImage { get; set; }
    public string? MentorName { get; set; }
    public string? MentorDescription { get; set; }
        public string? MentorTitle { get; set; }
                public string? Area { get; set; }


        public void OnGet()
        {
            MentorImage = Request.Query["image"];
    MentorName = Request.Query["name"];
    MentorDescription = Request.Query["description"];
        MentorTitle = Request.Query["title"];
        Area = Request.Query["area"];

        }
    }
}