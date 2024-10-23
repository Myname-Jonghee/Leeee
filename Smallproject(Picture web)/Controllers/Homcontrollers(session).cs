using Microsoft.AspNetCore.Mvc;
using OpenCVWebQuiz.Models;
using System.Diagnostics;
using System;
using System.IO;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using OpenCvSharp;

namespace OpenCVWebQuiz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                //업로드 한 사진 정보를 wwwroot/images에 저장함
                var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images"); 
                
                var fileName = Path.GetFileName(imageFile.FileName);
                var filePath = Path.Combine(uploadsFolderPath, fileName);

                // 파일 저장
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }

                // 원본 파일 정보를 Session에 저장
                var originalPhotoUrl = Url.Content("~/images/" + fileName); //이미지 경로 잘 볼것
                HttpContext.Session.SetString("OriginalPhotoPath", filePath);//이미지 경로 잘 볼것

                // 사진 화질 향상 처리 후 저장
                var enhancedPhotoPath = EnhancePhoto(filePath);
                HttpContext.Session.SetString("EnhancedPhotoPath", enhancedPhotoPath);

                return RedirectToAction("Result");
            }
            return View();
        }
        public ActionResult Result()
        {
            // 세션에 저장되어 있는 사진 정보들을 가지고 옴
            if (HttpContext.Session.TryGetValue("OriginalPhotoPath", out byte[] originalPathBytes) &&
                HttpContext.Session.TryGetValue("EnhancedPhotoPath", out byte[] enhancedPathBytes))
            {
                var originalPhotoPath = System.Text.Encoding.UTF8.GetString(originalPathBytes);
                var enhancedPhotoPath = System.Text.Encoding.UTF8.GetString(enhancedPathBytes);

                // 모델 생성 및 값 설정
                var model = new Photo
                {
                    OriginalPhotoUrl = Url.Content("~/images/" + Path.GetFileName(originalPhotoPath)),
                    EnhancedPhotoUrl = Url.Content("~/Enhanced/" + Path.GetFileName(enhancedPhotoPath))
                };
                // 사진 경로 정보를 ViewBag에 담아서 뷰로 전달
                ViewBag.OriginalPhotoUrl = model.OriginalPhotoUrl;
                ViewBag.EnhancedPhotoUrl = model.EnhancedPhotoUrl;
                // Result 뷰로 모델 전달
                return View(model);
            }
            // 세션에 정보가 없으면 업로드 페이지로 이동
            return RedirectToAction("Index");
        }

            public string EnhancePhoto(string originalPath)
            {
                // 원본 이미지 로드
                Mat originalImage = Cv2.ImRead(originalPath, ImreadModes.Color);
                Mat enhancedImage = new Mat();

                double alpha = 1.5; // 대비 조정 계수
                int beta = 20; // 밝기 조정 계수

                // 대비 및 명암 조정
                originalImage.ConvertTo(enhancedImage, MatType.CV_8UC3, alpha, beta);

                // 향상된 이미지를 저장할 폴더 경로 설정
                var enhancedFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Enhanced");
                Directory.CreateDirectory(enhancedFolderPath);

                // 향상된 이미지 파일 경로 설정 및 저장
                var enhancedPath = Path.Combine(enhancedFolderPath, Path.GetFileName(originalPath));
                Cv2.ImWrite(enhancedPath, enhancedImage);

                return enhancedPath;
            }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
