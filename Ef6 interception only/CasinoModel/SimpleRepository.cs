using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using DomainClasses;
using System.Data.Entity;

namespace CasinoSolution.Repository
{
    public class SimpleRepository
    {
        private readonly CasinoSlotsModel _context;

        public SimpleRepository()
        {
            _context=new CasinoSlotsModel();
        }

        public SimpleRepository(string connectionStringName)
        {
            _context = new CasinoSlotsModel(connectionStringName);
        }
        public List<Casino> GetAllCasinos()
        {
            
                return _context.Casinos.ToList();
           
        }

       
        public async Task<List<Casino>> GetAllCasinosAsync()
        {
               return await _context.Casinos.ToListAsync();
         }
        public Casino GetCasinoNotAsync(int id)
        {
                return _context.Casinos.Find(id);

        }
        public async Task<Casino> GetCasinoAsync(int id)
        {
   
                return await _context.Casinos.FindAsync(id);
        }
        public CasinoRating IncrementCasinoRating(int id)
        {

    var casino =  _context.Casinos.Find(id);
                UpdateRating(casino);
                _context.SaveChanges();
                return casino.Rating;
  }
        public async Task<CasinoRating> IncrementCasinoRatingAsync(int id)
        {

          
               var casino=await _context.Casinos.FindAsync(id);
                //rest is delayed until awaited query has received results
                UpdateRating(casino);
                await _context.SaveChangesAsync();
                //  Method completion is delayed until awaited SaveChanges has received results
                return casino.Rating;
           
        }

        private  void UpdateRating(Casino casino)
        {
            switch (casino.Rating)
            {
                case CasinoRating.Meh:
                    casino.Rating = CasinoRating.Nice;
                    break;
                case CasinoRating.Nice:
                    casino.Rating = CasinoRating.JustLikeonTv;
                    break;
                case CasinoRating.JustLikeonTv:
                    casino.Rating = CasinoRating.Meh;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public List<Casino> FindCasinosByRatingFromArray(CasinoRating[] r)
        {
          
  
                _context.Database.Log = Console.Write;
                return _context.Casinos.Where(c => r.Contains(c.Rating)).ToList();
              
        }
    }
}
