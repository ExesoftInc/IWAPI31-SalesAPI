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
    
    
    public partial class SalesTerritoryHistory {
        
        [Key()]
        [Column(Order=1)]
        [Display(Name = "Business entity ID")]
        public int BusinessEntityID { get; set; }
        
        [Key()]
        [Column(Order=3)]
        [Display(Name = "Territory ID")]
        public int TerritoryID { get; set; }
        
        [Key()]
        [Column(Order=2)]
        [Display(Name = "Start date")]
        public System.DateTime StartDate { get; set; }
        
        [Display(Name = "End date")]
        public System.DateTime? EndDate { get; set; }
        
        [Display(Name = "Rowguid")]
        public System.Guid Rowguid { get; set; }
        
        [Display(Name = "Modified date")]
        public System.DateTime ModifiedDate { get; set; }
        
        // Parent SalesPerson pointed by [SalesTerritoryHistory].([BusinessEntityID]) (FK_SalesTerritoryHistory_SalesPerson_BusinessEntityID)
        public virtual SalesPerson SalesPerson { get; set; }
        
        // Parent SalesTerritory pointed by [SalesTerritoryHistory].([TerritoryID]) (FK_SalesTerritoryHistory_SalesTerritory_TerritoryID)
        public virtual SalesTerritory SalesTerritory { get; set; }
    }
}

