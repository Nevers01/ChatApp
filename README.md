ChatApp

📡 ChatApp, SignalR tabanlı gerçek zamanlı sohbet uygulamasıdır.
Hem WinForms Client (C# .NET 8) hem de Web API Server (ASP.NET Core + EF Core) içerir.

🚀 Özellikler

🔐 Kullanıcı Kayıt & Giriş (Auth)

💬 Gerçek zamanlı mesajlaşma (SignalR)

👥 Odalara Katılma (Random veya seçili)

📜 Mesaj geçmişi DB’de saklanır

👤 Online kullanıcı listesi (oda bazlı)

🎨 Modern WinForms arayüz (ReaLTaiizor UI kütüphanesi)

📦 Dağıtım için Setup (MSI) projesi mevcut

🗂 Proje Yapısı
ChatApp/
│
├── Chat.Client         → WinForms Client (exe olarak dağıtılır)
├── Chat.Server         → ASP.NET Core Web API + SignalR Hub
├── Chat.Infrastructure → EF Core DbContext & Migrations
├── Chat.Domain         → Entity modelleri
├── Chat.Contracts      → Shared DTO’lar
└── ChatLiyoSetup       → MSI kurulum projesi

⚙️ Kullanılan Teknolojiler

.NET 8

ASP.NET Core Web API

SignalR

Entity Framework Core

WinForms (ReaLTaiizor UI)

MSSQL

📸 Ekran Görüntüleri

(buraya senin attığın login form, chat ekranı screenshotlarını ekleyebiliriz)

🔧 Kurulum

Repo’yu klonla:

git clone https://github.com/Nevers01/ChatApp.git


Server tarafını çalıştır:

cd Chat.Server
dotnet run


Varsayılan port: http://localhost:5000

Client tarafını aç:

Chat.Client → F5 ile çalıştırabilir

veya ChatLiyoSetup → MSI kurup masaüstünden çalıştırabilirsin.

📝 Yol Haritası

 Web Client (Blazor/Web UI) desteği

 Emoji & Dosya gönderme

 JWT ile gerçek token tabanlı auth

 Docker compose (Server + DB)

👤 Yazar

Alperen “NeversCoder” Dagül
📌 YouTube
 | GitHub
 | CodeBucks
