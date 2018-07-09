using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Textures
{
    class Program
    {
        private static readonly double fixedUpdateInterval = 1.0 / 60.0;

        static void Main(string[] args)
        {
            MainWindow window = new MainWindow();

            window.Run(fixedUpdateInterval);
        }
    }
}
