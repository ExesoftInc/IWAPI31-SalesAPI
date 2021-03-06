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
    
    
    public class ShoppingCartItemModel {
        
        protected internal int _shoppingCartItemID;
        
        protected internal string _shoppingCartID;
        
        protected internal int _quantity;
        
        protected internal int _productID;
        
        protected internal System.DateTime _dateCreated;
        
        protected internal System.DateTime _modifiedDate;
        
        public ShoppingCartItemModel() {
        }
        
        internal ShoppingCartItemModel(ShoppingCartItem entity) {
            this._shoppingCartItemID = entity.ShoppingCartItemID;
            this._shoppingCartID = entity.ShoppingCartID;
            this._quantity = entity.Quantity;
            this._productID = entity.ProductID;
            this._dateCreated = entity.DateCreated;
            this._modifiedDate = entity.ModifiedDate;
        }
        
        [Display(Name = "Shopping cart item ID")]
        public int ShoppingCartItemID {
            get {
                return this._shoppingCartItemID;
            }
            set {
                this._shoppingCartItemID = value;
            }
        }
        
        [Required()]
        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Shopping cart ID")]
        public string ShoppingCartID {
            get {
                return this._shoppingCartID;
            }
            set {
                this._shoppingCartID = value;
            }
        }
        
        [Required()]
        [Display(Name = "Quantity")]
        public int Quantity {
            get {
                return this._quantity;
            }
            set {
                this._quantity = value;
            }
        }
        
        [Required()]
        [Display(Name = "Product ID")]
        public int ProductID {
            get {
                return this._productID;
            }
            set {
                this._productID = value;
            }
        }
        
        [Required()]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date created")]
        public System.DateTime DateCreated {
            get {
                return this._dateCreated;
            }
            set {
                this._dateCreated = value;
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
            hash ^=ShoppingCartID.GetHashCode();
            hash ^=Quantity.GetHashCode();
            hash ^=ProductID.GetHashCode();
            return hash;
        }
        
        public override string ToString() {
            return ShoppingCartID
                 + "-" + Quantity.ToString()
                 + "-" + ProductID.ToString()
;
        }
        
        public override bool Equals(object obj) {
        bool result = false;

            if (obj is ShoppingCartItemModel) {
                ShoppingCartItemModel toCompare = (ShoppingCartItemModel)obj;
              if(toCompare != null)
              {
                  result = Equals(toCompare);
              }
            }

            return result;
        }
        
        public virtual bool Equals(ShoppingCartItemModel toCompare) {

        bool result = false;

            if (toCompare != null) {
                result = string.Compare(toCompare.ShoppingCartID, ShoppingCartID, true) == 0
             && toCompare.Quantity == Quantity
             && toCompare.ProductID == ProductID
;
            }

            return result;
        }
    }
}

