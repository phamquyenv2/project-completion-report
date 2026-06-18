
**Bước 1:** Mở file `.env` và điền:
- `DB_SERVER=`: Tên SQL Server trên máy bạn (vd: `.\SQLEXPRESS`)
- `DB_USER=` và `DB_PASSWORD=`: Điền tài khoản/mật khẩu SQL của bạn.

- (Nếu bạn không dùng User/Pass mà xài Windows Authentication, hãy mở file `Database/DbConnectionFactory.cs` và thay thế đoạn `User Id={UserId};Password={Password}` thành `Integrated Security=True`)

**Bước 2:** Mở Terminal, trỏ vào thư mục code và chạy:
```bash
cd project-completion-report
dotnet run
```
*(Lưu ý: Database và dữ liệu mẫu sẽ được tạo hoàn toàn tự động khi app khởi động, không cần chạy file SQL bằng tay).*