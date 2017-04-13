using System;

namespace KamikazeVTPRO.Data.Migrations
{
    public interface IDbFactory : IDisposable
    {
        KamikazeVTPRODbContext Init();
    }
}