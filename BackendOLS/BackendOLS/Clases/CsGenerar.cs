using BackendOLS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BackendOLS.Clases
{
    public class CsGenerar
    {
        private readonly proyectosClienteContext _context = new proyectosClienteContext();

        public DataTable generarReporte() {
            DataTable dataTable = new DataTable();
            using (var dbcon = new proyectosClienteContext())
            {
          
                

                try
                {
                    var command = dbcon.Database.GetDbConnection().CreateCommand();
                    command.CommandText = "sp_proyectosClientes";
                    command.CommandType = CommandType.StoredProcedure;
                    dbcon.Database.OpenConnection();

                    var dataReader = command.ExecuteReader();

                    dataTable.Load(dataReader);



                }
                catch (Exception ex) { 
                }
                finally
                {
                    dbcon.Database.CloseConnection();
                }  
                }


            return dataTable;

        }


        public Response createFile(DataTable dt) {

            Response response = new Response();
            string CadenaDataTable = "";
            Random rnd = new Random();
            int mIndex = rnd.Next(10000);
            string fileName = "GenerarArchivo_"+mIndex+".txt";
            string path1 = "Archivos";
            string path2 = @"\mydir";
            string fullPath;

            fullPath = Path.GetFullPath(path1);

            foreach (DataRow row in dt.Rows)
                {
                    CadenaDataTable += row["NombreCliente"] + "|" + row["telefono"] + 
                                       row["nombre"] + "|" + row["fechainicio"] +
                                        row["fechafin"] + "|" + row["precio"] +
                                        row["cantidadhoras"] + "|" + row["descripcion"];
                }


                StreamWriter file = new StreamWriter(fullPath+"\\"+ fileName, true);
                file.WriteLine(CadenaDataTable);
                file.Close();
                response.code = "01";
                response.mensaje = "Archivo creado con exito";

            return response;

        }





        }


    
}
