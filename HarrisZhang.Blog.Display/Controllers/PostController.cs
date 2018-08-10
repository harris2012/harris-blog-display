using HarrisZhang.Blog.Display.Repository;
using HarrisZhang.Blog.Display.Vo;
using HarrisZhang.Blog.Repository.Entity;
using HeyRed.MarkdownSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HarrisZhang.Blog.Display.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index(string param)
        {
            PostRepository repository = new PostRepository();
            var entityList = repository.GetPostEntityList();
            if (entityList == null && entityList.Count == 0)
            {
                return HttpNotFound();
            }

            var entity = entityList.FirstOrDefault(v => v.Ename.Equals(param));
            if (entity == null)
            {
                return HttpNotFound();
            }

            Markdown markdown = new Markdown();

            entity.Body = markdown.Transform(entity.Body);

            ViewBag.PostEntity = entity;

            ViewBag.Tab = "post";
            return View();
        }

        private List<PostVo> ToVoList(List<PostEntity> entityList)
        {
            List<PostVo> returnValue = new List<PostVo>();

            foreach (var entity in entityList)
            {
                PostVo postVo = new PostVo();

                postVo.Title = entity.Title;
                postVo.Ename = entity.Ename;
                postVo.HtmlBody = entity.Body;

                returnValue.Add(postVo);
            }

            return returnValue;
        }
    }
}