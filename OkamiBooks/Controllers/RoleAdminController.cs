using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using OkamiBooks.Infastructure;
using OkamiBooks.Models;

namespace OkamiBooks.Controllers
{
    public class RoleAdminController : Controller
    {
        public ActionResult IndexRoles()
        {
            return View(RoleManager.Roles);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Create([Required] string name)
        {
            if (ModelState.IsValid)
            { IdentityResult result = await RoleManager.CreateAsync(new AppRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("IndexRoles");

                }
                else
                {
                    AddErrorsFromResult(result);
                }
            } return View(name);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            AppRole role = await RoleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await RoleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("IndexRoles");
                }
                else
                {
                    return View("Error", result.Errors);
                }
            }
            else
            {
                return View("Error", new string[] { "Role Not Found" });
            }
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors) { ModelState.AddModelError("", error); }
        }
        private ApplicationUserManager UserManager { get { return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); } }
        private AppRoleManager RoleManager { get { return HttpContext.GetOwinContext().GetUserManager<AppRoleManager>(); } }
    }
}