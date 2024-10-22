using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project_Battery.Models;

namespace Project_Battery
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 뷰 추가 시 필요한 빌더
            builder.Services.AddControllersWithViews();

            //세션 기능
            builder.Services.AddSession(); //단순 세션
            var provider = builder.Services.BuildServiceProvider();
            var config = provider.GetRequiredService<IConfiguration>();
            builder.Services.AddDbContext<SignUpDbContext>(item => item.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            builder.Services.AddDbContext<EnquiryDbContext>(item => item.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            //방금 수정 DbContext 
           

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //세션기능을 사용 하려면 꼭 작성해야 합니다. build쪽 옵션은 말그대로 옵션 설정이지 정작 동작은 app.UseSession()을 통해서 세션 기능이 동작합니다.
            app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
