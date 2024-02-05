using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppWeb1.Data;
using AppWeb1.Models;

namespace AppWeb1.Pages.Plataformes
{
    public class IndexModel : PageModel
    {
        private readonly AppWeb1.Data.AppWeb1Context _context;

        public IndexModel(AppWeb1.Data.AppWeb1Context context)
        {
            _context = context;
        }

        public IList<Plataforma> Plataforma { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Plataforma != null)
            {
                Plataforma = await _context.Plataforma.ToListAsync();
            }
        }
    }
}
