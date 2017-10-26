﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stockimulate.Helpers;
using Stockimulate.ViewModels.Administrator;

namespace Stockimulate.Controllers.Administrator
{
    public sealed class TickerController : Controller
    {
        [HttpGet]
        [Route("Ticker/{symbol}")]
        public IActionResult Ticker(string symbol)
        {
            var loggedInAs = HttpContext.Session.GetString("LoggedInAs");

            if (string.IsNullOrEmpty(loggedInAs) || loggedInAs != "Administrator")
                return RedirectToAction("Home", "Home");

            ModelState.Clear();

            ViewData["Title"] = symbol;

            return View(Constants.TickerPath, new TickerViewModel(symbol));
        }
    }
}