using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.Collections;
using TDR7K.View;
using TDR7K.Controller;
namespace TDR7K
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            UserView view = new UserView();
            AppController usrController = new AppController(view);
            view.ShowDialog();
          
        }
    }
}
