using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DTD_Mentorship_Project.Pages
{
    public class SubmissionModel : PageModel
    {

        private readonly ILogger<PrivacyModel> _logger;

        public SubmissionModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {

        }
    }
}


