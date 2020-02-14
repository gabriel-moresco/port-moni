using PortMoni.MVVM;
using PortMoni.MODEL;
using PortMoni.SERVICES;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using PortMoni.UTIL;
using System.Threading.Tasks;

namespace PortMoni.VIEWMODEL
{
    public class MainViewModel : ObjectNotification
    {
        bool _quotationsLoaded;

        public string LoggedUserName { get; set; }
        Wallet _userWallet; public Wallet UserWallet { get { return _userWallet; } set { _userWallet = value; OnPropertyChanged(); } }
        bool _progressRingIsVisible; public bool ProgressRingIsVisible { get { return _progressRingIsVisible; } set { _progressRingIsVisible = value; OnPropertyChanged(); } }

        public ICommand LoadInfoCommand => new DelegateCommand(LoadInfo);
        public ICommand OpenNewOperationViewCommand => new DelegateCommand(GoToNewOperationView);

        Action GoToNewOperationViewAction;

        public MainViewModel(string userName, Action GoToNewOperationViewAction)
        {
            this.GoToNewOperationViewAction = GoToNewOperationViewAction;

            LoggedUserName = userName;
        }

        public void SaveNewOperation(Operation operation)
        {
            UserWallet.Operations.Add(operation);
            UpdateAssets();
            Task.Run(() => DataBaseWalletServices.UpdateWallet(UserWallet));
        }

        void GoToNewOperationView(object parameter)
        {
            GoToNewOperationViewAction();
        }

        void LoadInfo(object parameter)
        {
            //TODO INSERIR ASYNC
            //await Task.Run(() =>
            //{
            ProgressRingIsVisible = true;

            if (!_quotationsLoaded)
            {
                UserWallet = DataBaseWalletServices.GetWalletByUserNameAsync(LoggedUserName);

                if (UserWallet.Operations.Count > 0)
                {
                    UpdateAssets();
                }

                _quotationsLoaded = true;
            }

            ProgressRingIsVisible = false;
            //});
        }

        void UpdateAssets()
        {
            UserWallet.UpdateAssets();

            List<Papel> currentQuoteList = GetAssetsCurrentInfo();

            foreach (Papel papel in currentQuoteList)
            {
                Share share = UserWallet.Assets.FirstOrDefault(o => o.ReferencedShare.Code == papel.Codigo).ReferencedShare;

                if (share != null && double.TryParse(papel.Ultimo, out double currentQuote))
                {
                    share.CurrentQuote = currentQuote;
                    share.Description = papel.Nome;
                }
            }
        }

        List<Papel> GetAssetsCurrentInfo()
        {
            List<string> shareCodes = new List<string>();

            foreach (Asset asset in UserWallet.Assets)
            {
                shareCodes.Add(asset.ReferencedShare.Code);
            }

            string xmlCurrentQuoteResponse = QuoteServices.GetShareListQuoteString(shareCodes);
            List<Papel> currentQuoteList = Util.DeserializeXml<List<Papel>>(xmlCurrentQuoteResponse, "ComportamentoPapeis");

            return currentQuoteList;
        }
    }
}
