using System;

namespace JSONCovidDash.Events
{
    public class CriterioPesquisaEventArgs : EventArgs
    {
        public string Region { get; private set; }
        public DateTime Date { get; private set; }

        public CriterioPesquisaEventArgs(string region, DateTime date)
        {
            this.Region = region;
            this.Date = date;
        }
    }

}
