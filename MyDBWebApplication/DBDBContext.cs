using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MyDBWebApplication.Models;

namespace MyDBWebApplication
{
    public partial class DBDBContext : DbContext
    {
        public DBDBContext()
        {
        }

        public DBDBContext(DbContextOptions<DBDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cell> Cells { get; set; } = null!;
        public virtual DbSet<Column> Columns { get; set; } = null!;
        public virtual DbSet<DataType> DataTypes { get; set; } = null!;
        public virtual DbSet<Database> Databases { get; set; } = null!;
        public virtual DbSet<Row> Rows { get; set; } = null!;
        public virtual DbSet<Table> Tables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= WIN-VCDRI1UG58U; Database=DBDB; Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cell>(entity =>
            {
                entity.HasOne(d => d.Column)
                    .WithMany(p => p.Cells)
                    .HasForeignKey(d => d.ColumnId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cells_Columns");

                entity.HasOne(d => d.Row)
                    .WithMany(p => p.Cells)
                    .HasForeignKey(d => d.RowId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cells_Rows");
            });

            modelBuilder.Entity<Column>(entity =>
            {
                entity.HasOne(d => d.DataType)
                    .WithMany(p => p.Columns)
                    .HasForeignKey(d => d.DataTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Columns_DataTypes");

                entity.HasOne(d => d.Table)
                    .WithMany(p => p.Columns)
                    .HasForeignKey(d => d.TableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Columns_Tables");
            });

            modelBuilder.Entity<Row>(entity =>
            {
                entity.HasOne(d => d.Table)
                    .WithMany(p => p.Rows)
                    .HasForeignKey(d => d.TableId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rows_Tables");
            });

            modelBuilder.Entity<Table>(entity =>
            {
                entity.HasOne(d => d.Database)
                    .WithMany(p => p.Tables)
                    .HasForeignKey(d => d.DatabaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tables_Databases");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
