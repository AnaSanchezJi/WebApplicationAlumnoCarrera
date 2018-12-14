using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebApplicationAlumnoCarrera.Models;

namespace WebApplicationAlumnoCarrera.Areas.AlumnoCarrera.Services
{
    public class SrvAlumnoCarreraList
    {
        HttpClient FiClient;

        public SrvAlumnoCarreraList()
        {
            this.FiClient = new HttpClient();
            this.FiClient.BaseAddress = new Uri("https://localhost:44380/");
            this.FiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //Lista Edificio 100%
        public async Task<List<list_AlumnoCarrera>> FicGetListAlumnoCarrera()
        {
            HttpResponseMessage FicResponse = await this.FiClient.GetAsync("api/ListaAlumnoCarrera");
            if (FicResponse.IsSuccessStatusCode)
            {
                var FicRespuesta = await FicResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<list_AlumnoCarrera>>(FicRespuesta);
            }
            return new List<list_AlumnoCarrera>();
        }
              
        //Detallle Edificio 100%
        public async Task<eva_alumnos_carreras> FicGetDetailAlumnoCarrera(int id)
        {
            HttpResponseMessage FicResponse = await this.FiClient.GetAsync("api/GetAlumnoCarrera/" + id);
            if (FicResponse.IsSuccessStatusCode)
            {
                var FicRespuesta = await FicResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<eva_alumnos_carreras>(FicRespuesta);
            }
            return new eva_alumnos_carreras();
        }
        //Detalle 100%----------------------------------------------------------------------------------
        public async Task<detalle_AlumnoCarrera> DetailAlumnoCarrera(int id)
        {
            HttpResponseMessage FicResponse = await this.FiClient.GetAsync("api/GetDetallesAlumnoCarrera/" + id);
            if (FicResponse.IsSuccessStatusCode)
            {
                var FicRespuesta = await FicResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<detalle_AlumnoCarrera>(FicRespuesta);
            }
            return new detalle_AlumnoCarrera();
        }
        //Eliminar Edificio Pantalla modal -------------------------------------------------------------       
        public async Task<string> FicAlumnoCarreraDelete(Int32 id)
        {
            HttpResponseMessage FicRespuesta = await this.FiClient.DeleteAsync("api/" + id);
            if (FicRespuesta.IsSuccessStatusCode)
            {
                return "OK";
            }
            return "ERROR";
        }
        //Editar Combos con item -----------------------------------------------------------------------
        public async Task<eva_alumnos_carreras> FicAlumnoCarreraUpdate(eva_alumnos_carreras edificio)
        {
            edificio.FechaUltMod = DateTime.Now;
            edificio.UsuarioMod = "Paty";
            edificio.Activo = "S";
            edificio.Borrado = "N";

            var json = JsonConvert.SerializeObject(edificio);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var respuestaPut = await FiClient.PutAsync("api/" + edificio.IdAlumno, content);
            if (respuestaPut.IsSuccessStatusCode)
            {
                return edificio;
            }
            return null;
        }
        //Nuevo Edificio Validar fechas, alumno autocomplementable---------------------------------------       
        public async Task<eva_alumnos_carreras> FicAlumnoCarreraCreate(eva_alumnos_carreras edificio)
        {
            edificio.IdTipoGenPlanEstudio = 25;
            edificio.IdTipoGenOpcionTitulacion = 27;
            edificio.IdTipoGenNivelEscolar = 17;
            edificio.IdTipoGenIngreso = 28;
            edificio.FechaReg = DateTime.Now;
            edificio.FechaUltMod = DateTime.Now;
            edificio.UsuarioReg = "Ana";
            edificio.UsuarioMod = "Ana";
            edificio.Activo = "S";
            edificio.Borrado = "N";

            var FicJson = JsonConvert.SerializeObject(edificio);
            var FiContent = new StringContent(FicJson, Encoding.UTF8, "application/json");
            var FicRespuesta = await FiClient.PostAsync("api/AddAlumnoCarrera", FiContent);
            if (FicRespuesta.IsSuccessStatusCode)
            {
                return edificio;
            }
            return null;
        }
    }
}
