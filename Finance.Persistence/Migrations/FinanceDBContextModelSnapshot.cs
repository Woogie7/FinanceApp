﻿// <auto-generated />
using System;
using Finance.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Finance.Persistence.Migrations
{
    [DbContext(typeof(FinanceDBContext))]
    partial class FinanceDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Finance.Domain.Entities.CategoryExpense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryExpenseName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CategoryExpenses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryExpenseName = "Еда"
                        },
                        new
                        {
                            Id = 2,
                            CategoryExpenseName = "Транспорт"
                        },
                        new
                        {
                            Id = 3,
                            CategoryExpenseName = "Одежда"
                        },
                        new
                        {
                            Id = 4,
                            CategoryExpenseName = "Развлечения"
                        },
                        new
                        {
                            Id = 5,
                            CategoryExpenseName = "Образование"
                        },
                        new
                        {
                            Id = 6,
                            CategoryExpenseName = "Здоровье"
                        },
                        new
                        {
                            Id = 7,
                            CategoryExpenseName = "КоммунальныеУслуги"
                        },
                        new
                        {
                            Id = 8,
                            CategoryExpenseName = "Кредиты"
                        },
                        new
                        {
                            Id = 9,
                            CategoryExpenseName = "ДомашниеЖивотные"
                        },
                        new
                        {
                            Id = 10,
                            CategoryExpenseName = "Путешествия"
                        },
                        new
                        {
                            Id = 11,
                            CategoryExpenseName = "ЛичныеРасходы"
                        },
                        new
                        {
                            Id = 12,
                            CategoryExpenseName = "Благотворительность"
                        },
                        new
                        {
                            Id = 13,
                            CategoryExpenseName = "Абонементы"
                        },
                        new
                        {
                            Id = 14,
                            CategoryExpenseName = "Подарок"
                        },
                        new
                        {
                            Id = 15,
                            CategoryExpenseName = "Другое"
                        });
                });

            modelBuilder.Entity("Finance.Domain.Entities.CategoryIncome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryIncomeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CategoryIncomes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryIncomeName = "Зарплата"
                        },
                        new
                        {
                            Id = 2,
                            CategoryIncomeName = "Премия"
                        },
                        new
                        {
                            Id = 3,
                            CategoryIncomeName = "Подработка"
                        },
                        new
                        {
                            Id = 4,
                            CategoryIncomeName = "Дивиденды"
                        },
                        new
                        {
                            Id = 5,
                            CategoryIncomeName = "Проценты"
                        },
                        new
                        {
                            Id = 6,
                            CategoryIncomeName = "Подарки"
                        },
                        new
                        {
                            Id = 7,
                            CategoryIncomeName = "Продажа"
                        },
                        new
                        {
                            Id = 8,
                            CategoryIncomeName = "СдачаВАренду"
                        },
                        new
                        {
                            Id = 9,
                            CategoryIncomeName = "СоциальныеВыплаты"
                        },
                        new
                        {
                            Id = 10,
                            CategoryIncomeName = "Пенсия"
                        },
                        new
                        {
                            Id = 11,
                            CategoryIncomeName = "Стипендия"
                        },
                        new
                        {
                            Id = 12,
                            CategoryIncomeName = "ВозвратДолгов"
                        },
                        new
                        {
                            Id = 13,
                            CategoryIncomeName = "ДругиеДоходы"
                        });
                });

            modelBuilder.Entity("Finance.Domain.Entities.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CurrencyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrencyName = "RUB"
                        },
                        new
                        {
                            Id = 2,
                            CurrencyName = "USD"
                        },
                        new
                        {
                            Id = 3,
                            CurrencyName = "EUR"
                        });
                });

            modelBuilder.Entity("Finance.Domain.Entities.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("CategoryExpenseId")
                        .HasColumnType("integer");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CategoryExpenseId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("Finance.Domain.Entities.Income", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("CategoryIncomeId")
                        .HasColumnType("integer");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("integer");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CategoryIncomeId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Incomes");
                });

            modelBuilder.Entity("Finance.Domain.Entities.Users.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Permission");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Read"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Create"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Update"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Delete"
                        });
                });

            modelBuilder.Entity("Finance.Domain.Entities.Users.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("Finance.Domain.Entities.Users.RolePermissions", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int>("PermissionId")
                        .HasColumnType("integer");

                    b.HasKey("RoleId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("RolePermissions");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            PermissionId = 2
                        },
                        new
                        {
                            RoleId = 1,
                            PermissionId = 1
                        },
                        new
                        {
                            RoleId = 1,
                            PermissionId = 3
                        },
                        new
                        {
                            RoleId = 1,
                            PermissionId = 4
                        },
                        new
                        {
                            RoleId = 2,
                            PermissionId = 1
                        });
                });

            modelBuilder.Entity("Finance.Domain.Entities.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Finance.Domain.Entities.Expense", b =>
                {
                    b.HasOne("Finance.Domain.Entities.CategoryExpense", "Category")
                        .WithMany("Expenses")
                        .HasForeignKey("CategoryExpenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Finance.Domain.Entities.Currency", "Currency")
                        .WithMany("Expenses")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("Finance.Domain.Entities.Income", b =>
                {
                    b.HasOne("Finance.Domain.Entities.CategoryIncome", "Category")
                        .WithMany("Incomes")
                        .HasForeignKey("CategoryIncomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Finance.Domain.Entities.Currency", "Currency")
                        .WithMany("Incomes")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("Finance.Domain.Entities.Users.RolePermissions", b =>
                {
                    b.HasOne("Finance.Domain.Entities.Users.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Finance.Domain.Entities.Users.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Finance.Domain.Entities.Users.User", b =>
                {
                    b.HasOne("Finance.Domain.Entities.Users.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Finance.Domain.Entities.CategoryExpense", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("Finance.Domain.Entities.CategoryIncome", b =>
                {
                    b.Navigation("Incomes");
                });

            modelBuilder.Entity("Finance.Domain.Entities.Currency", b =>
                {
                    b.Navigation("Expenses");

                    b.Navigation("Incomes");
                });

            modelBuilder.Entity("Finance.Domain.Entities.Users.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
