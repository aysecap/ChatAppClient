namespace ChatApp
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            for (int i = 0; i < 1; i++)
            {
                new Form1().Show(); 
                Thread.Sleep(100);
            }
           
            Application.Run(new Form1());
            ApplicationConfiguration.Initialize();

        }
    }
}
