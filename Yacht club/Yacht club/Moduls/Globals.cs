﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Yacht_club.Moduls;

namespace Yacht_club
{
    /// <summary>
    /// Globális adatok a könnyeb adat elérésért
    /// </summary>
    public static class Globals
    {
        public static string log = "";
        public static int OldThemeId;
        public static UsingControls.ucErtesitesek log_windows = new UsingControls.ucErtesitesek();
        public static MySqlConnection connect = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=gamfyachtclub");
        public static Main_Yacht_Window Main;
        internal static Themes MainTheme;
        internal static Felhasznalo User;
        internal static Yacht selectedYacht;
        internal static Device selectedDevice;
    }
}
