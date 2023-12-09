using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace DTD_Mentorship_Project.Pages
{
    public class FeedbackFormModel : PageModel
    {
		private readonly ILogger _logger;




		public FeedbackFormModel(ILogger<FeedbackFormModel> logger)
		{
			_logger = logger;
		}

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

        public IActionResult OnPost()
        {
			//fair
			var status1 = HttpContext.Request.Form["status1"];

			//professional
			var status2 = HttpContext.Request.Form["status2"];

			//workload
			var status3 = HttpContext.Request.Form["status3"];

			//recommend
			var status4 = HttpContext.Request.Form["status4"];

			//additional comment
			var comment = HttpContext.Request.Form["comment"];

			_logger.LogInformation("Status1: {Status1}, Status2: {Status2}, Status3: {Status3}, Status4: {Status4}, Comment: {Comment}", status1, status2, status3, status4, comment);

			return RedirectToPage("feedbackreceived", new
			{
				image = Request.Query["image"],
				name = Request.Query["name"],
				description = Request.Query["description"],
				title = Request.Query["title"],
				area = Request.Query["area"]

		});
		}
	}
}
