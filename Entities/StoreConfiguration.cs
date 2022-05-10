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
    
    
    public class StoreConfiguration : IEntityTypeConfiguration<Store> {
        
        private string _schema = "Sales";
        
        public virtual void Configure(EntityTypeBuilder<Store> builder) {
            Configure(builder, _schema);
        }
        
        private void Configure(EntityTypeBuilder<Store> builder, string schema) {
            builder.ToTable("Store", schema);
            builder.HasKey(x => x.BusinessEntityID);

            builder.Property(x => x.BusinessEntityID).HasColumnName(@"BusinessEntityID").HasColumnType("int").IsRequired();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            builder.Property(x => x.SalesPersonID).HasColumnName(@"SalesPersonID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.Demographics).HasColumnName(@"Demographics").HasColumnType("xml").IsRequired(false);
            builder.Property(x => x.Rowguid).HasColumnName(@"rowguid").HasColumnType("uniqueidentifier").IsRequired().ValueGeneratedOnAddOrUpdate();
            builder.Property(x => x.ModifiedDate).HasColumnName(@"ModifiedDate").HasColumnType("datetime").IsRequired();

            //Foreign keys
            builder.HasOne(a => a.SalesPerson).WithMany(b => b.Stores).HasForeignKey(c => c.SalesPersonID).OnDelete(DeleteBehavior.Restrict); // FK_Store_SalesPerson_SalesPersonID
        }
    }
}

