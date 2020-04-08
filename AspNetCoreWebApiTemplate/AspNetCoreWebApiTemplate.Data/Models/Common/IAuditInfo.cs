﻿namespace AspNetCoreWebApiTemplate.Data.Models.Common
{
    using System;

    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
