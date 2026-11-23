
public class Contact
{
    public Contact(string name, string phone, string email)
    {
        Name = name;
        Phone = phone;
        Email = email;
    }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public string ConvertForLine()
    {
        return $"{Name},{Phone},{Email}";
    }

    public string ConvertForcolumns()
    {
        return $"{Name},{Phone},{Email}";
    }
}

