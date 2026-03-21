using System;
using System.Collections.Generic;
using System.Text;

namespace MyBlog.Domain
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; }
        protected BaseEntity(Guid id)
        {
            Id = id;
        }

        protected BaseEntity() { }
    }
}
