using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace websiteTest.Pages
{
    public class KomIhogModel : PageModel
    {
        [BindProperty]
        public DateTime Datum { get; set; }

        [BindProperty]
        public TimeSpan Tid { get; set; }

        [BindProperty]
        public string Handelse { get; set; }

        public static List<KomIhogPost> Lista { get; set; } = new();

        public void OnGet()
        {
            Lista = Lista
                .OrderBy(x => x.Datum.Add(x.Tid))
                .ToList();

        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrWhiteSpace(Handelse))
            {
                Lista.Add(new KomIhogPost
                {
                    Datum = Datum,
                    Tid = Tid,
                    Handelse = Handelse
                });

                Lista = Lista
    .OrderBy(x => x.Datum.Add(x.Tid))
    .ToList();
            }

            return RedirectToPage();
        }

        public IActionResult OnPostTaBort(int index)
        {
            if (index >= 0 && index < Lista.Count)
            {
                Lista.RemoveAt(index);
            }
            Lista = Lista
        .OrderBy(x => x.Datum.Add(x.Tid))
        .ToList();

            return RedirectToPage();
        }
    }

    public class KomIhogPost
    {
        public DateTime Datum { get; set; }
        public TimeSpan Tid { get; set; }
        public string Handelse { get; set; }
    }
}
