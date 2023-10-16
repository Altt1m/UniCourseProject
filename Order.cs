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
        if (spec.IsFree) // Якщо майстер вільний
        {
            AssignedSpecialist = spec; // ...то він і назначається
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
        Console.Write("Строк роботи: "); WorkPeriod = Console.ReadLine();
        Console.Write("Вартість: "); Cost = Double.Parse(Console.ReadLine());
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