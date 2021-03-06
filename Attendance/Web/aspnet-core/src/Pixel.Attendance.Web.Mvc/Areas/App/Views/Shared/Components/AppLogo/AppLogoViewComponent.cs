﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pixel.Attendance.Web.Areas.App.Models.Layout;
using Pixel.Attendance.Web.Session;
using Pixel.Attendance.Web.Views;

namespace Pixel.Attendance.Web.Areas.App.Views.Shared.Components.AppLogo
{
    public class AppLogoViewComponent : AttendanceViewComponent
    {
        private readonly IPerRequestSessionCache _sessionCache;

        public AppLogoViewComponent(
            IPerRequestSessionCache sessionCache
        )
        {
            _sessionCache = sessionCache;
        }

        public async Task<IViewComponentResult> InvokeAsync(string logoSkin = null, string logoClass = "")
        {
            var headerModel = new LogoViewModel
            {
                LoginInformations = await _sessionCache.GetCurrentLoginInformationsAsync(),
                LogoSkinOverride = logoSkin,
                LogoClassOverride = logoClass
            };

            return View(headerModel);
        }
    }
}
