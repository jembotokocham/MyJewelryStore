﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyJewelryStore.Models;

namespace MyJewelryStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MyJewelryStore.Models.NewProduct> NewProduct { get; set; }
        public DbSet<MyJewelryStore.Models.Order> Order { get; set; }
        public DbSet<MyJewelryStore.Models.Status> Status { get; set; }
    }
}