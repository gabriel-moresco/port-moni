namespace PortMoni.MODEL
{
    public class Asset
    {
        public Share ReferencedShare { get; set; }
        public int Quantity { get; set; }
        public double TotalValue
        {
            get
            {
                return Quantity * ReferencedShare.CurrentQuote;
            }
        }
    }
}
