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
    
    
    public partial class SalesReason {
        
        [Key()]
        [Display(Name = "Sales reason ID")]
        public int SalesReasonID { get; set; }
        
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Display(Name = "Reason type")]
        public string ReasonType { get; set; }
        
        [Display(Name = "Modified date")]
        public System.DateTime ModifiedDate { get; set; }
        
        /// Child SalesOrderHeaderSalesReasons where [SalesOrderHeaderSalesReason].[SalesReasonID] point to this entity (FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID)
        public virtual ICollection<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReasons { get; set; } = new HashSet<SalesOrderHeaderSalesReason>();
    }
}

