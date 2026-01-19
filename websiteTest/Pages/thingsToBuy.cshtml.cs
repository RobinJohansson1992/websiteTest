using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace websiteTest.Pages
{
    public class BuyModel : PageModel
    {
        [BindProperty]
        public string NewItems { get; set; }
        public static List<string> ItemsList { get; set; } = new();
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrWhiteSpace(NewItems))
            {
                ItemsList.Add(NewItems);
                NewItems = string.Empty;
            }
            return RedirectToPage();
        }

        public IActionResult OnPostRemove(int index)
        {
            if (index >= 0 && index < ItemsList.Count)
            {
                ItemsList.RemoveAt(index);
            }
            return RedirectToPage();
        }
    }
}
