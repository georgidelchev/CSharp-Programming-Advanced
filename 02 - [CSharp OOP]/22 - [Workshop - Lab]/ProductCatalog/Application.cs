using System;
using System.Collections.Generic;
using System.Text;
using ProductCatalog.Utilities;

namespace ProductCatalog
{
    public class Application
    {
        private readonly Menu menu;

        public Application(Menu menu)
        {
            this.menu = menu;
        }



        public void Run(string[] args)
        {
            bool running = true;

            while (running)
            {
                running = menu.MainMenu();
            }
        }
    }
}
