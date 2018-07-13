using BitEng.Security.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BitEng.Security
{
    public class BitSecurityContext : IdentityDbContext<BitUser, BitRole, Guid, BitUserLogin, BitUserRole, BitUserClaim>
    {
        public static BitSecurityContext Create(string connection) {
            return new BitSecurityContext(connection);
        }
        public BitSecurityContext(string connection) : base(connection){

        }
        public BitSecurityContext() : base("SecurityConnection"){
            
        }

        public virtual DbSet<BitPermission> Permissions { get; set; }
        public virtual DbSet<BitRolePermission> RolePermissions { get; set; }
        public virtual DbSet<BitUserRole> UserRoles { get; set; }
        public virtual DbSet<BitMenuItem> MenuItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            var users = modelBuilder.Entity<BitUser>();
            users.ToTable("BitUsers");
            users.HasKey(x => x.Id);
            users.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            var roles = modelBuilder.Entity<BitRole>();
            roles.ToTable("BitRoles");
            roles.HasKey(x => x.Id);
            roles.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            var permission = modelBuilder.Entity<BitPermission>();
            permission.ToTable("BitPermissions");
            permission.HasKey(x => x.Key);

            var rolePermission = modelBuilder.Entity<BitRolePermission>();
            rolePermission.ToTable("BitRolePermissions");
            rolePermission.HasKey(x => new { x.PermissionKey, x.RoleId });
            rolePermission.HasRequired(x => x.Permission).WithMany().HasForeignKey(x=>x.PermissionKey);
            rolePermission.HasRequired(x => x.Role).WithMany().HasForeignKey(x => x.RoleId);

            var userClaim = modelBuilder.Entity<BitUserClaim>();
            userClaim.ToTable("BitUserClaims");

            var userLogins = modelBuilder.Entity<BitUserLogin>();
            userLogins.ToTable("BitUserLogins");

            var userRoles = modelBuilder.Entity<BitUserRole>().ToTable("BitUserRole");
            userRoles.HasKey(x => new { x.RoleId, x.UserId });

            var menuItem = modelBuilder.Entity<BitMenuItem>();
            menuItem.ToTable("BitMenuItems").HasKey(x => x.Id);
            menuItem.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            menuItem.HasMany(x => x.Children).WithOptional(x => x.Parent).HasForeignKey(x => x.ParentId);
            menuItem.HasOptional(x => x.Permission).WithMany().HasForeignKey(x => x.PermissionKey);

        }
    }
}
