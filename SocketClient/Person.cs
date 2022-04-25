namespace SocketClient;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public double Height { get; set; }
    public bool isMarried { get; set; }
    public char Sex { get; set; }
    public string[] Hobbies { get; set; }

    public Person(string firstName, string lastName, int age, double height, bool isMarried, char sex, string[] hobbies)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Height = height;
        this.isMarried = isMarried;
        Sex = sex;
        Hobbies = hobbies;
    }
    
    
}