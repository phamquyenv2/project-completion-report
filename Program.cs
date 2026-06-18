using ProjectCompletionReport.Database;
using ProjectCompletionReport.Forms;

namespace ProjectCompletionReport;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // Load biến môi trường từ file .env
        DotNetEnv.Env.Load();

        // Khởi tạo database + seed dữ liệu mẫu
        DbInitializer.Initialize();

        ApplicationConfiguration.Initialize();
        Application.Run(new MainDashboard());
    }
}