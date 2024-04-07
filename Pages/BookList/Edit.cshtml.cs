using AppWeb1.Data;
using AppWeb1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AppWeb1.Pages.BookList
{

    public class EditModel : PageModel
    {

        private readonly AppWeb1Context _db;
        public EditModel(AppWeb1Context db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int id) {
            Book= await _db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
               var BookFromDb = await _db.Book.FindAsync(Book.Id); 
                BookFromDb.Name = Book.Name;
                BookFromDb.ISBN = Book.ISBN;
                BookFromDb.Author = Book.Author;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }


            return RedirectToPage();
            
        }
    }
}