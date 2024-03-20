using AutoMapper;
using BookWebApi.Models.Dtos.RequestDto;
using BookWebApi.Models.Dtos.ResponseDto;
using BookWebApi.Models.Entities;
using BookWebApi.Repository;
using BookWebApi.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BookWebApi.Service.Concrete;

public class BookService : IBookService
{
    private readonly BaseDbContext _context;

    private readonly IMapper _mapper;

    public BookService(BaseDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Add(BookAddRequestDto dto)
    {
        Book book = _mapper.Map<Book>(dto);
        _context.Books.Add(book);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        Book? book = _context.Books.Find(id);
        if (book == null)
        {
            throw new Exception($"id : {id} kitap bulunamadı.");
        }
        _context.Books.Remove(book);
        _context.SaveChanges();
    }

    public List<Book> GetAll()
    {
        List<Book> books = _context.Books.ToList();
        return books;
    }

    public List<BookResponseDto> GetAllDetails()
    {
        List<Book> books = _context.Books
            .Include(x=>x.Author)
            .Include(x=>x.Category)
            .ToList();
        List<BookResponseDto> responses = _mapper
            .Map<List<BookResponseDto>>(books);

        return responses;
    }

    public Book GetById(int id)
    {
        Book? book = _context.Books.Find(id);
        if (book == null)
        {
            throw new Exception($"id : {id} kitap bulunamadı.");
        }
        return book;
    }

    public void Update(BookUpdateRequestDto dto)
    {
        Book? book = _context.Books.Find(dto.Id);
        if (book == null)
        {
            throw new Exception($"id : {dto.Id} kitap bulunamadı.");
        }

        Book updateBook = _mapper.Map<Book>(dto);
        _context.Books.Update(updateBook);
        _context.SaveChanges();
    }

}
