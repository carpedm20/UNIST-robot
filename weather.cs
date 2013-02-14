using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace robot
{
    class Weather
    {
        // http://www.kma.go.kr/wid/queryDFS.jsp?gridx=98&gridy=84
        public string weather = "";

        public Weather()
        {
            getWeather();
        }

        public void getWeather() {
            XmlDocument docX = new XmlDocument();
            docX.Load("http://www.kma.go.kr/wid/queryDFS.jsp?gridx=98&gridy=84");

            XmlNodeList hourList = docX.GetElementsByTagName("hour");
            XmlNodeList tempList = docX.GetElementsByTagName("temp");
            XmlNodeList weatherList = docX.GetElementsByTagName("wfKor");

            weather = "   = 울산 날씨 =\n";
            weather += hourList[0].InnerText + "시 : " + weatherList[0].InnerText + " (" + tempList[0].InnerText + "℃)\n";
            weather += hourList[1].InnerText + "시 : " + weatherList[1].InnerText + " (" + tempList[1].InnerText + "℃)\n";
            weather += hourList[2].InnerText + "시 : " + weatherList[2].InnerText + " (" + tempList[2].InnerText + "℃)\n";
            weather += hourList[3].InnerText + "시 : " + weatherList[3].InnerText + " (" + tempList[3].InnerText + "℃)\n";
            // weather += hourList[4].InnerText + "시 : " + weatherList[4].InnerText + "(" + tempList[4].InnerText + "℃)\n";
            // weather += hourList[5].InnerText + "시 : " + weatherList[5].InnerText + "(" + tempList[5].InnerText + "℃)\n";
        }
    }
}
