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
    
    
    public class SalesPersonQuotaHistoryModel {
        
        protected internal int _businessEntityID;
        
        protected internal System.DateTime _quotaDate;
        
        protected internal decimal _salesQuota;
        
        protected internal System.Guid _rowguid;
        
        protected internal System.DateTime _modifiedDate;
        
        public SalesPersonQuotaHistoryModel() {
        }
        
        internal SalesPersonQuotaHistoryModel(SalesPersonQuotaHistory entity) {
            this._businessEntityID = entity.BusinessEntityID;
            this._quotaDate = entity.QuotaDate;
            this._salesQuota = entity.SalesQuota;
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
        [DataType(DataType.DateTime)]
        [Display(Name = "Quota date")]
        public System.DateTime QuotaDate {
            get {
                return this._quotaDate;
            }
            set {
                this._quotaDate = value;
            }
        }
        
        [Required()]
        [DataType(DataType.Currency)]
        [Display(Name = "Sales quota")]
        public decimal SalesQuota {
            get {
                return this._salesQuota;
            }
            set {
                this._salesQuota = value;
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
            hash ^=QuotaDate.GetHashCode();
            return hash;
        }
        
        public override string ToString() {
            return BusinessEntityID.ToString()
                 + "-" + QuotaDate.ToShortDateString()
;
        }
        
        public override bool Equals(object obj) {
        bool result = false;

            if (obj is SalesPersonQuotaHistoryModel) {
                SalesPersonQuotaHistoryModel toCompare = (SalesPersonQuotaHistoryModel)obj;
              if(toCompare != null)
              {
                  result = Equals(toCompare);
              }
            }

            return result;
        }
        
        public virtual bool Equals(SalesPersonQuotaHistoryModel toCompare) {

        bool result = false;

            if (toCompare != null) {
                result = toCompare.BusinessEntityID == BusinessEntityID
             && toCompare.QuotaDate.Equals(QuotaDate)
;
            }

            return result;
        }
    }
}

