using AutoMapper;
using Lib.Modules.Book.Domain.Dto.Book;
using Lib.Shared.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Book.Application.Mapping;

public class CommentProfile: Profile
{
    public CommentProfile()
    {
        CreateMap<CommentsView, CommentDto>()
            .ForMember(comment => comment.AddingDate,
                opt => opt.MapFrom(x => x.AddingDate))
            .ForMember(comment => comment.Description,
                opt => opt.MapFrom(x => x.Description))
            .ForMember(comment => comment.Email,
                opt => opt.MapFrom(x => x.Email))
            .ForMember(comment => comment.Rating,
                opt => opt.MapFrom(x => x.Rating));
    }
}
