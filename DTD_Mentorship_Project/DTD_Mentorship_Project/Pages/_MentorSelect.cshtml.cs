using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DTD_Mentorship_Project.Pages
{

    public class MentorModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public string? Area { get; set; }
        public string? Image { get; set; }
    }
    public class _MentorSelectModel : PageModel
    {
        public List<MentorModel>? Mentors { get; set; }

        public void OnGet()
        {
            Mentors = new List<MentorModel> {
                new MentorModel { Name = "Joe Weather", Description = "I like UX", Title = "Lead UX Designer", Area = "UX", Image = "http://placekitten.com/200/300"  },
                new MentorModel { Name = "Sarah West", Description = "I also like UX", Title = "UX Manager", Area = "UX", Image = "http://placekitten.com/200/300" },
                new MentorModel { Name = "Ghoe Peather", Description = "I like UX", Title = "Lead UX Designer", Area = "UX", Image = "http://placekitten.com/200/300"  },
                new MentorModel { Name = "Marah Lest", Description = "I also like UX", Title = "UX Manager", Area = "UX", Image = "http://placekitten.com/200/300" },
                new MentorModel { Name = "Toe Meather", Description = "I like UX", Title = "Lead UX Designer", Area = "UX", Image = "http://placekitten.com/200/300"  },
                new MentorModel { Name = "Darah Vest", Description = "I also like UX", Title = "UX Manager", Area = "UX", Image = "http://placekitten.com/200/300" },
            };
        }
    }
}
