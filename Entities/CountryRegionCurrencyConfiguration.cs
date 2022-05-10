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
    
    
    public class CountryRegionCurrencyConfiguration : IEntityTypeConfiguration<CountryRegionCurrency> {
        
        private string _schema = "Sales";
        
        public virtual void Configure(EntityTypeBuilder<CountryRegionCurrency> builder) {
            Configure(builder, _schema);
        }
        
        private void Configure(EntityTypeBuilder<CountryRegionCurrency> builder, string schema) {
            builder.ToTable("CountryRegionCurrency", schema);
            builder.HasKey(x => new { x.CountryRegionCode, x.CurrencyCode });

            builder.Property(x => x.CountryRegionCode).HasColumnName(@"CountryRegionCode").HasColumnType("nvarchar").IsRequired().HasMaxLength(3);
            builder.Property(x => x.CurrencyCode).HasColumnName(@"CurrencyCode").HasColumnType("nchar").IsRequired().IsFixedLength().HasMaxLength(3);
            builder.Property(x => x.ModifiedDate).HasColumnName(@"ModifiedDate").HasColumnType("datetime").IsRequired();

            //Foreign keys
            builder.HasOne(a => a.Currency).WithMany(b => b.CountryRegionCurrencies).HasForeignKey(c => c.CurrencyCode).OnDelete(DeleteBehavior.Restrict); // FK_CountryRegionCurrency_Currency_CurrencyCode
        }
    }
}
