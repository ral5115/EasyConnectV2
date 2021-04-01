using EasyTools.Framework.UI;
using Microsoft.Practices.Prism.Commands;
using System;

namespace EasyTools.UI.WPF.Models
{
    public class TabModel : BaseModel
    {
        public String Header
        {
            get { return GetValue(() => Header); }
            set { SetValue(() => Header, value); }
        }

        public bool IsSelected
        {
            get { return GetValue(() => IsSelected); }
            set { SetValue(() => IsSelected, value); }
        }

        public BaseUserControl Content
        {
            get { return GetValue(() => Content); }
            set { SetValue(() => Content, value); }
        }

        public DelegateCommand AddItemCommand
        {
            get { return GetValue(() => AddItemCommand); }
            set { SetValue(() => AddItemCommand, value); }
        }


        public DelegateCommand RemoveItemCommand
        {
            get { return GetValue(() => RemoveItemCommand); }
            set { SetValue(() => RemoveItemCommand, value); }
        }
    }
}
