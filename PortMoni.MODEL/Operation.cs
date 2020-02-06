using PortMoni.UTIL;
using System;

namespace PortMoni.MODEL
{
    public class Operation
    {
        public string ShareCode { get; set; }
        public Constants.OperationType Type { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public double Taxes { get; set; }

        public Operation(string shareCode, Constants.OperationType type, int quantity, double price, DateTime date, double taxes)
        {
            ShareCode = shareCode;
            Type = type;
            Quantity = quantity;
            Price = price;
            Date = date;
            Taxes = taxes;
        }
    }
}
