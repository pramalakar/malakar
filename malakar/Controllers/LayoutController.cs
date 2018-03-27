using AutoMapper;
using malakar.Data;
using malakar.Dtos;
using malakar.Models;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace malakar.Controllers
{
    public class LayoutController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public LayoutController()
        {
        }

        [HttpPost]
        [Route("api/Layout/GetLayout")]
        public IHttpActionResult getLayout()
        {
            var result = from layout in db.Layout
                         where layout.StatusID == 1
                         select new
                        {
                            layout.Id,
                            layout.Name,
                            layout.Description,
                            WidgetRow = from widgetRow in db.WidgetRow
                                    where widgetRow.LayoutId == layout.Id
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
                                    }
                        };
            return Ok(result);
        }

        [HttpPost]
        [Route("api/Layout/CreateLayout")]
        public LayoutDto createLayout(LayoutDto layoutDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var layout = Mapper.Map<LayoutDto, Layout>(layoutDto);
            layout.StatusID = 1;
            db.Layout.Add(layout);
            db.SaveChanges();

            layoutDto.Id = layout.Id;
            return layoutDto;
        }

        //PUT /api/layout?id=1
        [HttpPut]
        [Route("api/Layout/UpdateLayout")]
        public void updateLayout(int id, LayoutDto layoutDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var layoutInDb = db.Layout.SingleOrDefault(l => l.Id == id);

            if (layoutInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            Mapper.Map<LayoutDto, Layout>(layoutDto, layoutInDb);
            
            db.SaveChanges();
        }

        // DELETE /api/layout?id=1
        [HttpDelete]
        [Route("api/Layout/DeleteLayout")]
        public void deleteLayout(int id)
        {
            var layoutInDb = db.Layout.SingleOrDefault(l => l.Id == id);

            if (layoutInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            db.Layout.Remove(layoutInDb);
            db.SaveChanges();
        }
    }
}
