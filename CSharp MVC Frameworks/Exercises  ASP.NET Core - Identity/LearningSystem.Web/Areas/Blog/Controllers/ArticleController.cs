using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Web.Areas.Blog.Controllers
{
    [Area("Blog")]
    public class ArticleController : Controller
    {
        public IActionResult Index()
        {
            return NotFound();
        }
    }
}