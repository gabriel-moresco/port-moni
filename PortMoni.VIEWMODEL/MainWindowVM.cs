using PortMoni.CAT;
using PortMoni.MODEL;
using PortMoni.SERVICES;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PortMoni.VIEWMODEL
{
    public class MainWindowVM : ObjectNotification
    {
        ObservableCollection<Share> _shareList; public ObservableCollection<Share> ShareList { get { return _shareList; } set { _shareList = value; OnPropertyChanged(); } }

        public MainWindowVM()
        {
            ShareList = new ObservableCollection<Share>();

            Share wege3 = new Share
            {
                Code = "WEGE3",
                Description = "WEG Equipamentos Elétricos S/A",
            };
            ShareList.Add(wege3);

            Share flry4 = new Share
            {
                Code = "FLRY3",
                Description = "Fleury",
            };
            ShareList.Add(flry4);

            UpdateShareListQuote();
        }

        void UpdateShareListQuote()
        {
            List<Papel> currentQuoteList = GetCurrentShareListInfo();

            foreach (Papel papel in currentQuoteList)
            {
                Share share = ShareList.FirstOrDefault(o => o.Code == papel.Codigo);

                if (share != null && double.TryParse(papel.Ultimo, out double currentQuote))
                {
                    share.CurrentQuote = currentQuote;
                }
            }
        }

        List<Papel> GetCurrentShareListInfo()
        {
            string xmlCurrentQuoteResponse = QuoteServices.GetShareListQuoteString(ShareList.ToList());
            List<Papel> currentQuoteList = Util.Deserialize<List<Papel>>(xmlCurrentQuoteResponse, "ComportamentoPapeis");
            return currentQuoteList;
        }
    }
}
