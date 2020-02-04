using System.Collections.Generic;
using System.Linq;

namespace PortMoni.MODEL
{
    public class Wallet
    {
        public int Id { get; set; }
        public List<Operation> Operations { get; set; }
        public List<Asset> Assets { get; private set; }

        public double TotalInvestment()
        {
            return Assets.Select(o => o.TotalValue).Sum();
        }

        public Wallet()
        {
            Operations = new List<Operation>();
            Assets = new List<Asset>();
        }

        void PopulateAssets()
        {
            //TODO
            foreach (Operation operation in Operations)
            {
                if (Assets.Any(o => o.ReferencedShare.Code == operation.ShareCode))
                {

                }
                else
                {

                }
            }
        }
    }
}
