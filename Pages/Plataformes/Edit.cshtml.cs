using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppWeb1.Data;
using AppWeb1.Models;

namespace AppWeb1.Pages.Plataformes
{
    public class EditModel : PageModel
    {
        private readonly AppWeb1.Data.AppWeb1Context _context;

        public EditModel(AppWeb1.Data.AppWeb1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Plataforma Plataforma { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Plataforma == null)
            {
                return NotFound();
            }

            var plataforma =  await _context.Plataforma.FirstOrDefaultAsync(m => m.Id == id);
            if (plataforma == null)
            {
                return NotFound();
            }
            Plataforma = plataforma;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Plataforma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlataformaExists(Plataforma.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PlataformaExists(int id)
        {
          return (_context.Plataforma?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
