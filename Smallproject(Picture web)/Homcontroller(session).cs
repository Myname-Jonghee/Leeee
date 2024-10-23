namespace OpenCVWebQuiz
{
    public class Program
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // 세션 사용을 위해 메모리 캐시 및 세션 서비스 등록
            services.AddDistributedMemoryCache(); // 세션을 위한 메모리 캐시
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // 세션 유지 시간 설정
                options.Cookie.HttpOnly = true; // 세션 쿠키를 HttpOnly로 설정
                options.Cookie.IsEssential = true; // 이 쿠키가 필수인지 여부
            });
        }
        

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(); //단순 세션
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession(); //세션사용

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
