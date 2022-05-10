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
    
    
    public partial class CreditCard {
        
        [Key()]
        [Display(Name = "Credit card ID")]
        public int CreditCardID { get; set; }
        
        [Display(Name = "Card type")]
        public string CardType { get; set; }
        
        [Display(Name = "Card number")]
        public string CardNumber { get; set; }
        
        [Display(Name = "Exp month")]
        public byte ExpMonth { get; set; }
        
        [Display(Name = "Exp year")]
        public short ExpYear { get; set; }
        
        [Display(Name = "Modified date")]
        public System.DateTime ModifiedDate { get; set; }
        
        /// Child PersonCreditCards where [PersonCreditCard].[CreditCardID] point to this entity (FK_PersonCreditCard_CreditCard_CreditCardID)
        public virtual ICollection<PersonCreditCard> PersonCreditCards { get; set; } = new HashSet<PersonCreditCard>();
        
        /// Child SalesOrderHeaders where [SalesOrderHeader].[CreditCardID] point to this entity (FK_SalesOrderHeader_CreditCard_CreditCardID)
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = new HashSet<SalesOrderHeader>();
    }
}

