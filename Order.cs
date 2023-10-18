public class Order : IShow // Замовлення на ремонт та встановлення
{
    public string Address { get; set; } // Адреса (береться у клієнта)
    public string ServiceType { get; set; } // Тип послуги (Встановлення/Ремонт)
    public string DeviceName { get; set; } // Назва пристрою (для встановлення/ремонту)
    public string DeviceVendor { get; set; } // Виробник пристрою
    public string DateOfStart { get; set; } // Дата початку роботи
    public int WorkPeriod { get; set; } // Термін роботи (у днях)
    public double Cost { get; set; } // Вартість
    public string OrderID { get; set; } // ID замовлення *(у клієнта)

    private static int orderAmount = 0; // Номер замовлення (потім використовується)
    private static List<Order> orders = new List<Order>(); // Список всіх замовлень
    private static List<Order> repairOrders = new List<Order>(); // Список замовлень на ремонт
    private static List<Order> installOrders = new List<Order>(); // Список замовлень на встановлення
    private List<Specialist> specialists = new List<Specialist>(); // Список майстрів

    // Композиція
    public Specialist MainSpecialist { get; set; } // Головний майстер
    public Client ClientInfo { get; set; } // Інформація про клієнта (зокрема адреса)

    /// <summary>
    /// Конструктор з параметрами
    /// </summary>
    /// <param name="spec">Спеціаліст (об'єкт)</param>
    /// <param name="client">Клієнт (об'єкт)</param>
    /// <exception cref="Exception">Майстер зайнятий</exception>
    public Order(Specialist spec, Client client) // Конструктор
    {
        if (spec.IsFree) // Якщо майстер вільний
        {
            MainSpecialist = spec; // ...то він і назначається
            specialists.Add(spec);
            spec.IsFree = false; // Майстер перестає бути вільним
            spec.SetAssignedOrder(this); // Майстру приписується замовлення
        }
        else // Якщо ні
        {
            throw new Exception("Цей майстер наразі зайнятий."); // ...то видається помилка
        }
        ClientInfo = client;
        Address = ClientInfo.Address; // Адреса замовлення береться з адреси клієнта
        Console.Write("Вид послуги: "); ServiceType = Console.ReadLine();
        if (ServiceType == "Встановлення")
        {
            installOrders.Add(this); // Якщо замовлення на встановлення
        }
        else if (ServiceType == "Ремонт")
        {
            repairOrders.Add(this); // Якщо замовлення на ремонт
        }
        Console.Write("Назва прибору: "); DeviceName = Console.ReadLine();
        Console.Write("Виробник прибору: "); DeviceVendor = Console.ReadLine();
        Console.Write("Дата початку: "); DateOfStart = Console.ReadLine();
        Console.Write("Строк роботи (у днях): "); WorkPeriod = Int32.Parse(Console.ReadLine());
        Console.Write("Вартість: "); Cost = Double.Parse(Console.ReadLine());

        OrderID = "ORD" + ++orderAmount;
        if (client.OrderID != null) // Якщо вже є замовлення
        {
            client.OrderID = client.OrderID + ", " + this.OrderID;
        }
        else
        {
            client.OrderID = OrderID;
        }

        Console.Clear();
        Console.WriteLine($"Замовлення {OrderID} створено.\n");

        orders.Add(this);
        client.AddOrder(this);
    }

    /// <summary>
    /// Додає спеціаліста до списку виконуючих замовлення
    /// </summary>
    /// <param name="spec"></param>
    public void AddSpecialist(Specialist spec)
    {
        if (spec.IsFree) // Якщо майстер вільний
        {
            specialists.Add(spec); // ...то він додається до списку
            spec.IsFree = false; // Майстер перестає бути вільним
            spec.SetAssignedOrder(this); // Майстру приписується замовлення
        }
        else // Якщо ні
        {
            throw new Exception("Цей майстер наразі зайнятий."); // ...то видається помилка
        }
    }

    /// <summary>
    /// Виводить інформацію про замовлення
    /// </summary>
    public void Show()
    {
        Console.WriteLine($"Адреса: {Address}\n" +
                        $"Вид послуги: {ServiceType}\n" +
                        $"Назва прибору: {DeviceName}\n" +
                        $"Виробник прибору: {DeviceVendor}\n" +
                        $"Дата початку: {DateOfStart}\n" +
                        $"Строк роботи: {WorkPeriod}\n" +
                        $"Вартість: {Cost}\n" +
                        $"ID: {OrderID}\n");
    }

    /// <summary>
    /// Повератє список замовлень
    /// </summary>
    /// <returns>Список замовлень</returns>
    public static List<Order> GetOrdersList()
    {
        return orders;
    }

    /// <summary>
    /// 1. Список пристроїв для ремонту
    /// </summary>
    /// <returns>Список пристроїв на ремонт</returns>
    public static List<Order> GetRepairOrders()
    {
        return repairOrders;
    }

    /// <summary>
    /// Виводить список замовлень на ремонт
    /// </summary>
    public static void ShowRepairOrdersList()
    {
        foreach (Order order in repairOrders)
        {
            order.Show();
        }
        if (!repairOrders.Any())
        {
            Console.WriteLine("Немає замовлень на ремонт.\n");
        }
    }

    /// <summary>
    /// 2. Список пристроїв для встановлення
    /// </summary>
    /// <returns>Список замовлень на встановлення</returns>
    public static List<Order> GetInstallOrders()
    {
        return installOrders;
    }

    /// <summary>
    /// Виводить список замовлень на встановлення
    /// </summary>
    public static void ShowInstallOrdersList()
    {
        foreach (Order order in installOrders)
        {
            order.Show();      
        }
        if (!installOrders.Any())
        {
            Console.WriteLine("Немає замовлень на встановлення.\n");
        }
    }

    /// <summary>
    /// 3. Список клієнтів, які вибрали певний тип послуги
    /// </summary>
    /// <param name="serviceType">Тип послуги</param>
    /// <returns>Список клієнтів, які обрали певний тип послуги</returns>
    public static List<Client> GetClientsByServiceType(string serviceType)
    {
        return orders
            .Where(order => order.ServiceType == serviceType)
            .Select(order => order.ClientInfo)
            .Distinct() // Щоб уникнути дублікатів клієнтів
            .ToList();
    }

    /// <summary>
    /// Виводить список клієнтів, які обрали певний тип послуги
    /// </summary>
    /// <param name="serviceType"></param>
    public static void ShowClientsByServiceTypeList(string serviceType)
    {
        List<Client> clients = GetClientsByServiceType(serviceType);
        foreach (Client client in clients)
        {
            client.Show();
        }
        if (!clients.Any())
        {
            Console.Clear();
            Console.WriteLine($"Не знайдено жодного клієнта з типом послуги \"{serviceType}\"\n");
        }
    }


    /// <summary>
    /// 4. Середня вартість замовлень
    /// </summary>
    /// <returns>Середня вартість замовлень</returns>
    public static double GetAverageOrderCost()
    {
        Console.Clear();
        return orders.Average(o => o.Cost);
    }

    /// <summary>
    /// 5. Найдовший термін виконання роботи
    /// </summary>
    /// <returns>Найдовший термін виконання роботи</returns>
    public static int GetLongestWorkPeriod()
    {
        return orders.OrderByDescending(o => o.WorkPeriod).First().WorkPeriod;
    }

    /// <summary>
    /// 6. Найдорожче замовлення
    /// </summary>
    /// <returns>Об'єкт класу Order з найбільшим Cost</returns>
    public static Order GetMostExpensiveOrder()
    {
        return orders.OrderByDescending(o => o.Cost).First();
    }


    
}