using HouseModel.Models.Pay_M;
using HouseModel.Models.User_;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HouseModel.Models.Spends_
{
    public class Spends
    {
        [Key]
        public int Spend_Id { get; set; }
        [ForeignKey("Users")]
        public int User_Id { get; set; }
        [ForeignKey("Payment_Ms")]
        public int P_Id { get; set; }

        public double Spend_Value { get; set; }
        public string Description { get; set; }

        public DateTime Spend_date { get; set; }

        public User Users { get; set; }
        public Payment_M Payment_Ms { get; set; }
    }
}
