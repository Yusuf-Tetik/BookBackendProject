using BookWebApi.Models.Dtos.RequestDto;
using BookWebApi.Models.Entities;
using BookWebApi.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        List<Category> categories = _categoryService.GetAll();
        return Ok(categories);
    }
    [HttpGet("getbyid")]
    public IActionResult GetById([FromQuery] int id) 
    {   
        Category category = _categoryService.GetById(id);
        return Ok(category);
    }
    [HttpPost("add")]
    public IActionResult Add([FromBody]CategoryAddRequestDto dto)
    {
       _categoryService.Add(dto);
       return Ok(dto);
    }

}
