﻿using Core.Domain.User;

namespace Core.Application.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token
    );
}