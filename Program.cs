using Deliver.Entities;
using Deliver.Entities.Enums;

Console.WriteLine("Enter client data:");
Console.Write("Name: ");
string name = Console.ReadLine();
Console.Write("Email: ");
string email = Console.ReadLine();
Console.Write("Birth Date (DD/MM/YYYY): ");
DateTime birthdate =  DateTime.Parse(Console.ReadLine());

Client client = new Client(name, email, birthdate);

Console.WriteLine("Enter order data:");
Console.Write("Status: ");
OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

DateTime orderDate = DateTime.Now;

Order order = new Order(orderDate, status, client);

Console.Write("How many items to this order? ");
int nItems = int.Parse(Console.ReadLine());


for (int i = 1; i <= nItems; i++)
{
    Console.WriteLine($"Enter #{i} item data:");
    Console.Write("Product name: ");
    string productName = Console.ReadLine();
    Console.Write("Product price: ");
    double price = double.Parse(Console.ReadLine());
    Console.Write("Quantity: ");
    int quantity = int.Parse(Console.ReadLine());

    Product product = new Product(productName, price);

    OrderItem  item = new OrderItem(quantity, price, product);

    order.AddItem(item);
}

Console.WriteLine(order);
