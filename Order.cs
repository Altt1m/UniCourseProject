public class Order // Замовлення на ремонт та встановлення
{
    public string Address { get; set; }
    public string ServiceType { get; set; } // Тип послуги (Встановлення/Ремонт)
    public string DeviceName { get; set; } // Назва пристрою (для встановлення/ремонту)
    public string DeviceVendor { get; set; } // Виробник пристрою
    public string DateOfStart { get; set; } // Дата початку роботи
    public int WorkPeriod { get; set; } // Термін роботи (у днях)
    public double Cost { get; set; } // Вартість
    public string OrderID { get; set; } // ID замовлення *(у клієнта)

    private static int orderAmount = 0;
    private static List<Order> orders = new List<Order>();
    private static List<Order> repairOrders = new List<Order>(); // Список замовлень на ремонт
    private static List<Order> installOrders = new List<Order>(); // Список замовлень на встановлення
    private static List<Specialist> specialists = new List<Specialist>(); // Список майстрів

    // Композиція
    public Specialist AssignedSpecialist { get; set; } // Призначений майстер
    public Client ClientInfo { get; set; } // Інформація про клієнта (зокрема адреса)

    public Order(Specialist spec, Client client) // Конструктор
    {
        if (spec.IsFree) // Якщо майстер вільний
        {
            AssignedSpecialist = spec; // ...то він і назначається
            specialists.Add(spec);
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
        client.OrderID = client.OrderID + ", " + OrderID;
        spec.IsFree = false;

        orders.Add(this);
    }


    public static double GetAverageOrderCost() // 4. Середня вартість замовлення
    {
        return orders.Average(o => o.Cost);
    }

    public static int GetLongestWorkPeriod() // 5. Найдовший термін виконання роботи
    {
        return orders.OrderByDescending(o => o.WorkPeriod).First().WorkPeriod;
    }

    public static Order GetMostExpensiveOrder() // 6. Найдорожче замовлення
    {
        return orders.OrderByDescending(o => o.Cost).First();
    }

    public void Show()
    {
        Console.WriteLine($"\nАдреса: {this.Address}\n" +
                        $"Вид послуги: {this.ServiceType}\n" +
                        $"Назва прибору: {this.DeviceName}\n" +
                        $"Виробник прибору: {this.DeviceVendor}\n" +
                        $"Дата початку: {this.DateOfStart}\n" +
                        $"Строк роботи: {this.WorkPeriod}\n" +
                        $"Вартість: {this.Cost}\n" +
                        $"ID: {this.OrderID}\n"); 
    }

    // Додайте інші методи та логіку для збереження і обробки даних.

    // Конструктор і методи для завантаження / збереження даних в файли або базу даних.
}