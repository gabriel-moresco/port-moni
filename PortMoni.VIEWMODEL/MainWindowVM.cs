using PortMoni.MODEL;
using PortMoni.SERVICES;
using System.Collections.ObjectModel;
using System.Linq;

namespace PortMoni.VIEWMODEL
{
    public class MainWindowVM
    {
        public ObservableCollection<Share> ShareList { get; set; }

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

            string response = QuoteServices.GetShareListQuoteString(ShareList.ToList());
            var teste = Util.Deserialize<ComportamentoPapeis>(response);
        }
    }
}
