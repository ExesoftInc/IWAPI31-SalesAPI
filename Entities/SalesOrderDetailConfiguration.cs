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
    
    
    public class SalesOrderDetailConfiguration : IEntityTypeConfiguration<SalesOrderDetail> {
        
        private string _schema = "Sales";
        
        public virtual void Configure(EntityTypeBuilder<SalesOrderDetail> builder) {
            Configure(builder, _schema);
        }
        
        private void Configure(EntityTypeBuilder<SalesOrderDetail> builder, string schema) {
            builder.ToTable("SalesOrderDetail", schema);
            builder.HasKey(x => new { x.SalesOrderID, x.SalesOrderDetailID });

            builder.Property(x => x.SalesOrderID).HasColumnName(@"SalesOrderID").HasColumnType("int").IsRequired();
            builder.Property(x => x.SalesOrderDetailID).HasColumnName(@"SalesOrderDetailID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.CarrierTrackingNumber).HasColumnName(@"CarrierTrackingNumber").HasColumnType("nvarchar").IsRequired(false).HasMaxLength(25);
            builder.Property(x => x.OrderQty).HasColumnName(@"OrderQty").HasColumnType("smallint").IsRequired();
            builder.Property(x => x.ProductID).HasColumnName(@"ProductID").HasColumnType("int").IsRequired();
            builder.Property(x => x.SpecialOfferID).HasColumnName(@"SpecialOfferID").HasColumnType("int").IsRequired();
            builder.Property(x => x.UnitPrice).HasColumnName(@"UnitPrice").HasColumnType("money").IsRequired().HasColumnType("decimal19,4)");
            builder.Property(x => x.UnitPriceDiscount).HasColumnName(@"UnitPriceDiscount").HasColumnType("money").IsRequired().HasColumnType("decimal19,4)");
            builder.Property(x => x.LineTotal).HasColumnName(@"LineTotal").HasColumnType("numeric").IsRequired().HasColumnType("decimal38,6)").ValueGeneratedOnAddOrUpdate();
            builder.Property(x => x.Rowguid).HasColumnName(@"rowguid").HasColumnType("uniqueidentifier").IsRequired().ValueGeneratedOnAddOrUpdate();
            builder.Property(x => x.ModifiedDate).HasColumnName(@"ModifiedDate").HasColumnType("datetime").IsRequired();

            //Foreign keys
            builder.HasOne(a => a.SalesOrderHeader).WithMany(b => b.SalesOrderDetails).HasForeignKey(c => c.SalesOrderID); // FK_SalesOrderDetail_SalesOrderHeader_SalesOrderID
            builder.HasOne(a => a.SpecialOfferProduct).WithMany(b => b.SalesOrderDetails).HasForeignKey(c => new { c.SpecialOfferID, c.ProductID }).OnDelete(DeleteBehavior.Restrict); // FK_SalesOrderDetail_SpecialOfferProduct_SpecialOfferIDProductID
        }
    }
}

