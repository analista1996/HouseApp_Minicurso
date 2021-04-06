using HouseModel.Models.Budget_;
using HouseModel.Models.Pay_M;
using HouseModel.Models.Spends_;
using HouseModel.Models.User_;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HouseDataAcess.housecontext
{
    public class housecontext_: DbContext
    {
        public housecontext_(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Payment_M> Payment_Ms { get; set; }

        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Spends> Spends { get; set; }
        
    }
}
