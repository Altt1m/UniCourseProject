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
        Console.Clear();
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

        clients.Add(this);
    }

    public void Show()
    {
        Console.WriteLine($"ПІБ: {FullName}\n" +
                        $"Номер телефону: {PhoneNumber}\n" +
                        $"Адреса: {Address}\n" +
                        $"ID замовлення: {OrderID}\n");
    }

    /// <summary>
    /// Повертає список клієнтів
    /// </summary>
    /// <returns>Список клієнтів</returns>
    public static List<Client> GetClientsList()
    {
        return clients;
    }

    /// <summary>
    /// Виводить список клієнтів
    /// </summary>
    public static void ShowClientsList()
    {
        int index = 1;
        foreach (Client client in clients)
        {
            Console.WriteLine($"Клієнт №{index}");
            client.Show();
            index++;
        }
    }

    /// <summary>
    /// Додавання замовлення до списку клієнта
    /// </summary>
    /// <param name="order">Замовлення клієнта</param>
    public void AddOrder(Order order)
    {
        orders.Add(order);
    }

    override public void Presentation()
    {
        Console.WriteLine($"Мене звати {FullName}. Я всього лише клієнт.\n");
    }
}
