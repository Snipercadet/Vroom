using Microsoft.AspNetCore.Mvc.Rendering;

namespace Vroom.Models.ViewModels
{
    public class ModelViewModel
    {

        public Model Model { get; set; }
        public IEnumerable<Make> Makes { get; set; }
        public IEnumerable<SelectListItem> CSelectListItems(IEnumerable<Make> Items)

        {
            List<SelectListItem> list = new();
            SelectListItem sli = new()
            {
                Text = "----Select----",
                Value = string.Empty
            };
            list.Add(sli);


            foreach (var make in Items)
            {
                sli = new SelectListItem()
                {
                    Text = make.Name,
                    Value = make.Id.ToString()
                };
                list.Add(sli);
            }
            return list;
        }

        //internal List<Make> CSelectListItems(object items)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
