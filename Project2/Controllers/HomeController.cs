using Microsoft.AspNetCore.Mvc;
using Project_Battery.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Battery.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private readonly SignUpDbContext _context;
        private readonly EnquiryDbContext _Encontext;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(SignUpDbContext context, EnquiryDbContext Encontext)
        {
            _context = context;
            _Encontext = Encontext;

        }
        public IActionResult Index() //로그인 정보가 넘어온 과정
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
                ViewBag.IsLoggedIn = true; // 로그인 여부를 확인하는 변수
            }
            return View();
        }

        public IActionResult Introduction()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                //세션의 내용을 ViewBag에 담습니다.
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Index");
            }
                return View();
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(Sign_Up model)
        {

            if (ModelState.IsValid)
            {
                // 비밀번호와 비밀번호 확인이 일치하는지 확인
                if (model.Password != model.ConfirmPassword)
                {
                    // 비밀번호가 일치하지 않을 경우 오류 메시지를 추가
                    ModelState.AddModelError("ConfirmPassword", "비밀번호가 일치하지 않습니다.");
                    return View(model); // 오류가 있으면 다시 해당 뷰로 이동
                }

                // 비밀번호를 그대로 저장
                model.Password = model.Password;
                model.ConfirmPassword = model.ConfirmPassword;

                // 데이터베이스에 추가
                _context.Sign_Up.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {   // 세션의 내용을 ViewBag에 담습니다.
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            return View();
        }

        // 로그인 페이지 렌더링
        [HttpPost]
        public IActionResult Login(Sign_Up model)
        {
            //아이디와 비밀번호가 같을 때                          
            var user = _context.Sign_Up.Where(
                u => u.UserName == model.UserName &&
                u.Password == model.Password)
            .FirstOrDefault();

            if (user != null)
            {
                //세션 제작 코드
                //[Key,Value] 조합 ,Key = UserSession,Value = Db의 정보
                HttpContext.Session.SetString("UserSession", user.UserName);

                return RedirectToAction("Index"); //임의로 첫 화면으로 돌림

            }
            else
            {
                // 로그인 실패 처리
                ModelState.AddModelError(string.Empty, "로그인 실패: 잘못된 사용자 이름 또는 비밀번호입니다.");
                return View(model);
            }
        }
    
        
      
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                //세션 정보 삭제
                HttpContext.Session.Remove("UserSession");
                return RedirectToAction("Login", "Home"); 
            }
            return View();
        }
        public IActionResult Product_Info()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
                ViewBag.IsLoggedIn = true; // 로그인 여부를 확인하는 변수
            }
            else
            {
                // 세션이 없으면 로그인 상태를 false로 설정
                ViewBag.IsLoggedIn = false;
            }
                return View();
        }
        public IActionResult NewsAndEvents()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Enquiry()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                if (HttpContext.Session.GetString("UserSession") == "admin")
                {
                    //Adming으로 로그인 되어있을 때
                    ViewBag.IsLoggedIn = true; // 로그인 여부를 확인하는 변수

                    //세션의 내용을 ViewBag에 담습니다.
                    ViewBag.MySession = HttpContext.Session.GetString("UserSession");
                }
            }
            else
            {
                //로그인 안되어 있을 때 
                ViewBag.IsLoggedIn = false;
                return View("Enquiry");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Enquiry(Enquiry enquiry)
        {
            if (ModelState.IsValid)
            {
                // 데이터베이스에 저장
                _Encontext.Enquiries.Add(enquiry);
                await _Encontext.SaveChangesAsync();

                // 성공 페이지로 리다이렉트
                return RedirectToAction("Sucess");
            }

            // 유효성 검사 실패 시 다시 폼으로 돌아감
            return View(enquiry);
        }
        [HttpGet]
        public IActionResult Success(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Success( Enquiry enquiry)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _Encontext.Enquiries.Add(enquiry); // PurchaseInfo 테이블에 데이터 추가
                    await _Encontext.SaveChangesAsync(); // 데이터베이스에 저장
                    return RedirectToAction("Success", "Home"); // 성공 시 Confrim 페이지로 이동
                }
                catch (Exception ex)
                {
                    // 오류 처리
                    ModelState.AddModelError("", "데이터를 저장하는 중 오류가 발생했습니다.");
                }
            }
            return View(enquiry); // 유효성 검사가 실패하면 다시 폼을 보여줌
        }

        public IActionResult AdminMenu()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                //Adming으로 로그인 되어있을 때
                ViewBag.IsLoggedIn = true; // 로그인 여부를 확인하는 변수

                //세션의 내용을 ViewBag에 담습니다.
                ViewBag.MySession = HttpContext.Session.GetString("UserSession");

                // Enquiry 데이터를 가져와서 뷰로 전달
                var enquiries = _Encontext.Enquiries.ToList();  // 데이터베이스에서 Enquiry 데이터 가져오기
                return View(enquiries);  // 데이터를 뷰로 전달
            }
            else
            {
                //로그인 안되어 있을 때 
                ViewBag.IsLoggedIn = false;

            }
            return View();
        }

        [HttpGet]
        public IActionResult Buy()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Buy(Purchase purchase) //주문서 페이지
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchase);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Confirm));
            }
            return View(purchase);
        }
        [HttpGet]
        public IActionResult Confirm()
        {
            return View();
        }
        [HttpPost]
        //결제하기 버튼 클릭 시 넘어가는 주문 확인 페이지
        public IActionResult Confirm(Purchase purchase)
        {
            return View(purchase);
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
