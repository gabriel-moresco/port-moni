using System.Collections.Generic;

namespace PortMoni.MODEL
{
    public class Wallet
    {
        public int Id { get; set; }
        public List<Operation> Operations { get; set; }

        public Wallet()
        {
            Operations = new List<Operation>();
        }
    }
}
