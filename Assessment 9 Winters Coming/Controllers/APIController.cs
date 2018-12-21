using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Assessment_9_Winters_Coming.Controllers
{
    public class APIController : Controller
    {

        const string UserAgent = "Mozilla / 5.0(Windows NT 6.1; Win64; x64; rv: 47.0) Gecko / 20100101 Firefox / 47.0";

        // GET: API
        public ActionResult getCharData()
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://anapioficeandfire.com/api/characters/");
            request.UserAgent = UserAgent;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader data = new StreamReader(response.GetResponseStream());
                JArray dataObject = JArray.Parse(data.ReadToEnd());

                ViewBag.data = dataObject;
            }
            return View();
        }



        public ActionResult getSpecificCharacter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult getSpecificCharacter(string charID)
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://anapioficeandfire.com/api/characters/" + charID);
            request.UserAgent = UserAgent;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader data = new StreamReader(response.GetResponseStream());

                JObject dataObject = JObject.Parse(data.ReadToEnd());


                ViewBag.CharInfo = dataObject;
            }
            return View();


        }

        public ActionResult ShowDetroitWeatherData()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ShowDetroitWeatherData(string Latitude, string Longitude)
        {
            HttpWebRequest request = WebRequest.CreateHttp("https://forecast.weather.gov/MapClick.php?lat=" + Latitude + "&lon=" + Longitude + "&FcstType=json");
            request.UserAgent = UserAgent;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader data = new StreamReader(response.GetResponseStream());

                JObject dataObject = JObject.Parse(data.ReadToEnd());


                ViewBag.WeatherLabels = dataObject["time"];
                ViewBag.WeatherData = dataObject["data"];


            }
            return View();
        }
    }
}


    //    public ActionResult getSpecificCharacter()
    //    {
    //        return View();
    //    }

    //    [HttpPost]
    //    public ActionResult getSpecificCharacter(string charID)
    //    {
    //        HttpWebRequest request = WebRequest.CreateHttp("https://anapioficeandfire.com/api/characters/" + charID);
    //        request.UserAgent = UserAgent;
    //        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    //        if (response.StatusCode == HttpStatusCode.OK)
    //        {
    //            StreamReader data = new StreamReader(response.GetResponseStream());
    //            JArray dataObject = JArray.Parse(data.ReadToEnd());

    //            ViewBag.charData = dataObject;
    //        }
    //        return View();
    //    }
