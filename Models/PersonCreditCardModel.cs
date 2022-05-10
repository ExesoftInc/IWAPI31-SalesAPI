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
    
    
    public class PersonCreditCardModel {
        
        protected internal int _businessEntityID;
        
        protected internal int _creditCardID;
        
        protected internal System.DateTime _modifiedDate;
        
        public PersonCreditCardModel() {
        }
        
        internal PersonCreditCardModel(PersonCreditCard entity) {
            this._businessEntityID = entity.BusinessEntityID;
            this._creditCardID = entity.CreditCardID;
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
        [Display(Name = "Credit card ID")]
        public int CreditCardID {
            get {
                return this._creditCardID;
            }
            set {
                this._creditCardID = value;
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
            hash ^=CreditCardID.GetHashCode();
            return hash;
        }
        
        public override string ToString() {
            return BusinessEntityID.ToString()
                 + "-" + CreditCardID.ToString()
;
        }
        
        public override bool Equals(object obj) {
        bool result = false;

            if (obj is PersonCreditCardModel) {
                PersonCreditCardModel toCompare = (PersonCreditCardModel)obj;
              if(toCompare != null)
              {
                  result = Equals(toCompare);
              }
            }

            return result;
        }
        
        public virtual bool Equals(PersonCreditCardModel toCompare) {

        bool result = false;

            if (toCompare != null) {
                result = toCompare.BusinessEntityID == BusinessEntityID
             && toCompare.CreditCardID == CreditCardID
;
            }

            return result;
        }
    }
}
