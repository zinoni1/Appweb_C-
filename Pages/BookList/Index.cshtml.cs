using AppWeb1.Data;
using AppWeb1.Migrations;
using AppWeb1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AppWeb1.Pages.BookList
{
    public class IndexModel : PageModel
    {

        private readonly  AppWeb1Context _db;

        public IndexModel(AppWeb1Context db)
        {
            _db = db;
        }

        public IEnumerable<Book> Books { get; set; }

        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        { 
            var book = await _db.Book.FindAsync(id);
        if (book == null)
            {
                return NotFound(); }
    
        _db.Book.Remove(book);
         await _db.SaveChangesAsync();
         return RedirectToPage("Index");
         }

}

}
