namespace AspNetCoreWebApiTemplate.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    
    using System;

    public class AppRole : IdentityRole
    {
        public AppRole() : this(null)
        { }

        public AppRole(string name) : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
