namespace Task_2.ViewModel
{
    public class OrderWithItemsProducts
    {
        public int OrderId { get; set; }
        public int OrderCustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderTotalAmount { get; set; }
        public int ItemId { get; set; }
        public int ItemQuantity { get; set; }
        public decimal ItemPrice { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductCategoryId { get; set; }
        public decimal ProductPrice { get; set; }

       
    }
}
