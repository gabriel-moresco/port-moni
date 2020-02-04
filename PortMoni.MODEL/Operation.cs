using PortMoni.UTIL;
using System;

namespace PortMoni.MODEL
{
    public class Operation
    {
        public string ShareCode { get; set; }
        public Constants.OperationType Type { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public double Taxes { get; set; }
    }
}
