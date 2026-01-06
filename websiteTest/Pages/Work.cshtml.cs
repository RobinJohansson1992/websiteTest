using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace websiteTest.Pages
{
    public class ArbeteModel : PageModel
    {
        [BindProperty]
        public DateTime Datum { get; set; }

        [BindProperty]
        public TimeSpan StartTid { get; set; }

        [BindProperty]
        public TimeSpan SlutTid { get; set; }

        public static List<ArbetePost> Lista { get; set; } = new();

        public void OnGet()
        {
            Sortera();
        }

        public IActionResult OnPost()
        {
            if (StartTid < SlutTid)
            {
                Lista.Add(new ArbetePost
                {
                    Datum = Datum,
                    StartTid = StartTid,
                    SlutTid = SlutTid
                });
            }

            Sortera();
            return RedirectToPage();
        }

        public IActionResult OnPostTaBort(int index)
        {
            if (index >= 0 && index < Lista.Count)
            {
                Lista.RemoveAt(index);
            }

            Sortera();
            return RedirectToPage();
        }

        private void Sortera()
        {
            Lista = Lista
                .OrderBy(x => x.Datum.Add(x.StartTid))
                .ToList();
        }
    }

    public class ArbetePost
    {
        public DateTime Datum { get; set; }
        public TimeSpan StartTid { get; set; }
        public TimeSpan SlutTid { get; set; }
    }
}
