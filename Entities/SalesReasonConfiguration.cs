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
    
    
    public class SalesReasonConfiguration : IEntityTypeConfiguration<SalesReason> {
        
        private string _schema = "Sales";
        
        public virtual void Configure(EntityTypeBuilder<SalesReason> builder) {
            Configure(builder, _schema);
        }
        
        private void Configure(EntityTypeBuilder<SalesReason> builder, string schema) {
            builder.ToTable("SalesReason", schema);
            builder.HasKey(x => x.SalesReasonID);

            builder.Property(x => x.SalesReasonID).HasColumnName(@"SalesReasonID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasColumnName(@"Name").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            builder.Property(x => x.ReasonType).HasColumnName(@"ReasonType").HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            builder.Property(x => x.ModifiedDate).HasColumnName(@"ModifiedDate").HasColumnType("datetime").IsRequired();

            //Foreign keys
        }
    }
}

