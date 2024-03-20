using BookWebApi.Models.Dtos.RequestDto;
using BookWebApi.Models.Entities;
using BookWebApi.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _service;

    public AuthorsController(IAuthorService service)
    {
        _service = service;
    }
    [HttpPost("add")]
    public IActionResult Add([FromBody]AuthorAddRequestDto dto)
    {
        _service.Add(dto);
        return Ok(dto);

    }
    [HttpGet("getall")]
    public IActionResult GetAll() 
    {
        List<Author> authots = _service.GetAll();
        return Ok(authots);
    }

    [HttpGet("getbyid")]
    public IActionResult Get([FromQuery] int id) 
    {
        Author author = _service.GetById(id);
        return Ok(author);
    }




}
