﻿using malakar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace malakar.Controllers
{
    public class WidgetController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public WidgetController()
        {
        }

        [HttpPost]
        [Route("api/Widget/GetWidget")]
        public IHttpActionResult getWidget(int Id)
        {
            var result = from widgetRow in db.WidgetRow
                         where widgetRow.LayoutId == Id
                         select new
                         {
                             widgetRow.Id,
                             widgetRow.Title,
                             widgetRow.Order,
                             widget = from widget in db.Widget
                                      where widget.WidgetRowId == widgetRow.Id
                                      select new
                                      {
                                          widget.Id,
                                          widget.Type,
                                          widget.Order,
                                          widget.Key,
                                          widget.Data,
                                          widget.Image
                                      }
                         };
            return Ok(result);
        }
    }
}
