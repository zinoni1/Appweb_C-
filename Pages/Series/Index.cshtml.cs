using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppWeb1.Data;
using AppWeb1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppWeb1.Pages.Series
{
    public class IndexModel : PageModel
    {
        private readonly AppWeb1.Data.AppWeb1Context _context;

        public IndexModel(AppWeb1.Data.AppWeb1Context context)
        {
            _context = context;
        }

        public IList<Serie> Serie { get;set; }
        [BindProperty(SupportsGet = true)]

        public string SearchString { get; set; }

        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]

        public string MovieGenre { get; set; }
        public async Task OnGetAsync()
        {
            if (_context.Serie != null)
            {
                Serie = await _context.Serie.ToListAsync();
            }
        }
    }
}
