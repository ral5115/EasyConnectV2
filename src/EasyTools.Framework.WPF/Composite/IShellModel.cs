using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace EasyTools.Framework.Composite
{
    public interface IShellModel
    {
        String ApplicationName { get; set; }

        String Version { get; set; }

        String UserName { get; set; }

        Dictionary<int, IModuleExt> Modules { get; set; }

        bool IsLogged { get; set; }

        bool IsLocked { get; set; }

        BindingList<MenuModel> Menus { get; set; }

    }
}