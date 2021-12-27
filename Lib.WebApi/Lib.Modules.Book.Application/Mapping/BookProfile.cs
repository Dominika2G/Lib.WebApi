using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lib.Modules.Book.Application.Dtos;
using Lib.Shared.Data.Entities;

namespace Lib.Modules.Book.Application.Mapping;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Lib.Shared.Data.Entities.Book, BookDetailsDto>()
            .ForMember(book => book.BookId,
                opt => opt.MapFrom(x => x.BookId))
            .ForMember(book => book.Title,
                opt => opt.MapFrom(x => x.Title))
            .ForMember(book => book.AuthorFirstName,
                opt => opt.MapFrom(x => x.Author.FirstName))
            .ForMember(book => book.AuthorLastName,
                opt => opt.MapFrom(x => x.Author.LastName))
            .ForMember(book => book.IsAvailable,
                opt => opt.MapFrom(x => x.IsAvailable));
    }
}
