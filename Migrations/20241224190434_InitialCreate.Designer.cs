﻿// <auto-generated />
using System;
using GestionCommandes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionCommandes.Migrations
{
    [DbContext(typeof(GestionCommandesContext))]
    [Migration("20241224190434_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GestionCommandes.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Prénom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("SoldeCompte")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Téléphone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("GestionCommandes.Models.Commande", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int?>("ComptableId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCommande")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Montant")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ResponsableStockRsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComptableId");

                    b.HasIndex("ResponsableStockRsId");

                    b.ToTable("Commandes");
                });

            modelBuilder.Entity("GestionCommandes.Models.Comptable", b =>
                {
                    b.Property<int>("ComptableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ComptableId");

                    b.ToTable("Comptables");
                });

            modelBuilder.Entity("GestionCommandes.Models.Historique", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CommandeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAction")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Historiques");
                });

            modelBuilder.Entity("GestionCommandes.Models.HistoriqueVersement", b =>
                {
                    b.Property<int>("HistoriqueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("CommandeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAction")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PaiementId")
                        .HasColumnType("int");

                    b.HasKey("HistoriqueId");

                    b.HasIndex("ClientId");

                    b.HasIndex("CommandeId");

                    b.HasIndex("PaiementId");

                    b.ToTable("HistoriquesVersements");
                });

            modelBuilder.Entity("GestionCommandes.Models.Livraison", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AdresseLivraison")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CommandeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateLivraison")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("LivreurId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LivreurId");

                    b.ToTable("Livraisons");
                });

            modelBuilder.Entity("GestionCommandes.Models.Livreur", b =>
                {
                    b.Property<int>("LivreurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("LivreurId");

                    b.ToTable("Livreurs");
                });

            modelBuilder.Entity("GestionCommandes.Models.Paiement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CommandeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Montant")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Référence")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Paiements");
                });

            modelBuilder.Entity("GestionCommandes.Models.Produit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Libellé")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("PrixUnitaire")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("QuantitéSeuil")
                        .HasColumnType("int");

                    b.Property<int>("QuantitéStock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Produits");
                });

            modelBuilder.Entity("GestionCommandes.Models.Remise", b =>
                {
                    b.Property<int>("RemiseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRemise")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Pourcentage")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("RemiseId");

                    b.HasIndex("ClientId");

                    b.ToTable("Remises");
                });

            modelBuilder.Entity("GestionCommandes.Models.ResponsableStock", b =>
                {
                    b.Property<int>("RsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RsId");

                    b.ToTable("ResponsablesStock");
                });

            modelBuilder.Entity("GestionCommandes.Models.Commande", b =>
                {
                    b.HasOne("GestionCommandes.Models.Comptable", null)
                        .WithMany("CommandesFacturees")
                        .HasForeignKey("ComptableId");

                    b.HasOne("GestionCommandes.Models.ResponsableStock", null)
                        .WithMany("CommandesPreparees")
                        .HasForeignKey("ResponsableStockRsId");
                });

            modelBuilder.Entity("GestionCommandes.Models.HistoriqueVersement", b =>
                {
                    b.HasOne("GestionCommandes.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionCommandes.Models.Commande", "Commande")
                        .WithMany()
                        .HasForeignKey("CommandeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionCommandes.Models.Paiement", "Paiement")
                        .WithMany()
                        .HasForeignKey("PaiementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Commande");

                    b.Navigation("Paiement");
                });

            modelBuilder.Entity("GestionCommandes.Models.Livraison", b =>
                {
                    b.HasOne("GestionCommandes.Models.Livreur", null)
                        .WithMany("Livraisons")
                        .HasForeignKey("LivreurId");
                });

            modelBuilder.Entity("GestionCommandes.Models.Remise", b =>
                {
                    b.HasOne("GestionCommandes.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("GestionCommandes.Models.Comptable", b =>
                {
                    b.Navigation("CommandesFacturees");
                });

            modelBuilder.Entity("GestionCommandes.Models.Livreur", b =>
                {
                    b.Navigation("Livraisons");
                });

            modelBuilder.Entity("GestionCommandes.Models.ResponsableStock", b =>
                {
                    b.Navigation("CommandesPreparees");
                });
#pragma warning restore 612, 618
        }
    }
}