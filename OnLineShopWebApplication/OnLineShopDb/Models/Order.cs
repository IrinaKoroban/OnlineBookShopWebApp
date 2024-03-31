namespace OnLineShop.Db.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public UserDeliveryData userDeliveryData { get; set; }
        //public string UserId { get; set; }
        public string userEmail { get; set; }
        public List<CartItem> Items { get; set; }
        public DateTime CreateDateTime { get; set; }
        public OrderStatus Status { get; set; }

        public Order()
        {
            //Items = new List<CartItem>();
            CreateDateTime = DateTime.Now;
            Status = OrderStatus.Created;
        }
    }
}
