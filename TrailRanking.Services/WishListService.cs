using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailRanking.Data;
using TrailRanking.Models;

namespace TrailRanking.Services
{
    public class WishListService
    {
        private readonly Guid _userId;
        public WishListService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateWishList(WishListCreate model)
        {
            var entity =
                new WishList()
                {
                    OwnerId = _userId,
                    TrailId = model.TrailId,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.WishLists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<WishListItem> GetWishLists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.WishLists
                    .Select(
                        e =>
                        new WishListItem
                        {
                            WishListId = e.WishListId,
                            TrailId = e.TrailId,
                            TrailName = e.Trail.TrailName,
                            CreatedUtc = e.CreatedUtc
                        }
                  );
                return query.ToArray();
            }
        }
        public WishListDetail GetWishListById(int wishListId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                     ctx
                         .WishLists
                         .Single(e => e.WishListId == wishListId && e.OwnerId == _userId);
                return
                    new WishListDetail
                    {
                        WishListId = entity.WishListId,
                        TrailId = entity.TrailId,
                        TrailName = entity.Trail.TrailName,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool UpdateWishList(WishListEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                            ctx
                                .WishLists
                                .Single(e => e.WishListId == model.WishListId && e.OwnerId == _userId);
                entity.TrailId = model.TrailId;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteWishList(int wishListId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .WishLists
                        .Single(e => e.WishListId == wishListId && e.OwnerId == _userId);
                ctx.WishLists.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
