using PortMoni.MVVM;

namespace PortMoni.MODEL
{
    public class Share : ObjectNotification
    {
        string _code; public string Code { get { return _code; } set { _code = value; OnPropertyChanged(); } }
        string _description; public string Description { get { return _description; } set { _description = value; OnPropertyChanged(); } }
        double _currentQuote; public double CurrentQuote { get { return _currentQuote; } set { _currentQuote = value; OnPropertyChanged(); } }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Code, Description);
        }
    }
}
