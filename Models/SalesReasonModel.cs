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
    
    
    public class SalesReasonModel {
        
        protected internal int _salesReasonID;
        
        protected internal string _name;
        
        protected internal string _reasonType;
        
        protected internal System.DateTime _modifiedDate;
        
        public SalesReasonModel() {
        }
        
        internal SalesReasonModel(SalesReason entity) {
            this._salesReasonID = entity.SalesReasonID;
            this._name = entity.Name;
            this._reasonType = entity.ReasonType;
            this._modifiedDate = entity.ModifiedDate;
        }
        
        [Display(Name = "Sales reason ID")]
        public int SalesReasonID {
            get {
                return this._salesReasonID;
            }
            set {
                this._salesReasonID = value;
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
        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Reason type")]
        public string ReasonType {
            get {
                return this._reasonType;
            }
            set {
                this._reasonType = value;
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
        
        /// Child SalesOrderHeaderSalesReasons where [SalesOrderHeaderSalesReason].[SalesReasonID] point to this entity (FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID)
        public virtual ICollection<SalesOrderHeaderSalesReasonModel> SalesOrderHeaderSalesReasonsModel { get; set; } = new HashSet<SalesOrderHeaderSalesReasonModel>();
        
        public override int GetHashCode() {
            int hash = 0;
            hash ^=Name.GetHashCode();
            hash ^=ReasonType.GetHashCode();
            return hash;
        }
        
        public override string ToString() {
            return Name
                 + "-" + ReasonType
;
        }
        
        public override bool Equals(object obj) {
        bool result = false;

            if (obj is SalesReasonModel) {
                SalesReasonModel toCompare = (SalesReasonModel)obj;
              if(toCompare != null)
              {
                  result = Equals(toCompare);
              }
            }

            return result;
        }
        
        public virtual bool Equals(SalesReasonModel toCompare) {

        bool result = false;

            if (toCompare != null) {
                result = string.Compare(toCompare.Name, Name, true) == 0
             && string.Compare(toCompare.ReasonType, ReasonType, true) == 0
;
            }

            return result;
        }
    }
}
