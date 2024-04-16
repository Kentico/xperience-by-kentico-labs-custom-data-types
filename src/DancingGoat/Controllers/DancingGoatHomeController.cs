using System.Threading.Tasks;
using CMS.ContentEngine;
using DancingGoat;
using DancingGoat.Controllers;
using DancingGoat.Models;

using Kentico.Content.Web.Mvc;
using Kentico.Content.Web.Mvc.Routing;

using Microsoft.AspNetCore.Mvc;

[assembly: RegisterWebPageRoute(HomePage.CONTENT_TYPE_NAME, typeof(DancingGoatHomeController), WebsiteChannelNames = new[] { DancingGoatConstants.WEBSITE_CHANNEL_NAME })]

namespace DancingGoat.Controllers
{
    public class DancingGoatHomeController : Controller
    {
        private readonly HomePageRepository homePageRepository;
        private readonly IWebPageDataContextRetriever webPageDataContextRetriever;
        private readonly IContentQueryExecutor executor;

        public DancingGoatHomeController(HomePageRepository homePageRepository, IWebPageDataContextRetriever webPageDataContextRetriever, IContentQueryExecutor executor)
        {
            this.homePageRepository = homePageRepository;
            this.webPageDataContextRetriever = webPageDataContextRetriever;
            this.executor = executor;
        }


        public async Task<IActionResult> Index()
        {
            var webPage = webPageDataContextRetriever.Retrieve().WebPage;

            var homePage = await homePageRepository.GetHomePage(webPage.WebPageItemID, webPage.LanguageName, HttpContext.RequestAborted);

            var locations = await executor.GetMappedResult<LocationContent>(new ContentItemQueryBuilder().ForContentType(LocationContent.CONTENT_TYPE_NAME));

            return View(HomePageViewModel.GetViewModel(homePage));
        }
    }
}
