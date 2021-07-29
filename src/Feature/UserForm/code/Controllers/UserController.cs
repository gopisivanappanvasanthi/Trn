using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Trn.Foundation.Analytics.Services;
using Trn.Foundation.Analytics.Models;
using Trn.Feature.UserForm.ViewModels;

namespace Trn.Feature.UserForm.Controllers
{
    public class UserController : Controller
    {
        private IContactService _contactService;
        public UserController(IContactService contactService)
        {
            _contactService = contactService;
        }
        public ActionResult RegisterUser()
        {
            var model = new UserViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult RegisterUser(UserViewModel model)
        {
            var user = new UserModel();
            if(!string.IsNullOrEmpty(model.EmailAddress))
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.EmailAddress = model.EmailAddress;
                _contactService.CreateContact(user);
            }
            else
            {
                ModelState.Clear();
            }
            return Redirect("/");
        }
    }
}