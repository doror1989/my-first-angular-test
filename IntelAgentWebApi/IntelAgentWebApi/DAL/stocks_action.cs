//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IntelAgentWebApi.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class stocks_action
    {
        public string Id { get; set; }
        public string user_id { get; set; }
        public System.DateTime date_time { get; set; }
        public string stock_name { get; set; }
        public byte sell_action { get; set; }
        public Nullable<double> limit { get; set; }
        public byte market_limit { get; set; }
        public int quantity { get; set; }
        public string strategy { get; set; }
        public string target { get; set; }
        public string status { get; set; }
        public Nullable<int> amount_done { get; set; }
        public Nullable<double> price_done { get; set; }
    }
}
