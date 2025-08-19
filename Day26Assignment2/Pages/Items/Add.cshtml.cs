using Day26Assignment2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Day26Assignment2.Pages.Items
{
    public class AddModel : PageModel
    {
        private readonly ItemService _service;

        [BindProperty]
        public string NewItem { get; set; }

        public AddModel(ItemService service)
        {
            _service = service;
        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrWhiteSpace(NewItem))
            {
                _service.AddItem(NewItem);
            }
            return RedirectToPage("List");
        }
    }
}
