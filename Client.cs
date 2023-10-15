public class Client : Person // Клієнт (наслідування від Person)
{
    // На одного клієнта може приходитися багато замовлень, але на замовлення лише один клієнт
    public string Address { get; set; } // Адреса
    public string OrderID { get; set; } // ID замовлення
    public List<string> orders;

    public Client()
    {
        Console.Write("Address: "); Address = Console.ReadLine();
        Console.WriteLine($"Client {FullName} added.\n");
    }

    override public void Presentation()
    {
        Console.WriteLine($"My name is {FullName}. I'm just a client.\n");
    }
}
