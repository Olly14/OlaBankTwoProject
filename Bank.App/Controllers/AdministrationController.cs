using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bank.App.CustomSecurity;
using Bank.App.Models;
using Bank.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bank.App.Controllers
{
    [Authorize(Roles = "Bank Admin")]
    public class AdministrationController : Controller
    {


        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AdministrationController(RoleManager<IdentityRole> roleManager,
            UserManager<AppUser> userManager,
            
            IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }



        [HttpGet]
        public IActionResult CreateRole()
        {
            var role = new RoleViewModel();

            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleViewModel roleModel)
        {
            if (ModelState.IsValid)
            {
                var identityRole = new IdentityRole() { Name = roleModel.Name.Trim() };
                var createRoleResult = await _roleManager.CreateAsync(identityRole);
                if (createRoleResult.Succeeded)
                {
                    return RedirectToAction("Roles");
                }
                foreach (var error in createRoleResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(roleModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string roleId)
        {

            var decryptedId = GuidEncoder.Decode(roleId);
            var role = await _roleManager.FindByIdAsync(decryptedId.ToString());
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with ID = {roleId} cannot be found.";
                return View("NotFound");
            }
            var model = new RoleViewModel()
            {
                Id = role.Id,
                Name = role.Name
            };
            model = PopulateUriKey(model);
            model.UIControl = "Edit";
            foreach (var user in _userManager.Users)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    model.RoleUsers.Add(user.FirstName + " " + user.LastName);
                }
                
            }
            return View("CreateRole", model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditRole(RoleViewModel roleViewModel)
        {

            if (ModelState.IsValid)
            {
                var decryptedId = GuidEncoder.Decode(roleViewModel.UriKey);
                var role = await _roleManager.FindByIdAsync(decryptedId.ToString());
                if (role == null)
                {
                    ViewBag.ErrorMessage = $"Role with ID = {role.Id} cannnot be found.";
                    return View("NotFound");
                }
                role.Name = roleViewModel.Name;
                var updateResult = await _roleManager.UpdateAsync(role);
                if (updateResult.Succeeded)
                {
                    RedirectToAction("Roles");
                }
                foreach (var error in updateResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View(roleViewModel);
                }
            }



            return View(roleViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> AddOrRemoveUserInRoles(string urikey)
        {
            ViewData["UriKey"] = urikey;

            var decryptedId = GuidEncoder.Decode(urikey);
            var role = await _roleManager.FindByIdAsync(decryptedId.ToString());
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with ID = {urikey} cannnot be found.";
                return View("NotFound");
            }
            var models = new List<UserRoleViewModel>();


            //model.UIControl = "Edit";
            foreach (var user in _userManager.Users)
            {

                var userRoleviewModel = new UserRoleViewModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                var fillIsSelected = await _userManager.IsInRoleAsync(user, role.Name) ? userRoleviewModel.IsSelected = true : userRoleviewModel.IsSelected = false;

                models.Add(userRoleviewModel);
            }

            return View(models);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddOrRemoveUserInRoles(List<UserRoleViewModel> userRoleViewModels, string roleId)
        {




                var decryptedId = GuidEncoder.Decode(roleId);
                var role = await _roleManager.FindByIdAsync(decryptedId.ToString());
                if (role == null)
                {
                    ViewBag.ErrorMessage = $"Role with ID = {roleId} cannnot be found.";
                    return View("NotFound");
                }

            for (int i = 0; i < userRoleViewModels.Count; i++)
            {
                var user = await _userManager.FindByIdAsync(userRoleViewModels[i].UserId);

                IdentityResult identityResult = null;
                if (userRoleViewModels[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                {

                    identityResult = await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!userRoleViewModels[i].IsSelected && await _userManager.IsInRoleAsync(user, role.Name))
                {

                    identityResult = await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else { continue; }
                if (identityResult.Succeeded)
                {
                    if (i < userRoleViewModels.Count -1)
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("EditRole", new { roleId });
                    }
                }
            }




            return RedirectToAction("EditRole", new { roleId });
        }


        [HttpGet]
        public IActionResult Roles()
        {
            var roles = _roleManager.Roles.OrderBy(r => r.Name);
            var roleViewModels = _mapper.Map<IEnumerable<RoleViewModel>>(roles);
            roleViewModels = PopulateUriKey(roleViewModels);

            return View(roleViewModels);
        }


        [HttpGet]
        public IActionResult DeleteRole(string roleId)
        {


            return View();
        }





        public IEnumerable<RoleViewModel> PopulateUriKey(IEnumerable<RoleViewModel> roles)
        {
            return roles = roles.Select(r =>
            {
                r.UriKey = GuidEncoder.Encode(r.Id);
                return r;
            });
        }
        public IEnumerable<UserRoleViewModel> PopulateUriKey(IEnumerable<UserRoleViewModel> roles)
        {
            return roles = roles.Select(r =>
            {
                r.Urikey = GuidEncoder.Encode(r.UserId);
                return r;
            });
        }
        public RoleViewModel PopulateUriKey(RoleViewModel role)
        {
            role.UriKey =  GuidEncoder.Encode(role.Id);
            return role;
        }

        public UserRoleViewModel PopulateUriKey(UserRoleViewModel role)
        {
            role.Urikey = GuidEncoder.Encode(role.UserId);
            return role;
        }
    }
}