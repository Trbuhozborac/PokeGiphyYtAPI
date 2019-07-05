using Newtonsoft.Json.Linq;
using PokeGiphyYtAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PokeGiphyYtAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Create the request to the API
            WebRequest request = WebRequest.Create("https://pokeapi.co/api/v2/pokemon/1");

            //Send that request off
            WebResponse respone = request.GetResponse();

            //Get back the response stram
            Stream stream = respone.GetResponseStream();

            //Make it accessible
            StreamReader reader = new StreamReader(stream);

            //Put into string , which is json formatted
            string resposneFromServer = reader.ReadToEnd();

            JObject parsedString = JObject.Parse(resposneFromServer);
            Pokemon myPokemon = parsedString.ToObject<Pokemon>();

            Debug.WriteLine(myPokemon.moves[0].move.name);

            //Get back the response stream 
            return View();
        }
    }
}