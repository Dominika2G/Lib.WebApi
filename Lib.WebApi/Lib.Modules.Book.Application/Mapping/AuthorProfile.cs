using AutoMapper;
using Lib.Modules.Book.Domain.Dto.Book;
using Lib.Shared.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Application.Mapping;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<Author, AuthorsResponseDto>()
            .ForMember(author => author.FirstName,
                opt => opt.MapFrom(x => x.FirstName))
            .ForMember(author => author.LastName,
                opt => opt.MapFrom(x => x.LastName));
    }
}
