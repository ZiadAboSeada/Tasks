namespace Task_2.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public decimal price { get; set; }   


        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<OrderItem> orderItems { get; set; } 



    }
}
