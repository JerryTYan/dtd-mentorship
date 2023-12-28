using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DTD_Mentorship_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace DTD_Mentorship_Project.Pages
{

    
    public class MentorSelectModel : PageModel
    {
        private readonly ILogger<MentorSelectModel> _logger;
        private readonly DBContext _dbContext;
        
        public MentorSelectModel(Models.DBContext db, ILogger<MentorSelectModel> logger)
        {
            _logger = logger;
            _dbContext = db;
        }


        //do some sorting or query beforehand to put the mentors into UX, Cyber, IT, need to make this process dynamic for
        //the different types
        public List<Models.User>? Mentors_UX { get; set; }
        public List<Models.User>? Mentors_CB { get; set; }
        public List<Models.User>? Mentors_IT { get; set; }


        public void OnGet()
        {
           Mentors_CB = (from user in _dbContext.Users
                         join userarea in _dbContext.UserAreas on user.UserId equals userarea.UserId
                         join area in _dbContext.Areas on userarea.AreaId equals area.AreaId
                         where area.AreaId == 3 && user.IdentityId == 9
                         select user).ToList();

            Mentors_UX = (from user in _dbContext.Users
                          join userarea in _dbContext.UserAreas on user.UserId equals userarea.UserId
                          join area in _dbContext.Areas on userarea.AreaId equals area.AreaId
                          where area.AreaId == 2 && user.IdentityId == 9
                          select user).ToList();

            Mentors_IT = (from user in _dbContext.Users
                          join userarea in _dbContext.UserAreas on user.UserId equals userarea.UserId
                          join area in _dbContext.Areas on userarea.AreaId equals area.AreaId
                          where area.AreaId == 4 && user.IdentityId == 9
                          select user).ToList();

           /* if (!Mentors_CB.IsNullOrEmpty())
            {
                foreach(var item in Mentors_CB)
                {
                    _logger.LogInformation("User found: {User}", item.FirstName);
                    _logger.LogInformation("Id found: {IdName}", item.UserId);

                }
              

            }
            else
            {
                _logger.LogInformation("No user found");
            }
*/


        }
    }
}
