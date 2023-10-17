using System.Text;

namespace Course_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            //       Запити до системи.
            // 1.Список пристроїв для ремонту.
            // 2.Список пристроїв для встановлення.
            // 3.Список клієнтів, які вибрали певний тип послуги.
            // 4.Середня вартість замовлення.
            // 5.Найбільший термін виконання роботи.
            // 6.Пристрій, який має найбільшу вартість.


            Specialist spec = new Specialist("Жмишенко Михайло Петрович", "+38001", "Енергогаз Україна");
            spec.Presentation();
            Client client = new Client("Малевіч Адам Кропивницький", "+38002", "Zabuvko 10");

            Order order = new Order(spec, client);

            Console.WriteLine();
            Specialist spec2 = new Specialist();
            Client client2 = new Client();
            Order order2 = new Order(spec2, client2);

            Console.WriteLine();
            Order.ShowRepairOrdersList(); // 1.
            Order.ShowInstallOrdersList(); // 2.
            Order.ShowClientsByServiceTypeList("Встановлення"); // 3.
            Console.WriteLine(Order.GetAverageOrderCost()); // 4.
            Console.WriteLine(Order.GetLongestWorkPeriod()); // 5.
            Order.GetMostExpensiveOrder().Show(); // 6.


        }
    }
}
