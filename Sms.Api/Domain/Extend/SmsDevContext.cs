using Domain.Extend;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data
{
    public partial class SmsDevContext : DbContext
    {
        private IHttpContextAccessor _httpContextAccessor;
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            HandleAuditEntities();
            HandleAuditEntries();
            return await base.SaveChangesAsync(cancellationToken);
        }
        public override int SaveChanges()
        {
            HandleAuditEntities();
            HandleAuditEntries();
            return base.SaveChanges();
        }
        private void HandleAuditEntries()
        {
            var addedAuditedEntities = ChangeTracker.Entries<IAuditable>()
                .Where(p => p.State == EntityState.Added)
                .Select(p => p.Entity);

            var modifiedAuditedEntities = ChangeTracker.Entries<IAuditable>()
                .Where(p => p.State == EntityState.Modified)
                .Select(p => p.Entity);

            _httpContextAccessor ??= new HttpContextAccessor();

            var currentUserDetails = !string.IsNullOrEmpty(_httpContextAccessor.HttpContext?.User.FindFirst("UserId")?.Value) ? _httpContextAccessor.HttpContext?.User.FindFirst("UserId")?.Value : "1";
            int.TryParse(currentUserDetails, out var currentUser);
            //var userId = 1;

            var now = DateTime.UtcNow;
            foreach (var added in addedAuditedEntities)
            {
                added.Created = (DateTime.MinValue == added.Created) ? now : added.Created;
                added.Updated = now;
                added.CreatedBy = currentUser;
                added.UpdatedBy = currentUser;
            }

            foreach (var modified in modifiedAuditedEntities)
            {
                //if (modified.CreatedBy != 1 && modified.CreatedBy != currentUser)
                //{
                //    getUserAccess();

                //}   
                //open api
                modified.Updated = now;
                modified.UpdatedBy = currentUser;
            }
        }
        private void HandleAuditEntities()
        {
            _httpContextAccessor ??= new HttpContextAccessor();
            var currentUserDetails = !string.IsNullOrEmpty(_httpContextAccessor.HttpContext?.User.FindFirst("UserId")?.Value) ? _httpContextAccessor.HttpContext?.User.FindFirst("UserId")?.Value : "1";
            int.TryParse(currentUserDetails, out var currentUser);

            var modifiedAuditedEntities = ChangeTracker.Entries<IAuditable>()
                .Where(p => p.State == EntityState.Modified)
                .Select(p => p.Entity);

            //var isUnAuthorized = modifiedAuditedEntities.FirstOrDefault(x => x.CreatedBy != currentUser && x.CreatedBy != 1);
            //if (isUnAuthorized != null)
            //{
            //    getUserAccess();
            //}

            //var deletedAuditedEntities = ChangeTracker.Entries<IAuditable>()
            //  .Where(p => p.State == EntityState.Deleted)
            //  .Select(p => p.Entity);


        }
    }
}
