using BookWebApi.Models.Dtos.RequestDto;
using BookWebApi.Models.Dtos.ResponseDto;
using BookWebApi.Models.Entities;

namespace BookWebApi.Service.Interfaces;

public interface IBookService
{
    List<Book> GetAll();
    Book GetById(int id);
    void Update(BookUpdateRequestDto dto);
    void Add(BookAddRequestDto dto);
    void Delete(int id);
    List<BookResponseDto> GetAllDetails();

}
