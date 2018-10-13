using HarrisZhang.Blog.Display.Repository;
using HarrisZhang.Blog.Display.Vo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HarrisZhang.Blog.Display.Biz
{
    public class SummaryBiz
    {
        public List<SummaryVo> GetSummaryList()
        {
            List<SummaryVo> returnValue = new List<SummaryVo>();

            PostRepository postRepository = new PostRepository();
            var postEntityList = postRepository.GetPostEntityList();
            foreach (var postEntity in postEntityList)
            {
                SummaryVo summary = new SummaryVo();

                summary.ItemType = 1;
                summary.ItemId = postEntity.Id;
                summary.Ename = postEntity.Ename;
                summary.Title = postEntity.Title;
                summary.Body = postEntity.Summary;
                summary.PublishTime = postEntity.PublishTime;

                returnValue.Add(summary);
            }

            return returnValue;
        }
    }
}