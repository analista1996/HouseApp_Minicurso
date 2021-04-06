using System;
using System.Collections.Generic;
using System.Text;

namespace HouseModel.Models.Resume_
{
    public class Resume
    {
        public int User_Id { get; set; }

        public double Total_Spends { get; set; }
        public double Total_Save { get; set; }
        public int Total_Times { get; set; }

        public List<string> P_used { get; set; }

        public double I_Budget { get; set; }
        public double F_Budget { get; set; }


    }
}
