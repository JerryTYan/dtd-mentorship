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
    public class MentorSelectModel : PageModel
    {

        //do some sorting or query beforehand to put the mentors into UX, Cyber, IT, need to make this process dynamic for
        //the different types
        public List<MentorModel>? Mentors_UX { get; set; }
        public List<MentorModel>? Mentors_CB { get; set; }
        public List<MentorModel>? Mentors_IT { get; set; }


        public void OnGet()
        {
            Mentors_UX = new List<MentorModel> {
                new MentorModel { Name = "Joe Weather", Description = "I like UX", Title = "Lead UX Designer", Area = "UX", Image = "http://placekitten.com/200/300"  },
                new MentorModel { Name = "Sarah West", Description = "I also like UX", Title = "UX Manager", Area = "UX", Image = "http://placekitten.com/200/300" },
                new MentorModel { Name = "Ghoe Peather", Description = "I like UX", Title = "Lead UX Designer", Area = "UX", Image = "http://placekitten.com/200/300"  },
                new MentorModel { Name = "Marah Lest", Description = "I also like UX", Title = "UX Manager", Area = "UX", Image = "http://placekitten.com/200/300" },
                new MentorModel { Name = "Toe Meather", Description = "I like UX", Title = "Lead UX Designer", Area = "UX", Image = "http://placekitten.com/200/300"  },
                new MentorModel { Name = "Darah Vest", Description = "I also like UX", Title = "UX Manager", Area = "UX", Image = "http://placekitten.com/200/300" },
            };

            Mentors_CB = new List<MentorModel> {
                new MentorModel { Name = "Joe Weather", Description = "I like Cyber", Title = "Lead Cyber Designer", Area = "Cybersecurity", Image = "http://placekitten.com/200/300"  },
                new MentorModel { Name = "Sarah West", Description = "I also like Cyber", Title = "Cyber Manager", Area = "Cybersecurity", Image = "http://placekitten.com/200/300" },
                new MentorModel { Name = "Ghoe Peather", Description = "I like Cyber", Title = "Lead Cyber Designer", Area = "Cybersecurity", Image = "http://placekitten.com/200/300"  },
                new MentorModel { Name = "Marah Lest", Description = "I also like Cyber", Title = "Cyber Manager", Area = "Cybersecurity", Image = "http://placekitten.com/200/300" },
                new MentorModel { Name = "Toe Meather", Description = "I like Cyber", Title = "Lead Cyber Designer", Area = "Cybersecurity", Image = "http://placekitten.com/200/300"  },
                new MentorModel { Name = "Darah Vest", Description = "I also like Cyber", Title = "Cyber Manager", Area = "Cybersecurity", Image = "http://placekitten.com/200/300" },
            };
            Mentors_IT = new List<MentorModel> {
                new MentorModel { Name = "Joe Weather", Description = "I like IT", Title = "Lead IT Designer", Area = "IT Support", Image = "http://placekitten.com/200/300"  },
                new MentorModel { Name = "Sarah West", Description = "I also like IT", Title = "IT Manager", Area = "IT Support", Image = "http://placekitten.com/200/300" },
                new MentorModel { Name = "Ghoe Peather", Description = "I like IT", Title = "Lead IT Designer", Area = "IT Support", Image = "http://placekitten.com/200/300"  },
                new MentorModel { Name = "Marah Lest", Description = "I also like IT", Title = "IT Manager", Area = "IT Support", Image = "http://placekitten.com/200/300" },
                new MentorModel { Name = "Toe Meather", Description = "I like IT", Title = "Lead IT Designer", Area = "IT Support", Image = "http://placekitten.com/200/300"  },
                new MentorModel { Name = "Darah Vest", Description = "I also like IT", Title = "IT Manager", Area = "IT Support", Image = "http://placekitten.com/200/300" },
            };


        }
    }
}
