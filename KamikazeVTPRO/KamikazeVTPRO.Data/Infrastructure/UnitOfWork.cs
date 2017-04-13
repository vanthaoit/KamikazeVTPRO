using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamikazeVTPRO.Data.Migrations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private KamikazeVTPRODbContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public KamikazeVTPRODbContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        } 

        public void Commit()
        {
            dbContext.SaveChanges();
        }
    }
}
