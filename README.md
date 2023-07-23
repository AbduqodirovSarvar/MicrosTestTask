# MicrosTestTask

  # # Loyiha haqida
  Bu loyiha bir oilaning umumiy daromadlari va harajatlarini nazorat qilishda yordam beruvchi web dastur. Bunda har bir oila a'zosi uchun alohida akount mavjud bo'ladi va har bir a'zo o'zining daromadlari(oylik ish haqi, ijara daromadlar va boshqalar) va harajatlarini(ovqatlanishi, transport, aloqa, internet, ko'ngilochar va boshqalar) tizimga kiritib boradi. Bu dasturda oilaga yangi a'zo qo'shish va o'chirish faqat admin orqali amalga oshiriladi. Boshlang'ich holatda adminning 
{ 
  "FirstName": "Admin"
  "Password": "DefaultAdminPassword"
}
bo'ladi. Bu ma'lumotlarni adminning akountiga kirgan holda bemalol o'zgartirish mumkin. Bunda oila a'zosining ismi(FirstName) takrorlanmas(Unique) bo'ladi. 

  # Loyihani ishga tushurish
  Loyihani ishga tushurish uchun siz avvalo .NetSDK va .Net Runtime ni komputeringizga o'rnatishingiz kerak.
.NetSDK : "https://dotnet.microsoft.com/en-us/download/visual-studio-sdks"
.NetRuntime : "https://dotnet.microsoft.com/en-us/download/dotnet-framework"  ushbu saytlardan yuklab olishingiz mumkin.
Bu dasturning Malumotlar bazasi PostgreSql da bo'lgani uchun sizda PostgreSql ham o'rnatilgan bo'lishi kerak.
Agar sizda postgresql bo'lsa MicrosTestTask/Micros.Api/appsettings.json fayliga kirib 
"ConnectionStrings": {
    "DefaultConnection": "Server=127.0.0.1;Port=5432;Database=Your_Database_Name;User Id=postgres;Password=Your_Password;"
  },
o'z bazangiz malumotlari bilan almashtirishingiz kerak.
Keyin terminaldan "dotnet ef database update" buyrugi orqali mavjud migration asosida bazani yangilashingiz kerak boladi.
So'ng esa Micros.Api papkasiga kirgan holda terminaldan "dotnet run" buyrugi orqali loyihani ishga tushurasiz.
"https://localhost:7258/swagger/index.html" yoki "http://localhost:5036/swagger/index.html" orqali swagerga kirishingiz mumkin.

  # Loyiha API laridan foydalanish
1. "https://localhost:7258/api/Authorize/Login" bunga HttpPost metodidan foydalanib 
{
  "firstName": "Sarvar",
  "password": "12345"
}
ushbu jsonni bodyda berasiz va bundan 
{
  "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjMiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJDaGlsZCIsImp0aSI6ImQxMjU0MWJhLWFkYTgtNGFkYi04YTQ0LTdkNDRkZjBhNWZlMCIsIm5hbWUiOiIyMy8wNy8yMDIzIDE1OjIzOjEzIiwiZXhwIjoxNjkwMjEyMTkzLCJpc3MiOiJNaWNyb3NUZXN0SXNzdWVyIiwiYXVkIjoiTWljcm9zVGVzdEF1ZGllbmNlIn0.jFKYq-9oJWGGsT2Bnbz2fkBJJIacF0Go6krnRi0nEaw"
}
ushbu ko'rinishda token qaytadi.
2. 
