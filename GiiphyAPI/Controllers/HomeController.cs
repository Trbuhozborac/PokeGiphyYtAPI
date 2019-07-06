using GiiphyAPI.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace GiiphyAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["giphyAPIKey"];
            string query = "funny cat";

            //Create the request to the API
            WebRequest request = WebRequest.Create("http://api.giphy.com/v1/gifs/search?q=" + query+"&api_key=" + apiKey);

            //Send that request off
            WebResponse respone = request.GetResponse();

            //Get back the response stram
            Stream stream = respone.GetResponseStream();

            //Make it accessible
            StreamReader reader = new StreamReader(stream);

            //Put into string , which is json formatted
            string resposneFromServer = reader.ReadToEnd();

            JObject parsedString = JObject.Parse(resposneFromServer);

            Gif myGifs = parsedString.ToObject<Gif>();

            return View(myGifs);
        }
    }
}