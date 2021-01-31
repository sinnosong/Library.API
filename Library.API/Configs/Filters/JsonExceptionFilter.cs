﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.API.Configs.Filters
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        public JsonExceptionFilter(IWebHostEnvironment env, ILogger<Program> logger)
        {
            Env = env;
            Logger = logger;
        }

        public IWebHostEnvironment Env { get; }
        public ILogger<Program> Logger { get; }

        public void OnException(ExceptionContext context)
        {
            var error = new ApiError();
            if (Env.IsDevelopment())
            {
                error.Message = context.Exception.Message;
                error.Detail = context.Exception.ToString();
            }
            else
            {
                error.Message = "服务器出错";
                error.Detail = context.Exception.Message;
            }
            context.Result = new ObjectResult(error)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"服务器发生异常：{context.Exception.Message}");
            sb.AppendLine(context.Exception.ToString());
            Logger.LogCritical(sb.ToString());
        }
    }
}