using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HouseModel.Models.Pay_M
{
    public class Payment_M
    {
        [Key]
        public int P_Id { get; set; }
        public string Name { get; set; }

    }

}
