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
    
    
    public class SalesPersonConfiguration : IEntityTypeConfiguration<SalesPerson> {
        
        private string _schema = "Sales";
        
        public virtual void Configure(EntityTypeBuilder<SalesPerson> builder) {
            Configure(builder, _schema);
        }
        
        private void Configure(EntityTypeBuilder<SalesPerson> builder, string schema) {
            builder.ToTable("SalesPerson", schema);
            builder.HasKey(x => x.BusinessEntityID);

            builder.Property(x => x.BusinessEntityID).HasColumnName(@"BusinessEntityID").HasColumnType("int").IsRequired();
            builder.Property(x => x.TerritoryID).HasColumnName(@"TerritoryID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.SalesQuota).HasColumnName(@"SalesQuota").HasColumnType("money").IsRequired(false).HasColumnType("decimal19,4)");
            builder.Property(x => x.Bonus).HasColumnName(@"Bonus").HasColumnType("money").IsRequired().HasColumnType("decimal19,4)");
            builder.Property(x => x.CommissionPct).HasColumnName(@"CommissionPct").HasColumnType("smallmoney").IsRequired().HasColumnType("decimal10,4)");
            builder.Property(x => x.SalesYTD).HasColumnName(@"SalesYTD").HasColumnType("money").IsRequired().HasColumnType("decimal19,4)");
            builder.Property(x => x.SalesLastYear).HasColumnName(@"SalesLastYear").HasColumnType("money").IsRequired().HasColumnType("decimal19,4)");
            builder.Property(x => x.Rowguid).HasColumnName(@"rowguid").HasColumnType("uniqueidentifier").IsRequired().ValueGeneratedOnAddOrUpdate();
            builder.Property(x => x.ModifiedDate).HasColumnName(@"ModifiedDate").HasColumnType("datetime").IsRequired();

            //Foreign keys
            builder.HasOne(a => a.SalesTerritory).WithMany(b => b.SalesPersons).HasForeignKey(c => c.TerritoryID).OnDelete(DeleteBehavior.Restrict); // FK_SalesPerson_SalesTerritory_TerritoryID
        }
    }
}

