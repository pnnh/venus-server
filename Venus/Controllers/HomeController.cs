using System.Diagnostics;
using Gliese.Models;
using Microsoft.AspNetCore.Mvc;
using Venus.Models;

namespace Venus.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> logger;
    private readonly VenusDatabaseContext dataContext;


    public HomeController(ILogger<HomeController> logger, VenusDatabaseContext configuration)
    {
        this.logger = logger;
        dataContext = configuration;
    }

    [Route("/restful/picture")]
    public CommonResult Index(int page = 1)
    {
        return new CommonResult { Code = 200, Message = "Venus业务接口服务" };
    } 
}