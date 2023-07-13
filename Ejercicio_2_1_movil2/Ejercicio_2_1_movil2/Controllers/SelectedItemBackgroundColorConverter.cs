using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Ejercicio_2_1_movil2.Controllers
{
    internal class SelectedItemBackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Comprueba si el elemento está seleccionado
            if ((bool)value)
            {
                // Devuelve el color de fondo seleccionado
                return Color.LightBlue;
            }

            // Devuelve el color de fondo predeterminado
            return Color.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
