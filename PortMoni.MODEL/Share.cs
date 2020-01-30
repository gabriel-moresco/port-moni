namespace PortMoni.MODEL
{
    public class Share
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public double CurrentQuote { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Code, Description);
        }
    }
}
