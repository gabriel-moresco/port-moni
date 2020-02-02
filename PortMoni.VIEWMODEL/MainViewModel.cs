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

namespace PortMoni.VIEWMODEL
{
    public class MainViewModel : ObjectNotification
    {
        ObservableCollection<Share> _shareList; public ObservableCollection<Share> ShareList { get { return _shareList; } set { _shareList = value; OnPropertyChanged(); } }
        bool _progressRingIsVisible; public bool ProgressRingIsVisible { get { return _progressRingIsVisible; } set { _progressRingIsVisible = value; OnPropertyChanged(); } }

        public ICommand LoadInfoCommand => new DelegateCommand(LoadInfo);

        public MainViewModel()
        {
            ShareList = new ObservableCollection<Share>();
        }

        void LoadInfo(object parameter)
        {
            //await Task.Run(() =>
            //{
            //ProgressRingIsVisible = true;
            PopulateShareListFromTextFile();
            UpdateShareListQuoteAndDescription();
            //ProgressRingIsVisible = false;
            //});
        }

        void PopulateShareListFromTextFile()
        {
            string shareListString = string.Empty;

            using (StreamReader reader = new StreamReader(@"..\..\..\PortMoni.UTIL\shares.txt"))
            {
                shareListString = reader.ReadToEnd();
            }

            string[] shareListArray = shareListString.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string shareString in shareListArray)
            {
                ShareList.Add(new Share
                {
                    Code = shareString
                });
            }
        }

        void UpdateShareListQuoteAndDescription()
        {
            List<Papel> currentQuoteList = GetCurrentShareListInfo();

            foreach (Papel papel in currentQuoteList)
            {
                Share share = ShareList.FirstOrDefault(o => o.Code == papel.Codigo);

                if (share != null && double.TryParse(papel.Ultimo, out double currentQuote))
                {
                    share.CurrentQuote = currentQuote;
                    share.Description = papel.Nome;
                }
            }
        }

        List<Papel> GetCurrentShareListInfo()
        {
            string xmlCurrentQuoteResponse = QuoteServices.GetShareListQuoteString(ShareList.ToList());
            List<Papel> currentQuoteList = Util.DeserializeXml<List<Papel>>(xmlCurrentQuoteResponse, "ComportamentoPapeis");
            return currentQuoteList;
        }
    }
}
