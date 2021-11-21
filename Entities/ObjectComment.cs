using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities
{
    public class ObjectComment : IEntity
    {
        public long ObjectRef { get; set; }
        public virtual Object ObjectTRef { get; set; }
        public int CommentRef { get; set; }
        public virtual Comment CommentTRef { get; set; }

        public bool IsActive { get; set; }
    }

    public class ObjectCommentConfiguration : IEntityTypeConfiguration<ObjectComment>
    {
        public void Configure(EntityTypeBuilder<ObjectComment> builder)
        {
            builder.HasKey(oc => new { oc.CommentRef, oc.ObjectRef });
        }
    }
}
