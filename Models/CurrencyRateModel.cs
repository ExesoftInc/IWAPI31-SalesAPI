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
    
    
    public class CurrencyRateModel {
        
        protected internal int _currencyRateID;
        
        protected internal System.DateTime _currencyRateDate;
        
        protected internal string _fromCurrencyCode;
        
        protected internal string _toCurrencyCode;
        
        protected internal decimal _averageRate;
        
        protected internal decimal _endOfDayRate;
        
        protected internal System.DateTime _modifiedDate;
        
        public CurrencyRateModel() {
        }
        
        internal CurrencyRateModel(CurrencyRate entity) {
            this._currencyRateID = entity.CurrencyRateID;
            this._currencyRateDate = entity.CurrencyRateDate;
            this._fromCurrencyCode = entity.FromCurrencyCode;
            this._toCurrencyCode = entity.ToCurrencyCode;
            this._averageRate = entity.AverageRate;
            this._endOfDayRate = entity.EndOfDayRate;
            this._modifiedDate = entity.ModifiedDate;
        }
        
        [Display(Name = "Currency rate ID")]
        public int CurrencyRateID {
            get {
                return this._currencyRateID;
            }
            set {
                this._currencyRateID = value;
            }
        }
        
        [Required()]
        [DataType(DataType.DateTime)]
        [Display(Name = "Currency rate date")]
        public System.DateTime CurrencyRateDate {
            get {
                return this._currencyRateDate;
            }
            set {
                this._currencyRateDate = value;
            }
        }
        
        [Required()]
        [MaxLength(3)]
        [StringLength(3)]
        [Display(Name = "From currency code")]
        public string FromCurrencyCode {
            get {
                return this._fromCurrencyCode;
            }
            set {
                this._fromCurrencyCode = value;
            }
        }
        
        [Required()]
        [MaxLength(3)]
        [StringLength(3)]
        [Display(Name = "To currency code")]
        public string ToCurrencyCode {
            get {
                return this._toCurrencyCode;
            }
            set {
                this._toCurrencyCode = value;
            }
        }
        
        [Required()]
        [DataType(DataType.Currency)]
        [Display(Name = "Average rate")]
        public decimal AverageRate {
            get {
                return this._averageRate;
            }
            set {
                this._averageRate = value;
            }
        }
        
        [Required()]
        [DataType(DataType.Currency)]
        [Display(Name = "End of day rate")]
        public decimal EndOfDayRate {
            get {
                return this._endOfDayRate;
            }
            set {
                this._endOfDayRate = value;
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
        
        /// Child SalesOrderHeaders where [SalesOrderHeader].[CurrencyRateID] point to this entity (FK_SalesOrderHeader_CurrencyRate_CurrencyRateID)
        public virtual ICollection<SalesOrderHeaderModel> SalesOrderHeadersModel { get; set; } = new HashSet<SalesOrderHeaderModel>();
        
        public override int GetHashCode() {
            int hash = 0;
            hash ^=CurrencyRateDate.GetHashCode();
            hash ^=FromCurrencyCode.GetHashCode();
            hash ^=ToCurrencyCode.GetHashCode();
            return hash;
        }
        
        public override string ToString() {
            return CurrencyRateDate.ToShortDateString()
                 + "-" + FromCurrencyCode
                 + "-" + ToCurrencyCode
;
        }
        
        public override bool Equals(object obj) {
        bool result = false;

            if (obj is CurrencyRateModel) {
                CurrencyRateModel toCompare = (CurrencyRateModel)obj;
              if(toCompare != null)
              {
                  result = Equals(toCompare);
              }
            }

            return result;
        }
        
        public virtual bool Equals(CurrencyRateModel toCompare) {

        bool result = false;

            if (toCompare != null) {
                result = toCompare.CurrencyRateDate.Equals(CurrencyRateDate)
             && string.Compare(toCompare.FromCurrencyCode, FromCurrencyCode, true) == 0
             && string.Compare(toCompare.ToCurrencyCode, ToCurrencyCode, true) == 0
;
            }

            return result;
        }
    }
}
