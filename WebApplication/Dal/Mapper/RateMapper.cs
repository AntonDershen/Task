using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;
using DataAccess.Interface.DataTransfer;
namespace DataAccess.Mapper
{
    public static class RateMapper
    {
        public static double CalculateRate(ICollection<Rate> rates)
        {
            double calculateRate = 0;
            foreach (var rate in rates)
                calculateRate += rate.Rating;
            return calculateRate /= rates.Count;
        }
    }
}
