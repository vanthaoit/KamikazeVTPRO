using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using KamikazeVTPRO.Service.Collections;
using KamikazeVTPRO.Web.App_Start;
using KamikazeVTPRO.Web.Infrastructure.Core;
using Microsoft.AspNet.Identity.Owin;

namespace KamikazeVTPRO.Web.Api
{
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<HttpResponseMessage> Login(HttpRequestMessage request,string userName, string password, bool rememberMe)
        {
            HttpResponseMessage response = null ;
            if (!ModelState.IsValid)
            {
                return response = request.CreateResponse(HttpStatusCode.BadRequest,ModelState);
            }
            var result = await SignInManager.PasswordSignInAsync(userName,password,rememberMe,shouldLockout:false);

            response = request.CreateResponse(HttpStatusCode.OK,result);

            return response;
        }


    }
}