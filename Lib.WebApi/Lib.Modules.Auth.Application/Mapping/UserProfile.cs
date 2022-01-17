using AutoMapper;
using Lib.Modules.Auth.Domain.Dtos.User;
using Lib.Shared.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Modules.Auth.Application.Mapping;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<UserView, UserDetailDto>()
            .ForMember(user => user.UserId,
                opt => opt.MapFrom(x => x.UserId))
            .ForMember(user => user.FirstName,
                opt => opt.MapFrom(x => x.FirstName))
            .ForMember(user => user.LastName,
                opt => opt.MapFrom(x => x.LastName))
            .ForMember(user => user.Email,
                opt => opt.MapFrom(x => x.Email))
            .ForMember(user => user.Class,
                opt => opt.MapFrom(x => x.Class))
            .ForMember(user => user.IsActive,
                opt => opt.MapFrom(x => x.IsActive))
            .ForMember(user => user.RoleName,
                opt => opt.MapFrom(x => x.RoleName));
    }
}
