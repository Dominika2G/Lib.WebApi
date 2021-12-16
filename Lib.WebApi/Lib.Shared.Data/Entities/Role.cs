// <auto-generated>
// ReSharper disable All

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Lib.Shared.Data.Entities
{
    // Role
    public class Role
    {
        public long RoleId { get; set; } // RoleId (Primary key)
        public string RoleName { get; set; } // RoleName (length: 50)

        // Reverse navigation

        /// <summary>
        /// Child Users where [User].[RoleId] point to this entity (FK_User_Role)
        /// </summary>
        public virtual ICollection<User> Users { get; set; } // User.FK_User_Role

        public Role()
        {
            Users = new List<User>();
        }
    }

}
// </auto-generated>
