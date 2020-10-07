namespace Burak.Boilerplate.Models.Requests
{
    public class UserItemRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public bool IsEquipped { get; set; }
        public bool IsConsumed { get; set; }
        public int ItemLevel { get; set; }
        public int Quantity { get; set; }
    }
}