using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YoutubeAPI.Models;

namespace YoutubeAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["ytAPIKey"];

            //Create the request to the API
            WebRequest request = WebRequest.Create("https://www.googleapis.com/youtube/v3/search?part=snippet&q=pokemon&key=" + apiKey);

            //Send that request off
            WebResponse respone = request.GetResponse();

            //Get back the response stram
            Stream stream = respone.GetResponseStream();

            //Make it accessible
            StreamReader reader = new StreamReader(stream);

            //Put into string , which is json formatted
            string resposneFromServer = reader.ReadToEnd();

            JObject parsedString = JObject.Parse(resposneFromServer);

            YoutubeSearch mySearch = parsedString.ToObject<YoutubeSearch>();

            

            return View(mySearch);
        } 
    }
}