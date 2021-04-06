using HouseModel.Models.User_;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HouseModel.Models.Budget_
{
   public class Budget
    {
        [Key]
        public int Budget_Id { get; set; }
        [ForeignKey("Users")]
        public int User_Id { get; set; }

        public User Users { get; set; }

        public double Montly_value { get; set; }

    }
}
