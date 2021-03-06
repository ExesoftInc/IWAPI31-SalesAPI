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
    
    
    public partial class SalesOrderHeaderSalesReason {
        
        [Key()]
        [Column(Order=1)]
        [Display(Name = "Sales order ID")]
        public int SalesOrderID { get; set; }
        
        [Key()]
        [Column(Order=2)]
        [Display(Name = "Sales reason ID")]
        public int SalesReasonID { get; set; }
        
        [Display(Name = "Modified date")]
        public System.DateTime ModifiedDate { get; set; }
        
        // Parent SalesOrderHeader pointed by [SalesOrderHeaderSalesReason].([SalesOrderID]) (FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID)
        public virtual SalesOrderHeader SalesOrderHeader { get; set; }
        
        // Parent SalesReason pointed by [SalesOrderHeaderSalesReason].([SalesReasonID]) (FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID)
        public virtual SalesReason SalesReason { get; set; }
    }
}

