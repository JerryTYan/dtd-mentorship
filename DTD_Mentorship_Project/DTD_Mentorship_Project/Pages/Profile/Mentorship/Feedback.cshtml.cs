using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DTD_Mentorship_Project.Models;


namespace DTD_Mentorship_Project.Pages
{
    public class FeedbackModel : PageModel
    {
		public Mentor? CurrentMentor { get; set; }



		public void OnGet()
		{
			//this is where we need to fetch data from the server to get the current mentees assigned mentor
			CurrentMentor = new Mentor { Name = "Jane Doe", Description = "blah", Title = "Introduction to UI/UX Design", Area = "UX/UI Design", Image = "placeholder.jpg" };
		}
	}
}