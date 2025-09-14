# ChatApp

📡 **ChatApp**, SignalR tabanlı **gerçek zamanlı sohbet uygulaması**dır.  
Hem **WinForms Client (C# .NET 8)** hem de **Web API Server (ASP.NET Core + EF Core)** içerir.  

---

## 🚀 Özellikler
- 🔐 Kullanıcı Kayıt & Giriş (Auth)
- 💬 Gerçek zamanlı mesajlaşma (SignalR)
- 👥 Odalara Katılma (Random veya seçili)
- 📜 Mesaj geçmişi veritabanında saklanır
- 👤 Online kullanıcı listesi (oda bazlı)
- 🎨 Modern WinForms arayüz (ReaLTaiizor UI kütüphanesi)
- 📦 Dağıtım için **Setup (MSI)** projesi mevcut

---

## 🗂 Proje Yapısı
```
ChatApp/
│
├── Chat.Client         → WinForms Client (exe olarak dağıtılır)
├── Chat.Server         → ASP.NET Core Web API + SignalR Hub
├── Chat.Infrastructure → EF Core DbContext & Migrations
├── Chat.Domain         → Entity modelleri
├── Chat.Contracts      → Shared DTO’lar
└── ChatLiyoSetup       → MSI kurulum projesi
```

---

## ⚙️ Kullanılan Teknolojiler
- .NET 8
- ASP.NET Core Web API
- SignalR
- Entity Framework Core
- WinForms (ReaLTaiizor UI)
- MSSQL

---

## 📸 Ekran Görüntüleri

[Login] https://prnt.sc/l1jUmTiuGQqm
[Chat] https://prnt.sc/yWTWtXSme6AO


---

## 🔧 Kurulum
1. Repo’yu klonla:
   ```bash
   git clone https://github.com/Nevers01/ChatApp.git
   ```

2. **Server** tarafını çalıştır:
   ```bash
   cd Chat.Server
   dotnet run
   ```
   > Varsayılan port: **http://localhost:5000**

3. **Client** tarafını aç:
   - `Chat.Client` → **F5** ile çalıştırılabilir
   - veya `ChatLiyoSetup` → MSI kurup masaüstünden çalıştırabilirsin.

---

## 📝 Yol Haritası
- [ ] Web Client (Blazor/Web UI) desteği
- [ ] Emoji & Dosya gönderme
- [ ] JWT ile gerçek token tabanlı auth
- [ ] Docker compose (Server + DB)

---

## 👤 Yazar
**Alperen “NeversCoder” Dağül**  
📌 [YouTube](https://youtube.com/@neverscoder) | [GitHub](https://github.com/Nevers01) | [CodeBucks](https://codebucks.com.tr)
