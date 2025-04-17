namespace Task_2.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDat { get; set; }
        public decimal TotalAmount { get; set; }  



        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<OrderItem> orderItems { get; set; }

    }
}
