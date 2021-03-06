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
    
    
    public class CurrencyModel {
        
        protected internal string _currencyCode;
        
        protected internal string _name;
        
        protected internal System.DateTime _modifiedDate;
        
        public CurrencyModel() {
        }
        
        internal CurrencyModel(Currency entity) {
            this._currencyCode = entity.CurrencyCode;
            this._name = entity.Name;
            this._modifiedDate = entity.ModifiedDate;
        }
        
        [Required()]
        [MaxLength(3)]
        [StringLength(3)]
        [Display(Name = "Currency code")]
        public string CurrencyCode {
            get {
                return this._currencyCode;
            }
            set {
                this._currencyCode = value;
            }
        }
        
        [Required()]
        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string Name {
            get {
                return this._name;
            }
            set {
                this._name = value;
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
        
        /// Child CountryRegionCurrencies where [CountryRegionCurrency].[CurrencyCode] point to this entity (FK_CountryRegionCurrency_Currency_CurrencyCode)
        public virtual ICollection<CountryRegionCurrencyModel> CountryRegionCurrenciesModel { get; set; } = new HashSet<CountryRegionCurrencyModel>();
        
        /// Child CurrencyRates where [CurrencyRate].[FromCurrencyCode] point to this entity (FK_CurrencyRate_Currency_FromCurrencyCode)
        public virtual ICollection<CurrencyRateModel> CurrencyRates_FromCurrencyCodeModel { get; set; } = new HashSet<CurrencyRateModel>();
        
        /// Child CurrencyRates where [CurrencyRate].[ToCurrencyCode] point to this entity (FK_CurrencyRate_Currency_ToCurrencyCode)
        public virtual ICollection<CurrencyRateModel> CurrencyRates_ToCurrencyCodeModel { get; set; } = new HashSet<CurrencyRateModel>();
        
        public override int GetHashCode() {
            int hash = 0;
            hash ^=CurrencyCode.GetHashCode();
            return hash;
        }
        
        public override string ToString() {
            return CurrencyCode
;
        }
        
        public override bool Equals(object obj) {
        bool result = false;

            if (obj is CurrencyModel) {
                CurrencyModel toCompare = (CurrencyModel)obj;
              if(toCompare != null)
              {
                  result = Equals(toCompare);
              }
            }

            return result;
        }
        
        public virtual bool Equals(CurrencyModel toCompare) {

        bool result = false;

            if (toCompare != null) {
                result = string.Compare(toCompare.CurrencyCode, CurrencyCode, true) == 0
;
            }

            return result;
        }
    }
}

