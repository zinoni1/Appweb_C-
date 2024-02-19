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

namespace AppWeb1.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly AppWeb1.Data.AppWeb1Context _context;

        public IndexModel(AppWeb1.Data.AppWeb1Context context)
        {
            _context = context;
        }

        public IList<Client> Client{ get; set; }
        [BindProperty(SupportsGet = true)]

        public string SearchString { get; set; }

        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]

        public string Nom { get; set; }
        public async Task OnGetAsync()
        {
            var clients = from m in _context.Client
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                clients = clients.Where(s => s.Nom.Contains(SearchString));
            }

            Client = await clients.ToListAsync();
        }
    }

}
