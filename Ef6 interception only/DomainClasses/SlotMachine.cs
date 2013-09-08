using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainClasses
{
    public class SlotMachine
    {
        public int Id { get; set; }
        public SlotMachineType SlotMachineType { get; set; }
        public string SerialNumber { get; set; }
        public Casino Casino { get; set; }
        public int HotelId { get; set; }
        public DateTime DateInService { get; set; }
        public bool HasQuietMode { get; set; }
      //public string SomeNewProp { get; set; }
      //public string AnotherNewProp { get; set; }
    }

    public enum SlotMachineType
    {
        Straight = 1,
        Progressive = 2,
        Wildcard = 3,
        Multipliers = 4,
        BonusMultipliers = 5,
        BuyAPay = 6
    }
}
