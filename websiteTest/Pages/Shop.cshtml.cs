using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace websiteTest.Pages
{
    public class ShopModel : PageModel
    {
        [BindProperty]
        public string NewItem { get; set; }
        public static List<string> ItemList { get; set; } = new();
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrWhiteSpace(NewItem))
            {
                ItemList.Add(NewItem);
                NewItem = string.Empty;
            }
            return Page();
        }

        public IActionResult OnPostRemove(int index)
        {
            if (index >= 0 && index < ItemList.Count)
            {
                ItemList.RemoveAt(index);
            }
            return RedirectToPage();
        }
    }
}
