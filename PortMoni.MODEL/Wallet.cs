using MongoDB.Bson.Serialization.Attributes;
using PortMoni.MVVM;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PortMoni.MODEL
{
    public class Wallet : ObjectNotification
    {
        [BsonId]
        public int Id { get; set; }
        public string WalletOwner { get; set; }
        ObservableCollection<Operation> _operation; public ObservableCollection<Operation> Operations { get { return _operation; } set { _operation = value; OnPropertyChanged(); } }
        public List<Asset> Assets { get; set; }

        public double TotalInvestment()
        {
            return Assets.Select(o => o.TotalValue).Sum();
        }

        public Wallet(int walletId, string walletOwner)
        {
            Operations = new ObservableCollection<Operation>();
            Assets = new List<Asset>();

            Id = walletId;
            WalletOwner = walletOwner;
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
