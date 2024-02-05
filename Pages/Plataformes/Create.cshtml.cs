using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppWeb1.Data;
using AppWeb1.Models;

namespace AppWeb1.Pages.Plataformes
{
    public class CreateModel : PageModel
    {
        private readonly AppWeb1.Data.AppWeb1Context _context;

        public CreateModel(AppWeb1.Data.AppWeb1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Plataforma Plataforma { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Plataforma == null || Plataforma == null)
            {
                return Page();
            }

            _context.Plataforma.Add(Plataforma);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
