public class Client : Person // Клієнт (наслідування від Person)
{
    // На одного клієнта може приходитися багато замовлень, але на замовлення лише один клієнт
    public string Address { get; set; } // Адреса
    public string OrderID { get; set; } // ID замовлення

    private List<Order> orders = new List<Order>(); // Список замовлень клієнта

    private static List<Client> clients = new List<Client>(); // Список клієнтів

    /// <summary>
    /// Конструктор за замовчуванням
    /// </summary>
    public Client()
    {
        Console.Write("Адреса: "); Address = Console.ReadLine();
        Console.WriteLine($"Клієнт {FullName} доданий.\n");

        clients.Add(this);
    }

    /// <summary>
    /// Конструктор з параметрами
    /// </summary>
    /// <param name="fN">ПІБ</param>
    /// <param name="pNum">Номер телефону</param>
    /// <param name="addr">Адреса</param>
    public Client(string fN, string pNum, string addr)
    {
        FullName = fN;
        PhoneNumber = pNum;
        Address = addr;
    }

    override public void Presentation()
    {
        Console.WriteLine($"Мене звати {FullName}. Я всього лише клієнт.\n");
    }

    /// <summary>
    /// Додавання замовлення до списку клієнта
    /// </summary>
    /// <param name="order">Замовлення клієнта</param>
    public void AddOrder(Order order)
    {
        orders.Add(order);
    }

    public void Show()
    {
        Console.WriteLine($"\nПІБ: {FullName}\n" +
                        $"Номер телефону: {PhoneNumber}\n" +
                        $"Адреса: {Address}\n" +
                        $"ID замовлення: {OrderID}\n");
    }
}
