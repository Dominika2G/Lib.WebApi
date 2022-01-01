using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Lib.Modules.Book.Application.Queries;
using Lib.Modules.Book.Domain.Dto.Book;
using Lib.Shared.Data.Entities;

namespace Lib.Modules.Book.Application.Mapping;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<BookView, BookDetailsDto>()
            .ForMember(book => book.BookId,
                opt => opt.MapFrom(x => x.BookId))
            .ForMember(book => book.Title,
                opt => opt.MapFrom(x => x.Title))
            .ForMember(book => book.AuthorFirstName,
                opt => opt.MapFrom(x => x.FirstName))
            .ForMember(book => book.AuthorLastName,
                opt => opt.MapFrom(x => x.LastName))
            .ForMember(book => book.IsAvailable,
                opt => opt.MapFrom(x => x.IsAvailable))
            .ForMember(book => book.IsReserved,
                opt => opt.MapFrom(x => x.IsReserved))
            .ForMember(book => book.Cover, 
                opt => opt.MapFrom(x => x.Cover));

        CreateMap<BookView, BookDetailResponseDto>()
            .ForMember(book => book.Title,
                opt => opt.MapFrom(x => x.Title))
            .ForMember(book => book.Description,
                opt => opt.MapFrom(x => x.Description))
            .ForMember(book => book.IsAvailable,
                opt => opt.MapFrom(x => x.IsAvailable))
            .ForMember(book => book.IsReserved,
                opt => opt.MapFrom(x => x.IsReserved))
            .ForMember(book => book.AuthorFirstName,
                opt => opt.MapFrom(x => x.FirstName))
            .ForMember(book => book.AuthorLastName,
                opt => opt.MapFrom(x => x.LastName))
            .ForMember(book => book.BookId,
                opt => opt.MapFrom(x => x.BookId));

        /*CreateMap<Borrow, GetUsersBookResponseDto>()
            .ForMember(borrow => borrow.BookId,
                opt => opt.MapFrom(x => x.BookId));*/

        CreateMap<BorrowView, GetUsersBookResponseDto>()
            .ForMember(borrow => borrow.BookId,
                opt => opt.MapFrom(x => x.BookId))
            .ForMember(borrow => borrow.Title,
                opt => opt.MapFrom(x => x.Title))
            .ForMember(borrow => borrow.AuthorFirstName,
                opt => opt.MapFrom(x => x.FirstName))
            .ForMember(borrow => borrow.AuthorLastName,
                opt => opt.MapFrom(x => x.LastName))
            .ForMember(borrow => borrow.Email,
                opt => opt.MapFrom(x => x.Email))
            .ForMember(borrow => borrow.UserId,
                opt => opt.MapFrom(x => x.UserId))
            .ForMember(borrow => borrow.IsAvailable,
                opt => opt.MapFrom(x => x.IsAvailable))
            .ForMember(borrow => borrow.IsReserved,
                opt => opt.MapFrom(x => x.IsReserved))
            .ForMember(borrow => borrow.LoanDate,
                opt => opt.MapFrom(x => x.LoanDate))
            .ForMember(borrow => borrow.ReturnDate,
                opt => opt.MapFrom(x => x.ReturnDate))
            .ForMember(borrow => borrow.RentalPeriod,
                opt => opt.MapFrom(x => x.RentalPeriod))
            .ForMember(borrow => borrow.Description,
                opt => opt.MapFrom(x => x.Description));

    }
}
