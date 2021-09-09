using System;

namespace JSONCovidDash.Models
{
    public class Criterios
    {
        public string Regiao { get; set; }
        public DateTime Data { get; set; }

        public Criterios()
        {
            this.Regiao = string.Empty;
            this.Data = new DateTime(2021, 4, 10);
        }

    }
}
