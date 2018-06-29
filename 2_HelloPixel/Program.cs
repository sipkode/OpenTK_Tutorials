using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace _2_HelloTriangle
{
    public class Program
    {
        private static readonly double fixedUpdateInterval = 1.0 / 60.0;

        static void Main(string[] args)
        {
            MainWindow window = new MainWindow();

            window.Run(fixedUpdateInterval);
        }
    }
}
