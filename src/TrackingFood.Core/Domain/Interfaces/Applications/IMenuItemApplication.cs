﻿using TrackingFood.Core.Domain.ViewModel;
using TrackingFood.Core.Domain.ViewModel.Request;

namespace TrackingFood.Core.Domain.Interfaces.Applications
{
    public interface IMenuItemApplication : IBaseApplication
    {
        void Create(CreateMenuItemsViewModel menuItem);
        SearchMenuItemViewModel[] SearchForNameOrValue(string strSearch, decimal? inicialValue = null, decimal? finalValue = null);
    }
}