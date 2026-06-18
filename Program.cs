using ProjectCompletionReport.Database;
using ProjectCompletionReport.Forms;

namespace ProjectCompletionReport;

static class Program
{
    [STAThread]
    static void Main()
    {
        DotNetEnv.Env.Load();
        DbInitializer.Initialize();

        ApplicationConfiguration.Initialize();
        Application.Run(new MainDashboard());
    }
}