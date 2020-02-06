using PortMoni.MVVM;

namespace PortMoni.MODEL
{
    public class Asset : ObjectNotification
    {
        Share _referencedShare; public Share ReferencedShare { get { return _referencedShare; } set { _referencedShare = value; OnPropertyChanged(); } }
        int _quantity; public int Quantity { get { return _quantity; } set { _quantity = value; OnPropertyChanged(); } }
        double _profitability; public double Profitability { get { return _profitability; } set { _profitability = value; OnPropertyChanged(); } }


        public double TotalValue
        {
            get
            {
                return Quantity * ReferencedShare.CurrentQuote;
            }
        }

        public Asset(Share referencedShare, int quantity)
        {
            ReferencedShare = referencedShare;
            Quantity = quantity;
        }
    }
}
