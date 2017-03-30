using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Models;

namespace TeamBuilder.Data.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
       public UserConfiguration()
        {
            this.Property(u => u.Username).IsRequired();
            this.Property(u => u.Password).IsRequired();

            this.Property(u => u.Username)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                new IndexAnnotation(
                    new IndexAttribute("IX_Users_Username", 1) { IsUnique = true }))
                    .HasMaxLength(25);

            this.Property(u => u.FirstName)
                .HasMaxLength(25);

            this.Property(u => u.LastName)
                .HasMaxLength(25);

            this.Property(u => u.Password)
                .HasMaxLength(30)
                .IsRequired();


            this.HasMany(u => u.CreatedTeams)
                .WithRequired(t => t.Creator)
                .WillCascadeOnDelete(false);

            this.HasMany(u => u.CreatedEvents)
                .WithRequired(e => e.Creator)
                .WillCascadeOnDelete(false);

            this.HasMany(u => u.Teams)
                .WithMany(t => t.Members)
                .Map(
                ca =>
                    {
                        ca.MapLeftKey("UserId");
                        ca.MapRightKey("TeamId");
                        ca.ToTable("UserTeams");
                    });

            this.HasMany(u => u.ReceivedInvitations)
                .WithRequired(i => i.InvitedUser)
                .WillCascadeOnDelete(false);
        }
    }
}
