using AutoMapper;
using malakar.Data;
using malakar.Dtos;
using malakar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace malakar.Controllers
{
    public class WidgetRowController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public WidgetRowController()
        {
        }

        //PUT /api/widgetrow?id=1
        [HttpPut]
        [Route("api/WidgetRow/UpdateWidgetRow")]
        public void UpdateWidgetRow(int id, WidgetRowDto widgetRowDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var widgetRowInDb = db.WidgetRow.SingleOrDefault(w => w.Id == id);

            if (widgetRowInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<WidgetRowDto, WidgetRow>(widgetRowDto, widgetRowInDb);

            db.SaveChanges();
        }

    }
}
