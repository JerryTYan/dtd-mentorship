using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using DTD_Mentorship_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace DTD_Mentorship_Project.Pages
{

    
    public class MentorSelectModel : PageModel
    {
        private readonly ILogger<MentorSelectModel> _logger;
        //private readonly DBContext _dbContext;
        //Models.DBContext db, 
        public MentorSelectModel(ILogger<MentorSelectModel> logger)
        {
            _logger = logger;
           // _dbContext = db;
        }


        //do some sorting or query beforehand to put the mentors into UX, Cyber, IT, need to make this process dynamic for
        //the different types
        //public List<Models.User>? Mentors_UX { get; set; }
        //public List<Models.User>? Mentors_CB { get; set; }
        //public List<Models.User>? Mentors_IT { get; set; }


        public void OnGet()
        {
            //Mentors_IT = _dbContext.;

        }
    }
}
