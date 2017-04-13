namespace KamikazeVTPRO.Data.Migrations
{
    public class DbFactory : Disposable, IDbFactory
    {
        private KamikazeVTPRODbContext dbContext;

        public KamikazeVTPRODbContext Init()
        {
            return dbContext ?? (dbContext = new KamikazeVTPRODbContext());
        }

        protected override void DisposeCore()
        {
           if(dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}