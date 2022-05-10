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
    
    
    public partial class SalesTerritory {
        
        [Key()]
        [Display(Name = "Territory ID")]
        public int TerritoryID { get; set; }
        
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Display(Name = "Country region code")]
        public string CountryRegionCode { get; set; }
        
        [Display(Name = "Group")]
        public string Group { get; set; }
        
        [Display(Name = "Sales ytd")]
        public decimal SalesYTD { get; set; }
        
        [Display(Name = "Sales last year")]
        public decimal SalesLastYear { get; set; }
        
        [Display(Name = "Cost ytd")]
        public decimal CostYTD { get; set; }
        
        [Display(Name = "Cost last year")]
        public decimal CostLastYear { get; set; }
        
        [Display(Name = "Rowguid")]
        public System.Guid Rowguid { get; set; }
        
        [Display(Name = "Modified date")]
        public System.DateTime ModifiedDate { get; set; }
        
        /// Child Customers where [Customer].[TerritoryID] point to this entity (FK_Customer_SalesTerritory_TerritoryID)
        public virtual ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();
        
        /// Child SalesOrderHeaders where [SalesOrderHeader].[TerritoryID] point to this entity (FK_SalesOrderHeader_SalesTerritory_TerritoryID)
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new HashSet<SalesOrderHeader>();
        
        /// Child SalesPersons where [SalesPerson].[TerritoryID] point to this entity (FK_SalesPerson_SalesTerritory_TerritoryID)
        public virtual ICollection<SalesPerson> SalesPersons { get; set; } = new HashSet<SalesPerson>();
        
        /// Child SalesTerritoryHistories where [SalesTerritoryHistory].[TerritoryID] point to this entity (FK_SalesTerritoryHistory_SalesTerritory_TerritoryID)
        public virtual ICollection<SalesTerritoryHistory> SalesTerritoryHistories { get; set; } = new HashSet<SalesTerritoryHistory>();
    }
}

