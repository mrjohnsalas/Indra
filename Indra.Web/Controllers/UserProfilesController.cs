using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Indra.Business;
using Microsoft.AspNet.Identity;

namespace Indra.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserProfilesController : Controller
    {
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated) return View();
            var buApplicationUser = new BuApplicationUser();
            var user = buApplicationUser.GetByUserName(User.Identity.GetUserName());
            return View(user);
        }

        [HttpPost]
        public JsonResult DeleteFile()
        {
            try
            {
                var buApplicationUser = new BuApplicationUser();
                var user = buApplicationUser.GetByUserName(User.Identity.GetUserName());
                user.ProfilePhoto = null;
                buApplicationUser.Update(user);

                return Json(new { Result = "Ok" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult UploadFile()
        {
            if (Request.Files.Count.Equals(0))
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = "Error" });
            }
            try
            {
                var buApplicationUser = new BuApplicationUser();
                var user = buApplicationUser.GetByUserName(User.Identity.GetUserName());

                for (var i = 0; i < Request.Files.Count; i++)
                {
                    var poImgFile = Request.Files[i];
                    using (var binary = new BinaryReader(poImgFile.InputStream))
                        user.ProfilePhoto = binary.ReadBytes(poImgFile.ContentLength);
                }

                buApplicationUser.Update(user);

                return Json(new { Result = "Ok" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }

        private byte[] LoadDefaultProfilePhoto()
        {
            var fileName = HttpContext.Server.MapPath(@"~/Images/profile_user_def.png");
            var fileInfo = new FileInfo(fileName);
            var imageFileLength = fileInfo.Length;
            var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            var br = new BinaryReader(fs);
            return br.ReadBytes((int)imageFileLength);
        }

        public FileContentResult ProfilePhoto()
        {
            if (!User.Identity.IsAuthenticated || string.IsNullOrEmpty(User.Identity.GetUserId()))
                return File(LoadDefaultProfilePhoto(), "image/png");

            var buApplicationUser = new BuApplicationUser();
            var user = buApplicationUser.GetByUserName(User.Identity.GetUserName());

            return user?.ProfilePhoto == null ? File(LoadDefaultProfilePhoto(), "image/png") : new FileContentResult(user.ProfilePhoto, "image/jpeg");
        }
    }
}