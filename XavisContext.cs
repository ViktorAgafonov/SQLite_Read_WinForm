using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WinFormsApp2;

public partial class XavisContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=TestDB.db3");

    protected override void OnModelCreating(ModelBuilder modelBuild)
    {
        modelBuild.Entity<TbModelInfo>(entity =>
        {
            entity.HasKey(e => e.ModelUid);
            entity.ToTable("TB_MODEL_INFO");

            entity.Property(e => e.ModelUid)
                .ValueGeneratedNever()
                .HasColumnName("MODEL_UID");

            entity.Property(e => e.ModelName)
                .HasColumnName("MODEL_NAME");
        });

        modelBuild.Entity<TbProductDatum>(entity =>
        {
            entity.HasKey(e => e.ProductDataUid);
            entity.ToTable("TB_PRODUCT_DATA");

            entity.Property(e => e.ProductDataUid)
                .ValueGeneratedNever()
                .HasColumnName("PRODUCT_DATA_UID");

            entity.Property(e => e.ModelUid)
                .HasColumnType("numeric")
                .HasColumnName("MODEL_UID");
        });

        modelBuild.Entity<TbInspUnitDatum>(entity =>
        {
            entity.HasKey(e => e.UnitDataUid);
            entity.ToTable("TB_INSP_UNIT_DATA");

            entity.Property(e => e.UnitDataUid)
                .ValueGeneratedNever()
                .HasColumnName("UNIT_DATA_UID");

            entity.Property(e => e.InspUse)
                .HasColumnType("numeric")
                .HasColumnName("INSP_USE");

            entity.Property(e => e.UnitName).HasColumnName("UNIT_NAME");

            entity.Property(e => e.UnitUid)
                .HasColumnType("numeric")
                .HasColumnName("UNIT_UID");
        });

        modelBuild.Entity<TbSettingValue>(entity =>
        {
            entity.HasKey(e => e.SettingUid);
            entity.ToTable("TB_SETTING_VALUE");

            entity.Property(e => e.SettingUid)
                .ValueGeneratedNever()
                .HasColumnName("SETTING_UID");

            entity.Property(e => e.ProductDataUid)
                .HasColumnType("numeric")
                .HasColumnName("PRODUCT_DATA_UID");

            entity.Property(e => e.SettingIndex)
                .HasColumnType("numeric")
                .HasColumnName("SETTING_INDEX");

            entity.Property(e => e.SettingValue)
                .HasColumnType("numeric")
                .HasColumnName("SETTING_VALUE");

            entity.Property(e => e.UnitUid)
                .HasColumnType("numeric")
                .HasColumnName("UNIT_UID");
        });
    }

    public virtual DbSet<TbModelInfo> TbModelInfos { get; set; }
    public virtual DbSet<TbProductDatum> TbProductData { get; set; }
    public virtual DbSet<TbInspUnitDatum> TbInspUnitData { get; set; }
    public virtual DbSet<TbSettingValue> TbSettingValues { get; set; }

    


}
