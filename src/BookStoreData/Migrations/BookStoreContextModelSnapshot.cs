﻿// <auto-generated />
using BookStoreData.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStoreData.Migrations
{
    [DbContext(typeof(BookStoreContext))]
    partial class BookStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookAuthor", b =>
                {
                    b.Property<long>("BookId")
                        .HasColumnType("bigint");

                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint");

                    b.HasKey("BookId", "AuthorId")
                        .HasName("PK__BookAuth__6AED6DC42C1F7131");

                    b.HasIndex("AuthorId");

                    b.ToTable("BookAuthor");
                });

            modelBuilder.Entity("BookStoreData.Data.Author", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NAME");

                    b.HasKey("Id")
                        .HasName("PK__Author__3214EC079F0D096D");

                    b.ToTable("Author", (string)null);
                });

            modelBuilder.Entity("BookStoreData.Data.AuthorContact", b =>
                {
                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ContactNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("AuthorId")
                        .HasName("PK__AuthorCo__70DAFC34BB6D7ABF");

                    b.ToTable("AuthorContact", (string)null);
                });

            modelBuilder.Entity("BookStoreData.Data.Book", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PublisherId")
                        .HasColumnType("bigint");

                    b.Property<string>("ShortDescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValueSql("(N'')");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id")
                        .HasName("PK__Book__3214EC07BC54CD5B");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Book", (string)null);
                });

            modelBuilder.Entity("BookStoreData.Data.BookCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NAME");

                    b.HasKey("Id")
                        .HasName("PK__BookCate__3214EC07ACCB2FEF");

                    b.ToTable("BookCategory", (string)null);
                });

            modelBuilder.Entity("BookStoreData.Data.Publisher", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("NAME");

                    b.HasKey("Id")
                        .HasName("PK__Publishe__3214EC07772C2D3E");

                    b.ToTable("Publisher", (string)null);
                });

            modelBuilder.Entity("BookStoreData.Data.Review", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("BookId")
                        .HasColumnType("bigint");

                    b.Property<string>("ReviewText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "BookId" }, "IX_Review_BookId");

                    b.ToTable("Review", (string)null);
                });

            modelBuilder.Entity("BookAuthor", b =>
                {
                    b.HasOne("BookStoreData.Data.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .IsRequired()
                        .HasConstraintName("FK__BookAutho__Autho__31EC6D26");

                    b.HasOne("BookStoreData.Data.Book", null)
                        .WithMany()
                        .HasForeignKey("BookId")
                        .IsRequired()
                        .HasConstraintName("FK__BookAutho__BookI__30F848ED");
                });

            modelBuilder.Entity("BookStoreData.Data.AuthorContact", b =>
                {
                    b.HasOne("BookStoreData.Data.Author", "Author")
                        .WithOne("AuthorContact")
                        .HasForeignKey("BookStoreData.Data.AuthorContact", "AuthorId")
                        .IsRequired()
                        .HasConstraintName("FK__AuthorCon__Autho__2E1BDC42");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("BookStoreData.Data.Book", b =>
                {
                    b.HasOne("BookStoreData.Data.BookCategory", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK__Book__CategoryId__2F10007B");

                    b.HasOne("BookStoreData.Data.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .IsRequired()
                        .HasConstraintName("FK__Book__PublisherI__300424B4");

                    b.Navigation("Category");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("BookStoreData.Data.Review", b =>
                {
                    b.HasOne("BookStoreData.Data.Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookStoreData.Data.Author", b =>
                {
                    b.Navigation("AuthorContact");
                });

            modelBuilder.Entity("BookStoreData.Data.Book", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("BookStoreData.Data.BookCategory", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookStoreData.Data.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
