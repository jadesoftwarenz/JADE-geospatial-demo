using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using JadeSoftware.Joob.Client;

namespace JoobSpatialDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (new JoobContext())
            {
                Application.Run(new MainForm());
            }
        }
    }
}
