using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DTD_Mentorship_Project.Models;


namespace DTD_Mentorship_Project.Pages
{


    public class MentorSelectModel : PageModel
    {

        //do some sorting or query beforehand to put the mentors into UX, Cyber, IT, need to make this process dynamic for
        //the different types
        public List<Mentor>? Mentors_UX { get; set; }
        public List<Mentor>? Mentors_CB { get; set; }
        public List<Mentor>? Mentors_IT { get; set; }


        public void OnGet()
        {
            Mentors_UX = new List<Mentor> {
                new Mentor { Name = "Joe Weather", Description = "I like UX", Title = "Lead UX Designer", Area = "UX", Image = "http://placekitten.com/200/300"  },
                new Mentor { Name = "Sarah West", Description = "I also like UX", Title = "UX Manager", Area = "UX", Image = "http://placekitten.com/200/300" },
                new Mentor { Name = "Ghoe Peather", Description = "I like UX", Title = "Lead UX Designer", Area = "UX", Image = "http://placekitten.com/200/300"  },
                new Mentor { Name = "Marah Lest", Description = "I also like UX", Title = "UX Manager", Area = "UX", Image = "http://placekitten.com/200/300" },
                new Mentor { Name = "Toe Meather", Description = "I like UX", Title = "Lead UX Designer", Area = "UX", Image = "http://placekitten.com/200/300"  },
                new Mentor { Name = "Darah Vest", Description = "I also like UX", Title = "UX Manager", Area = "UX", Image = "http://placekitten.com/200/300" },
            };

            Mentors_CB = new List<Mentor> {
                new Mentor { Name = "Joe Weather", Description = "I like Cyber", Title = "Lead Cyber Designer", Area = "Cybersecurity", Image = "http://placekitten.com/200/300"  },
                new Mentor { Name = "Sarah West", Description = "I also like Cyber", Title = "Cyber Manager", Area = "Cybersecurity", Image = "http://placekitten.com/200/300" },
                new Mentor { Name = "Ghoe Peather", Description = "I like Cyber", Title = "Lead Cyber Designer", Area = "Cybersecurity", Image = "http://placekitten.com/200/300"  },
                new Mentor { Name = "Marah Lest", Description = "I also like Cyber", Title = "Cyber Manager", Area = "Cybersecurity", Image = "http://placekitten.com/200/300" },
                new Mentor { Name = "Toe Meather", Description = "I like Cyber", Title = "Lead Cyber Designer", Area = "Cybersecurity", Image = "http://placekitten.com/200/300"  },
                new Mentor { Name = "Darah Vest", Description = "I also like Cyber", Title = "Cyber Manager", Area = "Cybersecurity", Image = "http://placekitten.com/200/300" },
            };
            Mentors_IT = new List<Mentor> {
                new Mentor { Name = "Joe Weather", Description = "I like IT", Title = "Lead IT Designer", Area = "IT Support", Image = "http://placekitten.com/200/300"  },
                new Mentor { Name = "Sarah West", Description = "I also like IT", Title = "IT Manager", Area = "IT Support", Image = "http://placekitten.com/200/300" },
                new Mentor { Name = "Ghoe Peather", Description = "I like IT", Title = "Lead IT Designer", Area = "IT Support", Image = "http://placekitten.com/200/300"  },
                new Mentor { Name = "Marah Lest", Description = "I also like IT", Title = "IT Manager", Area = "IT Support", Image = "http://placekitten.com/200/300" },
                new Mentor { Name = "Toe Meather", Description = "I like IT", Title = "Lead IT Designer", Area = "IT Support", Image = "http://placekitten.com/200/300"  },
                new Mentor { Name = "Darah Vest", Description = "I also like IT", Title = "IT Manager", Area = "IT Support", Image = "http://placekitten.com/200/300" },
            };


        }
    }
}
