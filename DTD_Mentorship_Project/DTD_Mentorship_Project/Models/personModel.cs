public class personModel
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }

    // Default constructor
    public personModel()
    {
    }

    // Parameterized constructor
    public personModel(string name, int age, string city, string state, string zipCode)
    {
        Name = name;
        Age = age;
        City = city;
        State = state;
        ZipCode = zipCode;
    }
}

