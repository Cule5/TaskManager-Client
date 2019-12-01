using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using TaskManager_Client.Enums;

namespace TaskManager_Client.Converters
{
    public class MessageStatusToFontConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is EMessageStatus)
            {
                var messageStatus = (EMessageStatus) value;
                if (messageStatus == EMessageStatus.Read)
                    return FontWeights.Bold;
                else if (messageStatus == EMessageStatus.Unread)
                    return FontWeights.Normal;
            }

            return FontWeights.Normal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
