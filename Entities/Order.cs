using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deliver.Entities.Enums;

namespace Deliver.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Clt { get; set; }
        public List<OrderItem> Items { get; private set; } = new List<OrderItem>();

        public Order() 
        { 
        }

        public Order(DateTime moment, OrderStatus status, Client clt)
        {
            Moment = moment;
            Status = status;
            Clt = clt;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double sum = 0;
            foreach (OrderItem item in Items)
            {
                sum += item.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY");
            sb.Append("Order Moment: ");
            sb.AppendLine(Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Order status: ");
            sb.AppendLine(Status.ToString());
            sb.AppendLine($"Client: {Clt}");
            sb.AppendLine("Order items: ");
            foreach(OrderItem item in Items)
            {
                sb.AppendLine($"{item.Product}, ${item.Price}, Quantity: {item.Quantity}, Subtotal: ${item.SubTotal()}");
            }
            sb.AppendLine($"Total price: ${Total()}");

            return sb.ToString();
        }
    }
}
