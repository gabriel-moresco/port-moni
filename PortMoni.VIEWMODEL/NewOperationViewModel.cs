using PortMoni.MODEL;
using PortMoni.MVVM;
using PortMoni.UTIL;
using System;
using System.Windows.Input;

namespace PortMoni.VIEWMODEL
{
    public class NewOperationViewModel : ObjectNotification
    {
        bool _buyOperationIsChecked; public bool BuyOperationSelected { get { return _buyOperationIsChecked; } set { _buyOperationIsChecked = value; OnPropertyChanged(); } }
        bool _sellOperationIsChecked; public bool SellOperationSelected { get { return _sellOperationIsChecked; } set { _sellOperationIsChecked = value; OnPropertyChanged(); } }
        string _shareCode; public string ShareCode { get { return _shareCode; } set { _shareCode = value; OnPropertyChanged(); } }
        double _operationPrice; public double OperationPrice { get { return _operationPrice; } set { _operationPrice = value; OnPropertyChanged(); } }
        string _operationDate; public string OperationDate { get { return _operationDate; } set { _operationDate = value; OnPropertyChanged(); } }
        double _operationTaxes; public double OperationTaxes { get { return _operationTaxes; } set { _operationTaxes = value; OnPropertyChanged(); } }

        public ICommand SaveNewInvestimentCommand => new DelegateCommand(SaveNewInvestment, CanSaveNewInvestment);
        public ICommand GoToMainViewCommand => new DelegateCommand(GoToMainView);

        Action<string> GoToMainViewAction;
        Action<Operation> SaveNewOperationAction;

        public NewOperationViewModel(Action<string> GoToMainViewAction, Action<Operation> SaveNewOperationAction)
        {
            this.GoToMainViewAction = GoToMainViewAction;
            this.SaveNewOperationAction = SaveNewOperationAction;
        }

        void SaveNewInvestment(object parameter)
        {
            Constants.OperationType operationType = BuyOperationSelected ? Constants.OperationType.Buy : Constants.OperationType.Sell;

            Operation operation = new Operation(ShareCode, operationType, OperationPrice, DateTime.Parse(OperationDate), OperationTaxes);

            SaveNewOperationAction(operation);
            GoToMainView(null);
        }

        void GoToMainView(object parameter)
        {
            GoToMainViewAction(null);
        }

        bool CanSaveNewInvestment()
        {
            return (BuyOperationSelected || SellOperationSelected) && ShareCode?.Length >= 4 && OperationPrice > 0 && DateTime.TryParse(OperationDate, out DateTime a);
        }
    }
}
