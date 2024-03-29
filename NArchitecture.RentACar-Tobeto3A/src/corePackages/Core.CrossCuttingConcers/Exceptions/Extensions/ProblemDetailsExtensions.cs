﻿using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Core.CrossCuttingConcers.Exceptions.Extensions;

public static class ProblemDetailsExtensions
{
    public static string AsJson<TProblemDetail>(this TProblemDetail problemDetails)
        where TProblemDetail : ProblemDetails => JsonSerializer.Serialize(problemDetails);
}