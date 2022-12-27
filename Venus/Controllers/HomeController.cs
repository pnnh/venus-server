using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Venus.Models;

namespace Venus.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> logger;
    private readonly BloggingContext dataContext;


    public HomeController(ILogger<HomeController> logger, BloggingContext configuration)
    {
        this.logger = logger;
        dataContext = configuration;
    }

    public IActionResult Index(int page = 1)
    {
        var indexPageSize = 8;
        var currentPage = page;
        if (currentPage <= 1)
        {
            currentPage = 1;
        }
        var articlesCount = dataContext.PicturesTable.Count();
        var pagination = new PaginationModel(articlesCount, currentPage, indexPageSize);

        var fBlogs = dataContext.PicturesTable.Join(dataContext.PictureFilesTable, pic => pic.File, pf => pf.Pk, (pic, pf) => new PictureModel
        {
            Pk = pic.Pk,
            Title = pic.Title,
            CreateTime = pic.CreateTime,
            UpdateTime = pic.UpdateTime,
            Creator = pic.Creator,
            File = pic.File,
            Status = pic.Status,
            FilePath = pf.Path,
        }).Skip(pagination.Offset).Take(indexPageSize).ToList();

        var model = new IndexViewModel
        {
            Range = fBlogs,
            Pagination = pagination,
        };
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}