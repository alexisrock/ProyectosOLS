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
    public class CsClientes
    {



        public List<Clientes> GetClientes() {

            var url = "https://localhost:44390/api/Cliente/Getall";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            string responseBody = "";
            List<Clientes> Clientes = new List<Clientes>();


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
                              var clientes = (JArray) JsonConvert.DeserializeObject(responseBody);
                            Clientes = clientes.Select(x => new Clientes
                            {
                                id = (int)x["id"],
                                nombres = (string)x["nombres"],
                                apellidos = (string)x["apellidos"],
                                cedula = (string)x["cedula"],
                                direcion = (string)x["direcion"],
                                telefono = (string)x["telefono"]

                            }).ToList();


                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
            return Clientes;

        }

    }
}
