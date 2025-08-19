using Day26Assignment2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Day26Assignment2.Pages.Items
{
    public class ListModel : PageModel
    {
        private readonly ItemService _service;
        public List<string> Items { get; set; }

        public ListModel(ItemService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            Items = _service.GetItems();
        }
    }
}
