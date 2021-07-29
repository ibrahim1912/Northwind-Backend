using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac
{
    //json web token için
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; //her istek için 

        public SecuredOperation(string roles) 
        {
            _roles = roles.Split(',');  //rolleri aspectte virgülle vermek için split
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();  //aspectler injection yapamaz onu burda tool ile yapıyoruz

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }  //buraya kadar bir claim i varsa hata verme
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}