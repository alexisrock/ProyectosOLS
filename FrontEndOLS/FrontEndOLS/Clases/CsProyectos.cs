using FrontEndOLS.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FrontEndOLS.Clases
{
    public class CsProyectos
    {


        public List<Proyectos> GetProyectos() {


                var url = "https://localhost:44390/api/Proyectos/GetAll";
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json";
                request.Accept = "application/json";
                string responseBody = "";
                List<Proyectos> proyectos = new List<Proyectos>();


                try
                {
                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream strReader = response.GetResponseStream())
                        {
                            if (strReader == null) return null;
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                responseBody = objReader.ReadToEnd();
                                // Do something with responseBody
                                var proyecto = (JArray)JsonConvert.DeserializeObject(responseBody);
                                proyectos = proyecto.Select(x => new Proyectos
                                {
                                    id = x["id"]!= null? (int)x["id"] : 0,
                                    nombre = x["nombre"] != null ? (string)x["nombre"] :"",
                                    idcliente = (int)x["idcliente"],
                                    idestado = (int)x["idestado"],
                                    cliente = (string)x["cliente"],
                                    estado = (string)x["estado"],
                                    fechainicio = (string)x["fechainicio"],
                                    fechafin = (string)x["fechafin"],
                                    precio = (int)x["precio"],
                                    cantidadhoras = (int)x["cantidadhoras"],

                                }).ToList();


                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    // Handle error
                }
                return proyectos;

            

        }
    }
}
