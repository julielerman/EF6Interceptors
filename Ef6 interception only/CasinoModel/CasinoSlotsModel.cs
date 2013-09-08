using System;
using System.Data.Entity;
using DomainClasses;


namespace DataLayer
{

  
  public class CasinoSlotsModel : DbContext
  {
    public CasinoSlotsModel()
    {
      
    }

      public CasinoSlotsModel(string connectionStringName):base(connectionStringName)
      {
            
      }
    public DbSet<Casino> Casinos { get; set; }
    public DbSet<SlotMachine> SlotMachines { get; set; }
    public DbSet<PokerTable> PokerTables { get; set; }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.HasDefaultSchema("Casino");
      base.OnModelCreating(modelBuilder);
    }
  }

  public class MyInitializer : DropCreateDatabaseAlways<CasinoSlotsModel>
  {
      protected override void Seed(CasinoSlotsModel context)
      {
          var casino = new Casino { Description = "Bets are on!", Name = "Gamble It Away", Rating = CasinoRating.Nice };
          casino.SlotMachines.Add(new SlotMachine { DateInService = DateTime.Now, SerialNumber = "123456", SlotMachineType = SlotMachineType.BuyAPay });
          context.Casinos.Add(casino);
          var casino2 = new Casino { Description = "We are shiny!", Name = "Harrahs", Rating = CasinoRating.JustLikeonTv };
          casino.SlotMachines.Add(new SlotMachine { DateInService = DateTime.Now, SerialNumber = "654321", SlotMachineType = SlotMachineType.BuyAPay });
          context.Casinos.Add(casino2);
          base.Seed(context);
      }
  }
}
