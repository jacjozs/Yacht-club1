﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Windows.Media;
using Yacht_club.Moduls;

namespace Yacht_club.UsingControls
{
    /// <summary>
    /// Interaction logic for ucBeallitasok.xaml
    /// </summary>
    public partial class ucBeallitasok : UserControl
    {
        private string filepath = "";
        private int theme;
        private Felhasznalo user;
        private Themes tema;

        private Database.MysqlSetting data;
        public ucBeallitasok()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Kép tallozás és az elérésiút mentése valamint kiírása a textbox-ba
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btkep_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "C:\\";
            open.Filter = "Image Files(*.PNG;*.JPG;*.JPEG;*.BMP;*.GIF)|*.PNG;*.JPG;*.JPEG;*.BMP;*.GIF";
            open.FilterIndex = 1;
            Nullable<bool> dialogok = open.ShowDialog();

            if (dialogok == true)
            {
                filepath = open.FileName;
                tbKep.Text = filepath;
            }
        }
        /// <summary>
        /// Elküldi az adatbázis interface-nek a kész felhasználó objectumot a frisitésre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btAlkalmaz_Click(object sender, RoutedEventArgs e)
        {
            user = new Felhasznalo();
            try
            {
                user = Globals.User;
                user.login = Globals.User.login;
                user.login.theme = theme;
                if (tbNickName.Text != "") user.nickname = tbNickName.Text;
                if (tbFirstName.Text != "") user.veztek_nev = tbFirstName.Text;
                if (tbLastName.Text != "") user.kereszt_nev = tbLastName.Text;
                if (tbVaros.Text != "") user.varos = tbVaros.Text;
                if (tbIranyitoszm.Text != "") user.iranyitoszm = int.Parse(tbIranyitoszm.Text);
                if (tbLakcim.Text != "") user.lakcim = tbLakcim.Text;
                if (tbOrszag.Text != "") user.orszag = tbOrszag.Text;
                if (pbPasswd.Password != "" && passwdEllenorzes(pbOldPasswd.Password, pbPasswd.Password, pbRePasswd.Password)) user.login.jelszo = pbPasswd.Password;
                if (tbEmail.Text != "") user.login.email = tbEmail.Text;
                if (filepath != "") user.kep = System.Drawing.Image.FromFile(filepath);

                data = new Database.MysqlSetting();
                if (user != null)
                {
                    data.MysqlUpdateUser(user);
                    data.MysqlUpdateUserLogin(user.login);
                }
                if (Globals.OldThemeId != Globals.MainTheme.id)
                {
                    Globals.OldThemeId = Globals.MainTheme.id;
                    MainWindowRefersh();
                }
            }
            catch (Exception)
            {
                Globals.log = "Módosítás Sikertelen! <Beállitások>";
            }
            finally
            {
                Globals.Main.lbNickname.Content = user.nickname + "!";
            }
            Globals.User = user;
            Globals.log = "Módosítás Sikeres! <Beállitások>";
            Globals.Main.logAdd(true);
        }

        private bool passwdEllenorzes(string regi, string uj, string reUj)
        {
            if (regi == Globals.User.login.jelszo && uj == reUj) return true;
            return false;
        }

        public void logining()
        {
            tbNickName.Text = Globals.User.nickname;
            tbFirstName.Text = Globals.User.veztek_nev;
            tbLastName.Text = Globals.User.kereszt_nev;
            tbVaros.Text = Globals.User.varos;
            tbIranyitoszm.Text = Globals.User.iranyitoszm.ToString();
            tbLakcim.Text = Globals.User.lakcim;
            tbOrszag.Text = Globals.User.orszag;
            tbEmail.Text = Globals.User.login.email;
        }

        private void Theme_Color(object sender, MouseButtonEventArgs e)
        {
            Image Themes = (Image)sender;
            switch (Themes.Name.ToString())
            {
                case "image1":
                    tema = new Themes(1);
                    Globals.MainTheme = tema;
                    theme = 1;
                    break;
                case "image2":
                    tema = new Themes(2);
                    Globals.MainTheme = tema;
                    theme = 2;
                    break;
                case "image3":
                    tema = new Themes(3);
                    Globals.MainTheme = tema;
                    theme = 3;
                    break;
                case "image4":
                    tema = new Themes(4);
                    Globals.MainTheme = tema;
                    theme = 4;
                    break;
                case "image5":
                    tema = new Themes(5);
                    Globals.MainTheme = tema;
                    theme = 5;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// A main ablak frissitése és a kinézetbeli változások alkalmazása
        /// </summary>
        private void MainWindowRefersh()
        {
            //Ha lehet kellene rá keresni egy takarékosabb megoldást
            Application.Current.ShutdownMode = ShutdownMode.OnLastWindowClose;
            //Új szinek beolvasása egy új main ablakba
            Main_Yacht_Window newWin = new Main_Yacht_Window();
            //az új ablaknak átadni az eddigi usercontorlokat
            newWin.ccWindow_2.Content = Globals.Main.ccWindow_2.Content;
            newWin.ccWindow_1.Content = Globals.Main.ccWindow_1.Content;
            if (Globals.User.login.admin)
                newWin.dpRegist.Visibility = Visibility.Visible;
            Globals.Main.Hide();
            Globals.Main = newWin;
            Globals.Main.Show();
        }
    }
}
