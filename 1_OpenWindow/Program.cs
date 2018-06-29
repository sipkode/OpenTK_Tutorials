using OpenTK;

namespace _1_OpenWindow
{
    class Program : GameWindow
    {
        // OpenGL Initialization Variables
        private static int frameWidth = 640;
        private static int frameHeight = 480;

        private static double fixedUpdateInterval = 1.0 / 60.0;

        static void Main(string[] args)
        {
            GameWindow window = new GameWindow(frameWidth, frameHeight);

            window.Run(fixedUpdateInterval);
        }
    }
}
