// ----------------------------------------------------------------------------------
// <copyright company="Exesoft Inc.">
//	This code was generated by Instant Web API code automation software (https://www.InstantWebAPI.com)
//	Copyright Exesoft Inc. © 2019.  All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------------

using SalesAPI.Entities;
using SalesAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesAPI.Models {
    
    
    public class SalesTerritoryHistoryModel {
        
        protected internal int _businessEntityID;
        
        protected internal int _territoryID;
        
        protected internal System.DateTime _startDate;
        
        protected internal System.DateTime? _endDate;
        
        protected internal System.Guid _rowguid;
        
        protected internal System.DateTime _modifiedDate;
        
        public SalesTerritoryHistoryModel() {
        }
        
        internal SalesTerritoryHistoryModel(SalesTerritoryHistory entity) {
            this._businessEntityID = entity.BusinessEntityID;
            this._territoryID = entity.TerritoryID;
            this._startDate = entity.StartDate;
            this._endDate = entity.EndDate;
            _rowguid = entity.Rowguid;
            this._modifiedDate = entity.ModifiedDate;
        }
        
        [Required()]
        [Display(Name = "Business entity ID")]
        public int BusinessEntityID {
            get {
                return this._businessEntityID;
            }
            set {
                this._businessEntityID = value;
            }
        }
        
        [Required()]
        [Display(Name = "Territory ID")]
        public int TerritoryID {
            get {
                return this._territoryID;
            }
            set {
                this._territoryID = value;
            }
        }
        
        [Required()]
        [DataType(DataType.DateTime)]
        [Display(Name = "Start date")]
        public System.DateTime StartDate {
            get {
                return this._startDate;
            }
            set {
                this._startDate = value;
            }
        }
        
        [DataType(DataType.DateTime)]
        [Display(Name = "End date")]
        public System.DateTime? EndDate {
            get {
                return this._endDate;
            }
            set {
                this._endDate = value;
            }
        }
        
        [Display(Name = "Rowguid")]
        public System.Guid Rowguid {
            get {
                return this._rowguid;
            }
        }
        
        [Required()]
        [DataType(DataType.DateTime)]
        [Display(Name = "Modified date")]
        public System.DateTime ModifiedDate {
            get {
                return this._modifiedDate;
            }
            set {
                this._modifiedDate = value;
            }
        }
        
        public override int GetHashCode() {
            int hash = 0;
            hash ^=BusinessEntityID.GetHashCode();
            hash ^=TerritoryID.GetHashCode();
            hash ^=StartDate.GetHashCode();
            return hash;
        }
        
        public override string ToString() {
            return BusinessEntityID.ToString()
                 + "-" + TerritoryID.ToString()
                 + "-" + StartDate.ToShortDateString()
;
        }
        
        public override bool Equals(object obj) {
        bool result = false;

            if (obj is SalesTerritoryHistoryModel) {
                SalesTerritoryHistoryModel toCompare = (SalesTerritoryHistoryModel)obj;
              if(toCompare != null)
              {
                  result = Equals(toCompare);
              }
            }

            return result;
        }
        
        public virtual bool Equals(SalesTerritoryHistoryModel toCompare) {

        bool result = false;

            if (toCompare != null) {
                result = toCompare.BusinessEntityID == BusinessEntityID
             && toCompare.TerritoryID == TerritoryID
             && toCompare.StartDate.Equals(StartDate)
;
            }

            return result;
        }
    }
}

