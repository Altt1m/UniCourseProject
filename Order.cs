public class Order // Замовлення на ремонт та встановлення
{
    public string Address { get; set; }
    public string ServiceType { get; set; } // Тип послуги (Встановлення/Ремонт)
    public string DeviceName { get; set; } // Назва пристрою (для встановлення/ремонту)
    public string DeviceVendor { get; set; } // Виробник пристрою
    public string DateOfStart { get; set; } // Дата початку роботи
    public string WorkPeriod { get; set; } // Термін роботи
    public double Cost { get; set; } // Вартість
    public string OrderID { get; set; } // ID замовлення *(у клієнта)

    private static int orderAmount = 0;
    private static List<Order> orders;
    private static List<Order> repairOrders; // Список замовлень на ремонт
    private static List<Order> installOrders; // Список замовлень на встановлення
    private static List<Client> clients; // Список клієнтів
    private static List<Specialist> specialists; // Список майстрів?

    // Композиція
    public Specialist AssignedSpecialist { get; set; } // Призначений майстер
    public Client ClientInfo { get; set; } // Інформація про клієнта (зокрема адреса)

    public Order(Specialist spec, Client client) // Конструктор
    {
        if (spec.IsFree)
        {
            AssignedSpecialist = spec;
        }
        else
        {
            throw new Exception("Specialist is not free now.");
        }
        ClientInfo = client;
        Address = ClientInfo.Address;
        Console.Write("Service type: "); ServiceType = Console.ReadLine();
        if (ServiceType == "Install")
        {
            installOrders.Add(this);
        }
        else if (ServiceType == "Repair")
        {
            repairOrders.Add(this);
        }
        Console.Write("Device name: "); DeviceName = Console.ReadLine();
        Console.Write("Device vendor: "); DeviceVendor = Console.ReadLine();
        Console.Write("Date of start: "); DateOfStart = Console.ReadLine();
        Console.Write("Work period: "); WorkPeriod = Console.ReadLine();
        Console.Write("Cost: "); Cost = Double.Parse(Console.ReadLine());
        OrderID = "ORD" + ++orderAmount;
        client.OrderID = client.OrderID + ", " + OrderID;
        spec.IsFree = false;

        orders.Add(this);
    }


    public double GetAverageOrderCost() // 4. Середня вартість замовлення
    {
        return orders.Average(o => o.Cost);
    }

    public string GetLongestWorkPeriod() // Найдовший термін виконання роботи
    {
        return orders.OrderByDescending(o => DateTime.Parse(o.WorkPeriod)).First().WorkPeriod;
    }

    public Order GetMostExpensiveOrder() // Найдорожче замовлення
    {
        return orders.OrderByDescending(o => o.Cost).First();
    }

    // Додайте інші методи та логіку для збереження і обробки даних.

    // Конструктор і методи для завантаження / збереження даних в файли або базу даних.
}