﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yacht_club
{
    class Device
    {
        public int id { get; set; }
        public string tipus { get; set; }
        public int napi_ar { get; set; }
        public int login_id { get; set; }
        public int max_hossz { get; set; }
        public int max_magas { get; set; }
        public int max_suly { get; set; }
        public int max_szeles { get; set; }
        public bool foglalt { get; set; }
        public bool berelheto { get; set; }
    }
}
