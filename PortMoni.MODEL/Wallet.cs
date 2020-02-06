using MongoDB.Bson.Serialization.Attributes;
using PortMoni.MVVM;
using PortMoni.UTIL;
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
        ObservableCollection<Asset> _assets; public ObservableCollection<Asset> Assets { get { return _assets; } set { _assets = value; OnPropertyChanged(); } }

        public double Profitability { get; set; }

        public double TotalToday
        {
            get
            {
                return Assets.Select(o => o.TotalValue).Sum();
            }
        }

        public double TotalApplied
        {
            get
            {
                double totalApplied = 0;

                foreach (Operation operation in Operations)
                {
                    double operationCost = operation.Quantity * operation.Price;

                    totalApplied += operation.Type == Constants.OperationType.Buy ? operationCost : operationCost * -1;
                }

                return totalApplied;
            }
        }

        public Wallet(int walletId, string walletOwner)
        {
            Operations = new ObservableCollection<Operation>();
            Assets = new ObservableCollection<Asset>();

            Id = walletId;
            WalletOwner = walletOwner;
        }

        public void UpdateAssets()
        {
            Assets.Clear();

            foreach (Operation operation in Operations)
            {
                if (!Assets.Any(o => o.ReferencedShare.Code == operation.ShareCode))
                {
                    Assets.Add(new Asset(new Share { Code = operation.ShareCode }, 0));
                }

                if (operation.Type == UTIL.Constants.OperationType.Buy)
                {
                    Assets.FirstOrDefault(o => o.ReferencedShare.Code == operation.ShareCode).Quantity += operation.Quantity;
                }
                else
                {
                    Assets.FirstOrDefault(o => o.ReferencedShare.Code == operation.ShareCode).Quantity -= operation.Quantity;
                }
            }
        }
    }
}
