using System;
using System.Collections.Generic;


namespace DomainClasses
{
    public class Casino
    {
        public Casino()
        {
            SlotMachines = new List<SlotMachine>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public CasinoRating Rating { get; set; }
        public String Description { get; set; }
        public ICollection<SlotMachine> SlotMachines { get; set; }
       
    }

    public enum CasinoRating
    {
        Meh = 1,
        Nice = 2,
        JustLikeonTv = 3
    }
}
