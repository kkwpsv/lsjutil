using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Lsj.Util.WPF
{
    /// <summary>
    /// Validation Helper
    /// </summary>
    public static class ValidationHelper
    {
        /// <summary>
        /// Get Errors of Elements
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        public static ReadOnlyObservableCollection<ValidationError> GetErrorsOfElements(params UIElement[] elements) => new ReadOnlyObservableCollection<ValidationError>(new ObservableCollection<ValidationError>(elements.Select(x => Validation.GetErrors(x)).SelectMany(x => x)));


        /// <summary>
        /// Get Has Error of Elements
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        public static bool GetHasErrorOfElements(params UIElement[] elements) => elements.Any(x => Validation.GetHasError(x));


        /// <summary>
        /// Get Errors with Children
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static ReadOnlyObservableCollection<ValidationError> GetErrorsWithChildren(UIElement element)
        {
            return new ReadOnlyObservableCollection<ValidationError>(new ObservableCollection<ValidationError>(GetUIElementWithChildren(element).Select(x => Validation.GetErrors(x)).SelectMany(x => x)));
        }

        /// <summary>
        /// Get Has Error with Children
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool GetHasErrorWithChildren(UIElement element) => Validation.GetHasError(element) || LogicalTreeHelper.GetChildren(element).OfType<UIElement>().Any(GetHasErrorWithChildren);

        /// <summary>
        /// Get Errors with Children Visible
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static ReadOnlyObservableCollection<ValidationError> GetErrorsWithChildrenVisible(UIElement element)
        {
            return new ReadOnlyObservableCollection<ValidationError>(new ObservableCollection<ValidationError>(GetUIElementWithChildrenVisible(element).Select(x => Validation.GetErrors(x)).SelectMany(x => x)));
        }

        /// <summary>
        /// Get Has Error with Children Visible
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static bool GetHasErrorWithChildrenVisible(UIElement element) => Validation.GetHasError(element) || LogicalTreeHelper.GetChildren(element).OfType<UIElement>().Where(x => x.Visibility == Visibility.Visible).Any(GetHasErrorWithChildren);

        /// <summary>
        /// GetUIElementWithChildren
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static IEnumerable<UIElement> GetUIElementWithChildren(UIElement element)
        {
            if (element != null)
            {
                yield return element;
                foreach (var child in LogicalTreeHelper.GetChildren(element).OfType<UIElement>())
                {
                    foreach (var e in GetUIElementWithChildren(child))
                    {
                        yield return e;
                    }
                }
            }
        }

        /// <summary>
        /// GetUIElementWithChildrenVisible
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static IEnumerable<UIElement> GetUIElementWithChildrenVisible(UIElement element)
        {
            if (element != null)
            {
                yield return element;
                foreach (var child in LogicalTreeHelper.GetChildren(element).OfType<UIElement>().Where(x => x.Visibility == Visibility.Visible))
                {
                    foreach (var e in GetUIElementWithChildren(child))
                    {
                        yield return e;
                    }
                }
            }
        }

    }
}
