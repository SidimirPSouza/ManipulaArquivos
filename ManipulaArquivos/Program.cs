var path = @"C:\dev\";
var file = "dados.dat";

Contact CreateContact()
{
    Console.WriteLine("Informe o nome do contato: ");
    var name = Console.ReadLine();
    Console.WriteLine("Informe o numero do contato: ");
    var phone = Console.ReadLine();
    Console.WriteLine("Informe o email do contato: ");
    var email = Console.ReadLine();

    var contact = new Contact(name, phone, email);
    return contact;
}

List<Contact> CreateContactList()
{
    List<Contact> contacts = new List<Contact>();
    while (true)
    {
        Console.WriteLine("1 - Adicionar mais um contato ");
        Console.WriteLine("0 - Encerrar ");
        var options = int.Parse(Console.ReadLine());

        switch (options)
        {
            case 1:
                var contact = CreateContact();
                contacts.Add(contact);
                break;
            case 0:
                return contacts;
            default:
                Console.WriteLine("Opção Invalida");
                break;
        }
    }
}

void ReadContacts()
{
    //var reader = new StreamReader(path + file);
    var arquivo = File.ReadAllLines(path + file);
    var contacts = new List<Contact>();
    foreach (var item in arquivo)
    {
        var properties = item.Split(',');

        var contact = new Contact(properties[0].ToString(), properties[1].ToString(), properties[2].ToString());
        contacts.Add(contact);
    }
    //Console.WriteLine(reader.ReadToEnd());
    //reader.Close();
    foreach (var item in contacts)
    {
        Console.WriteLine(item.ConvertForLine());
    }
}

bool PathValidation(string p)
{
    if (Directory.Exists(p))
        return true;

    try
    {
        Directory.CreateDirectory(p);
        return true;
    }
    catch (DirectoryNotFoundException e)
    {
        Console.WriteLine(e);
        return false;
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        return false;
    }

}

bool FileValidation(string p)
{
    if (File.Exists(p + file))
        return true;
    try
    {
        if (PathValidation(p))
        {
            File.Create(p + file).Close();
            return true;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        return false;
    }
    return false;
}

void ShowContacts()
{
    var reader = new StreamReader(path + file);

    //while (reader.Read() != -1)
    //{
    //    Console.WriteLine(reader.ReadLine());
    //}

    Console.WriteLine(reader.ReadToEnd());

    reader.Close();
}

void AddContacts()
{
    if (FileValidation(path))
    {
        var contacts = CreateContactList();
        foreach (var item in contacts)
        {
            File.AppendAllText(path + file, item.ConvertForLine() + "\n");
        }
    }
}

int MainMenu()
{
    Console.WriteLine("1 - Adicionar Contato no arquivo.");
    Console.WriteLine("2 - Mostrar contatos do arquivo.");
    Console.WriteLine("0 - Sair.");
    return int.Parse(Console.ReadLine());
}

while (true)
{
    switch (MainMenu())
    {
        case 1:
            //Console.WriteLine("Informe sua frase desmotivacional: ");
            AddContacts();
            break;
        case 2:
            try
            {
                ReadContacts();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case 0:
            Console.WriteLine("Hasta la vista, baby!");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Não entendi!");
            break;
    }
}