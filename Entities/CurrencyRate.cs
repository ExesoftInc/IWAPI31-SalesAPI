// ----------------------------------------------------------------------------------
// <copyright company="Exesoft Inc.">
//	This code was generated by Instant Web API code automation software (https://www.InstantWebAPI.com)
//	Copyright Exesoft Inc. © 2019.  All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesAPI.Entities {
    
    
    public partial class CurrencyRate {
        
        [Key()]
        [Display(Name = "Currency rate ID")]
        public int CurrencyRateID { get; set; }
        
        [Display(Name = "Currency rate date")]
        public System.DateTime CurrencyRateDate { get; set; }
        
        [Display(Name = "From currency code")]
        public string FromCurrencyCode { get; set; }
        
        [Display(Name = "To currency code")]
        public string ToCurrencyCode { get; set; }
        
        [Display(Name = "Average rate")]
        public decimal AverageRate { get; set; }
        
        [Display(Name = "End of day rate")]
        public decimal EndOfDayRate { get; set; }
        
        [Display(Name = "Modified date")]
        public System.DateTime ModifiedDate { get; set; }
        
        /// Child SalesOrderHeaders where [SalesOrderHeader].[CurrencyRateID] point to this entity (FK_SalesOrderHeader_CurrencyRate_CurrencyRateID)
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new HashSet<SalesOrderHeader>();
        
        // Parent Currency pointed by [CurrencyRate].([FromCurrencyCode]) (FK_CurrencyRate_Currency_FromCurrencyCode)
        public virtual Currency Currency_FromCurrencyCode { get; set; }
        
        // Parent Currency pointed by [CurrencyRate].([ToCurrencyCode]) (FK_CurrencyRate_Currency_ToCurrencyCode)
        public virtual Currency Currency_ToCurrencyCode { get; set; }
    }
}
