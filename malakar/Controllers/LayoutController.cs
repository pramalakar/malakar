using malakar.Data;
using System.Linq;
using System.Web.Http;

namespace malakar.Controllers
{
    public class LayoutController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public LayoutController()
        {
        }

        [HttpGet]
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
    }
}
