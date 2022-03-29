﻿using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace Blazor.Models.Auth;

public class SimpleAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly IAuthService authService;

    public SimpleAuthenticationStateProvider(IAuthService authService)
    {
        this.authService = authService;
        authService.OnAuthStateChanged += AuthStateChanged;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsPrincipal principal = await authService.GetAuthAsync();
        return await Task.FromResult(new AuthenticationState(principal));
    }

    private void AuthStateChanged(ClaimsPrincipal principal)
    {
        NotifyAuthenticationStateChanged(
            Task.FromResult(
                new AuthenticationState(principal)
            )
        );
    }
}