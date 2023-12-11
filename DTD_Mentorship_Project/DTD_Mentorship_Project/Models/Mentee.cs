namespace DTD_Mentorship_Project.Models
{
    public class Mentee
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public string? Area { get; set; }
        public string? Image { get; set; }

        public string GetShortDescription(int length = 50)
        {
            if (string.IsNullOrEmpty(Description))
            {
                return string.Empty;
            }

            return Description.Length <= length ? Description : Description.Substring(0, length) + "...";
        }
    }
}