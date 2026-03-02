using CetStudentBook.Data;
using CetStudentBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace CetStudentBook.Controllers;

public class BooksController : Controller

{
    private readonly ApplicationDbContext _context;
    
    public BooksController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        var books = _context.Books.ToList();
        return View(books);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Book book)
    {
        if (ModelState.IsValid)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(book);
    }

    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var book = _context.Books.Find(id);
        if (book == null)
        {
            return NotFound();
        }
        return View(book);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Book book)
    {
        if (id != book.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(book);
    }

    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var book = _context.Books.Find(id);
        if (book == null)
        {
            return NotFound();
        }
        return View(book);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var book = _context.Books.Find(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
    
}
