﻿using Microsoft.AspNetCore.Identity;

namespace MoneyTracker.Services;

public class SeedUserRoleInitial : ISeedUserRoleInitial
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public SeedUserRoleInitial(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public void SeedRoles()
    {
        if (!_roleManager.RoleExistsAsync("Member").Result)
        {
            IdentityRole role = new IdentityRole();
            role.Name = "Member";
            role.NormalizedName = "MEMBER";
            IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
        }
    }

    public void SeedUsers()
    {
        if (_userManager.FindByEmailAsync("usuario@localhost").Result == null)
        {
            IdentityUser user = new IdentityUser();
            user.UserName = "User1";
            user.Email = "user@localhost";
            user.NormalizedUserName = "USER1";
            user.NormalizedEmail = "USER@LOCALHOST";
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = _userManager.CreateAsync(user, "Numsey#2022").Result;

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, "Member").Wait();
            }
        }
    }
}
