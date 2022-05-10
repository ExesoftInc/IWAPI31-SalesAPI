// ----------------------------------------------------------------------------------
// <copyright company="Exesoft Inc.">
//	This code was generated by Instant Web API code automation software (https://www.InstantWebAPI.com)
//	Copyright Exesoft Inc. © 2019.  All rights reserved.
// </copyright>
// ----------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesAPI.Entities {
    
    
    public class SalesOrderHeaderConfiguration : IEntityTypeConfiguration<SalesOrderHeader> {
        
        private string _schema = "Sales";
        
        public virtual void Configure(EntityTypeBuilder<SalesOrderHeader> builder) {
            Configure(builder, _schema);
        }
        
        private void Configure(EntityTypeBuilder<SalesOrderHeader> builder, string schema) {
            builder.ToTable("SalesOrderHeader", schema);
            builder.HasKey(x => x.SalesOrderID);

            builder.Property(x => x.SalesOrderID).HasColumnName(@"SalesOrderID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.RevisionNumber).HasColumnName(@"RevisionNumber").HasColumnType("tinyint").IsRequired();
            builder.Property(x => x.OrderDate).HasColumnName(@"OrderDate").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.DueDate).HasColumnName(@"DueDate").HasColumnType("datetime").IsRequired();
            builder.Property(x => x.ShipDate).HasColumnName(@"ShipDate").HasColumnType("datetime").IsRequired(false);
            builder.Property(x => x.Status).HasColumnName(@"Status").HasColumnType("tinyint").IsRequired();
            builder.Property(x => x.OnlineOrderFlag).HasColumnName(@"OnlineOrderFlag").HasColumnType("bit").IsRequired();
            builder.Property(x => x.SalesOrderNumber).HasColumnName(@"SalesOrderNumber").HasColumnType("nvarchar").IsRequired().HasMaxLength(25).ValueGeneratedOnAddOrUpdate();
            builder.Property(x => x.PurchaseOrderNumber).HasColumnName(@"PurchaseOrderNumber").HasColumnType("nvarchar").IsRequired(false).HasMaxLength(25);
            builder.Property(x => x.AccountNumber).HasColumnName(@"AccountNumber").HasColumnType("nvarchar").IsRequired(false).HasMaxLength(15);
            builder.Property(x => x.CustomerID).HasColumnName(@"CustomerID").HasColumnType("int").IsRequired();
            builder.Property(x => x.SalesPersonID).HasColumnName(@"SalesPersonID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.TerritoryID).HasColumnName(@"TerritoryID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.BillToAddressID).HasColumnName(@"BillToAddressID").HasColumnType("int").IsRequired();
            builder.Property(x => x.ShipToAddressID).HasColumnName(@"ShipToAddressID").HasColumnType("int").IsRequired();
            builder.Property(x => x.ShipMethodID).HasColumnName(@"ShipMethodID").HasColumnType("int").IsRequired();
            builder.Property(x => x.CreditCardID).HasColumnName(@"CreditCardID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.CreditCardApprovalCode).HasColumnName(@"CreditCardApprovalCode").HasColumnType("varchar").IsRequired(false).IsUnicode(false).HasMaxLength(15);
            builder.Property(x => x.CurrencyRateID).HasColumnName(@"CurrencyRateID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.SubTotal).HasColumnName(@"SubTotal").HasColumnType("money").IsRequired().HasColumnType("decimal19,4)");
            builder.Property(x => x.TaxAmt).HasColumnName(@"TaxAmt").HasColumnType("money").IsRequired().HasColumnType("decimal19,4)");
            builder.Property(x => x.Freight).HasColumnName(@"Freight").HasColumnType("money").IsRequired().HasColumnType("decimal19,4)");
            builder.Property(x => x.TotalDue).HasColumnName(@"TotalDue").HasColumnType("money").IsRequired().HasColumnType("decimal19,4)").ValueGeneratedOnAddOrUpdate();
            builder.Property(x => x.Comment).HasColumnName(@"Comment").HasColumnType("nvarchar").IsRequired(false).HasMaxLength(128);
            builder.Property(x => x.Rowguid).HasColumnName(@"rowguid").HasColumnType("uniqueidentifier").IsRequired().ValueGeneratedOnAddOrUpdate();
            builder.Property(x => x.ModifiedDate).HasColumnName(@"ModifiedDate").HasColumnType("datetime").IsRequired();

            //Foreign keys
            builder.HasOne(a => a.Customer).WithMany(b => b.SalesOrderHeaders).HasForeignKey(c => c.CustomerID).OnDelete(DeleteBehavior.Restrict); // FK_SalesOrderHeader_Customer_CustomerID
            builder.HasOne(a => a.SalesPerson).WithMany(b => b.SalesOrderHeaders).HasForeignKey(c => c.SalesPersonID).OnDelete(DeleteBehavior.Restrict); // FK_SalesOrderHeader_SalesPerson_SalesPersonID
            builder.HasOne(a => a.SalesTerritory).WithMany(b => b.SalesOrderHeaders).HasForeignKey(c => c.TerritoryID).OnDelete(DeleteBehavior.Restrict); // FK_SalesOrderHeader_SalesTerritory_TerritoryID
            builder.HasOne(a => a.CreditCard).WithMany(b => b.SalesOrderHeaders).HasForeignKey(c => c.CreditCardID).OnDelete(DeleteBehavior.Restrict); // FK_SalesOrderHeader_CreditCard_CreditCardID
            builder.HasOne(a => a.CurrencyRate).WithMany(b => b.SalesOrderHeaders).HasForeignKey(c => c.CurrencyRateID).OnDelete(DeleteBehavior.Restrict); // FK_SalesOrderHeader_CurrencyRate_CurrencyRateID
        }
    }
}

