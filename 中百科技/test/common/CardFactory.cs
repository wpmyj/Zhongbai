using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;

namespace DasherStation.common
{
    public class CardFactory
    {
        public static ICardHelper Creat()
        {
            string CardName = ConfigurationSettings.AppSettings["CardName"];

            return (ICardHelper)Assembly.GetExecutingAssembly().CreateInstance(CardName);
        }
       
    }
}
