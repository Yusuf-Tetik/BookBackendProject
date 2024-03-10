using BookWebApi.Models.Entities;
using BookWebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookWebApi.Controllers;

// Okuma : HttpGet
// Silme : HttpDelete , HttpPost
// Ekle : HttpPost
// Güncelleme : HttpPost , HttpPatch , HttpPut

[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    BaseDbContext context = new BaseDbContext();


    [HttpPost("add")]
    public IActionResult Add([FromBody] Book book)
    {
        context.Books.Add(book);
        context.SaveChanges();

        return Ok("Ekleme başarılı.");
    }
    [HttpGet("getall")]
    public IActionResult GetAll() 
    {
        List<Book> books = context.Books.ToList();

        return Ok(books);
    }

    [HttpGet("getbyid")]
    public IActionResult GetById(int id) 
    {
        Book book = context.Books.Find(id);
        return Ok(book);
    }

    [HttpGet("getbystockrange")]
    public IActionResult GetByStockRange([FromQuery]int min,[FromQuery]int max)
    {
        List<Book> books=context.Books.Where(x=> x.Stock<max && x.Stock>min).ToList();

        return Ok(books);
    }

    [HttpGet("getbypricerange")]

    public IActionResult GetByPriceRange([FromQuery] double min, [FromQuery] double max)
    {
        List<Book> books = context.Books.Where(x => x.Price <= max && x.Price >= min).ToList();
        
        return Ok(books);
    }


}
