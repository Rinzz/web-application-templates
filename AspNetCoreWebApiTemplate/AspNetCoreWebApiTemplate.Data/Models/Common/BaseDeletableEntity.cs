namespace AspNetCoreWebApiTemplate.Data.Models.Common
{
    using System;

    public abstract class BaseDeletableEntity<TKey> : BaseEntity<TKey>, IDeletableEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
