﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    class Account
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public double Balance { get; set; }

        public double GetBalance()
        {
            return Balance;
        }
    }
}
