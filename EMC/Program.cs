using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EMC
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }

    public static class UpdateEvent
    {
        public delegate void UpdateEventHandler();
        public static UpdateEventHandler save;
    }

    public static class CallBackMy
    {
        public delegate void callbackEvent(DataGridView dgv);
        public static callbackEvent callbackEventHandler;
    }


}
