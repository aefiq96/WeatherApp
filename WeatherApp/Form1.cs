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
        //private object lbl_cityName;
        //private object lbl_countryName;
        //private object lbl_Temp;

        public Form1()
        {
            InitializeComponent();
            getWeather("Ireland");
        }

        /*private void label1_Click(object sender, EventArgs e)
        {

        }*/

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

        /*private void label1_Click_1(object sender, EventArgs e)
        {

        }*/
    }
}
