using System;

namespace KamikazeVTPRO.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        KamikazeVTPRODbContext Init();
    }
}