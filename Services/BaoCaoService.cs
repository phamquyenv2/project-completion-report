using ProjectCompletionReport.Models;
using ProjectCompletionReport.Repositories;

namespace ProjectCompletionReport.Services
{
    public class BaoCaoService
    {
        private readonly BaoCaoDuAnRepository _duAnRepo = new();
        private readonly BaoCaoNhanVienRepository _nvRepo = new();

        // ── Dự án ──

        public List<BaoCaoTyLeHoanThanhDuAn> LayTatCaDuAn()
            => _duAnRepo.GetBaoCaoDuAn();

        public BaoCaoTyLeHoanThanhDuAn? LayDuAnTheoMaHD(string maHD)
            => _duAnRepo.GetByMaHD(maHD);

        // ── Nhân viên ──

        public List<BaoCaoTyLeHoanThanhNhanVien> LayTatCaNhanVien()
            => _nvRepo.GetAll();

        public List<BaoCaoTyLeHoanThanhNhanVien> LayNhanVienTheoMaHD(string maHD)
            => _nvRepo.GetByMaHD(maHD);

        // ── Lấy danh sách mã hợp đồng (cho ComboBox) ──

        public List<string> LayDanhSachMaHD()
            => LayTatCaDuAn().Select(x => x.MA_HD).ToList();
    }
}
