using System;
using System.Collections.Generic;
using System.Text;

namespace FoodOrdersDatabaseImplement.Implements
{
    public class ComponentStorage : IComponentStorage
    {
        public List<ComponentViewModel> GetFullList()
        {
            using (var context = new FoodOrdersDatabase())
            {
                return context.Components
                .Select(rec => new ComponentViewModel
                {
                    Id = rec.Id,
                    ComponentName = rec.ComponentName
                })
                .ToList();
            }
            public List<ComponentViewModel> GetFilteredList(ComponentBindingModel model)
            {
                if (model == null)
                {
                    return null;
                }
                using (var context = new FoodOrdersDatabase())
                {
                    return context.Components
                    .Where(rec => rec.ComponentName.Contains(model.ComponentName))
                   .Select(rec => new ComponentViewModel
                   {
                       Id = rec.Id,
                       ComponentName = rec.ComponentName
                   })
                    .ToList();
                }
            }

        }

    }
}
