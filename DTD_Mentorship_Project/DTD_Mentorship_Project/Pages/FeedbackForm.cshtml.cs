using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DTD_Mentorship_Project.Pages
{
    public class FeedbackFormModel : PageModel
    {

        public string? MentorImage { get; set; }
        public string? MentorName { get; set; }
        public string? MentorDescription { get; set; }
        public string? MentorTitle { get; set; }
        public string? MentorArea { get; set; }

        public void OnGet()
        {
            MentorImage = Request.Query["image"];
            MentorName = Request.Query["name"];
            MentorDescription = Request.Query["description"];
            MentorTitle = Request.Query["title"];
            MentorArea = Request.Query["area"];
        }
    }
}
