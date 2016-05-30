using System;
using System.Collections.Generic;
using System.Text;

namespace BDCode
{
    public class TIPData
    {
        public int code { get; set; }
        public TData data { get; set; }

        public string getCounty()
        {
            return data.city.Replace("市", string.Empty);
        }
    }

    public class TData
    {
        public string ip { get; set; }
        public string country { get; set; }
        public string area { get; set; }
        public string region { get; set; }
        public string city { get; set; }
        public string county { get; set; }
        public string isp { get; set; }
        public string country_id { get; set; }
        public string area_id { get; set; }
        public string region_id { get; set; }
        public string city_id { get; set; }
        public string county_id { get; set; }
        public string isp_id { get; set; }
    }
}
