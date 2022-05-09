using Portfolio.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Portfolio.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {

        private readonly RoleManager<IdentityRole> _role;
        private readonly UserManager<User> _user;

        public RoleController(RoleManager<IdentityRole> role, UserManager<User> user)
        {
            _role = role;
            _user = user;
        }


        public IActionResult Index()
        {
            return View(_role.Roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            IdentityResult result = await _role.CreateAsync(new IdentityRole { Name = name });

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return View();

        }

        public IActionResult AddUser()
        {
            ViewBag.Roles = new SelectList(_role.Roles, "Name", "Name");
            ViewBag.Users = new SelectList(_user.Users, "Id", "UserName");
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AddUser(string role, string user)
        {
            var currentUser = await _user.FindByIdAsync(user);
            IdentityResult result = await _user.AddToRoleAsync(currentUser, role);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            return View();

        }
    }
}