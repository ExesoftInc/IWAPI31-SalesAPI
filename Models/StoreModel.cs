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
    
    
    public class StoreModel {
        
        protected internal int _businessEntityID;
        
        protected internal string _name;
        
        protected internal int? _salesPersonID;
        
        protected internal string _demographics;
        
        protected internal System.Guid _rowguid;
        
        protected internal System.DateTime _modifiedDate;
        
        public StoreModel() {
        }
        
        internal StoreModel(Store entity) {
            this._businessEntityID = entity.BusinessEntityID;
            this._name = entity.Name;
            this._salesPersonID = entity.SalesPersonID;
            this._demographics = entity.Demographics;
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
        
        [Display(Name = "Sales person ID")]
        public int? SalesPersonID {
            get {
                return this._salesPersonID;
            }
            set {
                this._salesPersonID = value;
            }
        }
        
        [Display(Name = "Demographics")]
        public string Demographics {
            get {
                return this._demographics;
            }
            set {
                this._demographics = value;
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
        
        /// Child Customers where [Customer].[StoreID] point to this entity (FK_Customer_Store_StoreID)
        public virtual ICollection<CustomerModel> CustomersModel { get; set; } = new HashSet<CustomerModel>();
        
        public override int GetHashCode() {
            int hash = 0;
            hash ^=BusinessEntityID.GetHashCode();
            return hash;
        }
        
        public override string ToString() {
            return BusinessEntityID.ToString()
;
        }
        
        public override bool Equals(object obj) {
        bool result = false;

            if (obj is StoreModel) {
                StoreModel toCompare = (StoreModel)obj;
              if(toCompare != null)
              {
                  result = Equals(toCompare);
              }
            }

            return result;
        }
        
        public virtual bool Equals(StoreModel toCompare) {

        bool result = false;

            if (toCompare != null) {
                result = toCompare.BusinessEntityID == BusinessEntityID
;
            }

            return result;
        }
    }
}
