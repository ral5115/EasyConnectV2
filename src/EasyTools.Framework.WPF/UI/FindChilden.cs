using System.Windows;
using System.Windows.Media;

namespace EasyTools.Framework.UI
{
    public class FindChilden
    {
        public static childItem FindVisualChild<childItem>(DependencyObject objParent) where childItem : DependencyObject
        {
            for (int i = 0; i <= VisualTreeHelper.GetChildrenCount(objParent) - 1; i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(objParent, i);
                if (child != null && child is childItem)
                {
                    return (childItem)child;
                }
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                    {
                        return childOfChild;
                    }

                }
            }
            return null;
        }
    }
}