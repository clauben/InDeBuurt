using Microsoft.AspNetCore.Http;
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

namespace Web.Services
{
	public class UserApiAuthHandler : DelegatingHandler
    {
		private readonly IUserApiAuthService _authService;
		private readonly IMemoryCache _memoryCache;

		public UserApiAuthHandler(IUserApiAuthService authService, IMemoryCache memoryCache)
        {
			_authService = authService;
			_memoryCache = memoryCache;
		}

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _memoryCache.TryGetValue("Token", out string token);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
