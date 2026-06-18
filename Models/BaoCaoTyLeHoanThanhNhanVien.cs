namespace ProjectCompletionReport.Models
{
    public class BaoCaoTyLeHoanThanhNhanVien
    {
        public int ID { get; set; }

        public string MA_HD { get; set; } = string.Empty;

        public string MA_NV { get; set; } = string.Empty;

        public int SL_TASK_HT { get; set; }

        public int SL_TASK_CHT { get; set; }

        public double TY_LE_HT { get; set; }

        public double TY_LE_CHT { get; set; }

        public string MA_SP { get; set; } = string.Empty;

        public int SL_TASK { get; set; }
    }
}
