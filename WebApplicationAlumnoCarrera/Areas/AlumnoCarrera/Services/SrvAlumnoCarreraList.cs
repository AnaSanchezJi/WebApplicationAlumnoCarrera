﻿using Newtonsoft.Json;
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
        public async Task<List<eva_alumnos_carreras>> FicGetListAlumnoCarrera()
        {
            HttpResponseMessage FicResponse = await this.FiClient.GetAsync("api/GetAlumnoCarrera");
            if (FicResponse.IsSuccessStatusCode)
            {
                var FicRespuesta = await FicResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<eva_alumnos_carreras>>(FicRespuesta);

            }
            return new List<eva_alumnos_carreras>();
        }


        //Detallle Edificio 100%
        public async Task<eva_alumnos_carreras> FicGetDetailAlumnoCarrera(int id)
        {
            HttpResponseMessage FicResponse = await this.FiClient.GetAsync("api/" + id);
            if (FicResponse.IsSuccessStatusCode)
            {
                var FicRespuesta = await FicResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<eva_alumnos_carreras>(FicRespuesta);
            }
            return new eva_alumnos_carreras();
        }

        //Eliminar Edificio -----------------------------------------       
        public async Task<string> FicAlumnoCarreraDelete(short id)
        {
            HttpResponseMessage FicRespuesta = await this.FiClient.DeleteAsync("api/" + id);
            return FicRespuesta.IsSuccessStatusCode ? "OK" : "ERROR";
        }


        //Editar-------------------------------------------------------------------
        public async Task<eva_alumnos_carreras> FicAlumnoCarreraUpdate(eva_alumnos_carreras edificio)
        {
            edificio.FechaUltMod = DateTime.Now;
            edificio.UsuarioMod = "Paty";

            var json = JsonConvert.SerializeObject(edificio);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var respuestaPut = await FiClient.PutAsync("api/" + edificio.IdAlumno, content);
            if (respuestaPut.IsSuccessStatusCode)
            {
                return edificio;
            }
            return null;
        }

        //Nuevo Edificio ------------------------------------------------------------------       
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
