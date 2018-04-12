using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WeatherApp
{
    public partial class Form1 : Form
    {
        const string APPID = "542ffd081e67f4512b705f89d2a611b2";
        string cityName = "Galway";
        public Form1()
        {
            InitializeComponent();
            getWeather("Ireland"); //one day weather
            getForcast("Ireland"); //more than one day 

        }
        

        void getWeather(string city)
        {
            using (WebClient web = new WebClient())
            {
                //where do i get this url?
                string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric&cnt=6", cityName, APPID);

                var json = web.DownloadString(url);

                var result = JsonConvert.DeserializeObject<weatherInfo.Root>(json);

                weatherInfo.Root outPut = result;                

                lbl_cityName.Text = string.Format("{0}", outPut.name);
                lbl_countryName.Text = string.Format("{0}", outPut.sys.country);
                lbl_Temp.Text = string.Format("{0} \u00B0" + "C", outPut.main.temp);

               

            }

            
        }
        void getForcast(string city) {
            int day = 5;
            string url = string.Format("http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&units=metric&cnt={1}&APPID={2}",city,day,APPID);
            using (WebClient web = new WebClient()) {
                var json = web.DownloadString(url);
                var Object = JsonConvert.DeserializeObject<weatherForcast>(json);

                weatherForcast forcast = Object;


                //next day
                lbl_day_2.Text = string.Format("{0}", getDate(forcast.list[1].dt).DayOfWeek); //returning Day
                lbl_cond_2.Text = string.Format("{0}", forcast.list[1].weather[0].main); //weather condition
                lbl_des_2.Text = string.Format("{0}", forcast.list[1].weather[0].description); //weather description
                lbl_temp_2.Text = string.Format("{0} \u00B0" + "C", forcast.list[1].temp.day); //weather temperature
                lbl_wind_2.Text = string.Format("{0} km/h", forcast.list[1].speed); //weather temperature

                //day after tomorrow
                lbl_day_3.Text = string.Format("{0}", getDate(forcast.list[2].dt).DayOfWeek); //returning Day
                lbl_cond_3.Text = string.Format("{0}", forcast.list[1].weather[0].main); //weather condition
                lbl_des_3.Text = string.Format("{0}", forcast.list[1].weather[0].description); //weather description
                lbl_temp_3.Text = string.Format("{0} \u00B0" + "C", forcast.list[2].temp.day); //weather temperature
                lbl_wind_3.Text = string.Format("{0} km/h", forcast.list[2].speed); //weather temperature

                picture_Main.Image = setIcon();
            }
        }

        DateTime getDate(double millisecond) {
            DateTime day = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(millisecond).ToLocalTime();

            return day;

        }

        Image setIcon() {
            string url = "http://openweathermap.org/img/w/10d.png"; // weather icon resource
            var request = WebRequest.Create(url);
            using (var response = request.GetResponse())
            using (var weatherIcon = response.GetResponseStream())
            {
                Image weatherImg = Bitmap.FromStream(weatherIcon);
                return weatherImg;

            }
            
                
        }

        
    }
}
