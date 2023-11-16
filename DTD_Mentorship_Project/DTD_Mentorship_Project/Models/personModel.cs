public class personModel
{
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public int BirthYear { get; set; }

    // Default constructor
    public personModel()
    {
    }

    // Parameterized constructor
    public personModel(string name, int age, string city, string state, string zipCode, int birthYear)
    {
        Name = name;
        Age = age;
        City = city;
        State = state;
        ZipCode = zipCode;
        BirthYear = birthYear;
    }
}

