public class Client : Person // Клієнт (наслідування від Person)
{
    // На одного клієнта може приходитися багато замовлень, але на замовлення лише один клієнт
    public string Address { get; set; } // Адреса
    public string OrderID { get; set; } // ID замовлення
    public List<string> orders;

    public Client()
    {
        Console.Write("Адреса: "); Address = Console.ReadLine();
        Console.WriteLine($"Клієнт {FullName} доданий.\n");
    }

    override public void Presentation()
    {
        Console.WriteLine($"Мене звати {FullName}. Я всього лише клієнт.\n");
    }
}
