using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System.Security.Claims;
using Web.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.Auth.ViewModels;
using Newtonsoft.Json;
using System.Globalization;
using System.Threading;
using Web.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Http;

namespace Web.Helpers
{
	public class UserApiAuthHandler : DelegatingHandler
    {
		private readonly IUserApiAuthService _authService;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public UserApiAuthHandler(IUserApiAuthService authService, IHttpContextAccessor httpContextAccessor)
        {
			_authService = authService;
			_httpContextAccessor = httpContextAccessor;
		}

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = _httpContextAccessor.HttpContext.User.Claims
                .Where(c => c.Type == "Token")
                .Select(c => c.Value)
                .DefaultIfEmpty("Empty")
                .First();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
