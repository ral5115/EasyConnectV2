
using Microsoft.Practices.Prism.PubSubEvents;
using System;

namespace EasyTools.Framework.Composite
{
    public interface IShellView
    {
        IShellViewModel ViewModel { get; set; }

        event EventHandler<DataEventArgs<MenuModel>> OnShowTabMenu;

    }
}
