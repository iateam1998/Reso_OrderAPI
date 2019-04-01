using SkyWeb.DatVM.Data;
using SkyWeb.DatVM.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Model
{
    public static class EntityExtensions
    {

        public static TViewModel ToViewModel<TEntity, TViewModel>(this TEntity entity)
            where TEntity : IEntity, new()
            where TViewModel : BaseEntityViewModel<TEntity>, new()
        {

            var result = new TViewModel();
            result.CopyFromEntity(entity);
            return result;
        }

    }
}
