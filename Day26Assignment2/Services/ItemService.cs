namespace Day26Assignment2.Services
{
    public class ItemService
    {
        private readonly List<string> _items = new();

        public List<string> GetItems() => _items;

        public void AddItem(string item) => _items.Add(item);
    }
}
