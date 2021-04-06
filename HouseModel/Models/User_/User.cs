using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HouseModel.Models.User_
{
  public  class User
  {
        [Key]
        public int User_Id { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
