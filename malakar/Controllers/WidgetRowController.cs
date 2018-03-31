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

        [HttpPost]
        [Route("api/WidgetRow/CreateWidgetRow")]
        public WidgetRowDto createWidgetRow(WidgetRowDto widgetRowDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //layoutDto.StatusID = 1;
            var widgetRow = Mapper.Map<WidgetRowDto, WidgetRow>(widgetRowDto);

            db.WidgetRow.Add(widgetRow);
            db.SaveChanges();

            widgetRowDto.Id = widgetRow.Id;
            return widgetRowDto;
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

        // DELETE /api/widgetrow?id=1
        [HttpDelete]
        [Route("api/WidgetRow/DeleteWidgetRow")]
        public void deleteWidgetRow(int id)
        {
            var widgetRowInDb = db.WidgetRow.SingleOrDefault(l => l.Id == id);

            if (widgetRowInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            db.WidgetRow.Remove(widgetRowInDb);
            db.SaveChanges();
            //Also deletes records from 'Widgets' table linked to 'WidgetRow' table
        }

    }
}
