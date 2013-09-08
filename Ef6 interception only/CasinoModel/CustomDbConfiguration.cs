using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DataLayer.CasinoModel
{
  public class CustomDbConfiguration : DbConfiguration
  {

    public CustomDbConfiguration()
    {
        SetDefaultConnectionFactory(new LocalDbConnectionFactory("v11.0"));
         AddInterceptor(new NLogEfCommandInterceptor());

    }
  }
}
