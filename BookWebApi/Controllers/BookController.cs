using BookWebApi.Models.Dtos.RequestDto;
using BookWebApi.Models.Dtos.ResponseDto;
using BookWebApi.Models.Entities;
using BookWebApi.Service.Interfaces;
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
    private readonly IBookService _service;

    public BookController(IBookService service)
    {
        _service = service;
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        List<Book> books = _service.GetAll();
        return Ok(books);

    }

    [HttpGet("getbyid")]
    public IActionResult GetById(int id)
    {
        Book book = _service.GetById(id);
        return Ok(book);
    }

    [HttpPut]
    public IActionResult Update([FromBody] BookUpdateRequestDto dto)
    {
        _service.Update(dto);
        return Ok("Güncelleme başarılı.");

    }

    [HttpPost("add")]
    public IActionResult Add([FromBody] BookAddRequestDto dto) 
    {
        _service.Add(dto);
        return Ok("Ekleme başarılı");
    }
    [HttpDelete("delete")]
    public IActionResult DeleteById([FromQuery]int id) 
    {
        _service.Delete(id);
        return Ok("Silme başarılı");
    }
    [HttpGet("getalldetails")]
    public IActionResult GetAllDetails()
    {
        List<BookResponseDto> result = _service.GetAllDetails();
        return Ok(result);
    }







}




