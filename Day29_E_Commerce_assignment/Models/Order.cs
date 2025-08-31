namespace Day29_E_Commerce_assignment.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Item { get; set; } = "";
        public decimal Amount { get; set; }
    }
}
