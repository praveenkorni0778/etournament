using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using etournament.Api.DataAccess;
using etournament.Models;

namespace etournament.Controllers
{
    public class TournamentController : ApiController
    {
        // GET api/<controller>
        List<TournamentModel> quizList = new List<TournamentModel>();
        DataAccess quizDataAccess = new DataAccess();
        // GET: Quiz

        public IEnumerable<TournamentModel> Get()
        {
            DataTable dt;
            dt = quizDataAccess.Get();
            foreach (DataRow dr in dt.Rows)
            {
                TournamentModel obj = new TournamentModel();
                obj.t_id = (int)(dr["t_id"]);
                obj.t_name = (string)(dr["t_name"]);
                obj.t_website = (string)(dr.IsNull("t_website") ? -1 : dr["t_contact"]); ;
                obj.t_dts = (DateTime)(dr["t_dts"]);
                obj.t_dte = (DateTime)(dr["t_dte"]);
                obj.t_image = (string)(dr["t_image"]);
                obj.t_fk = (int)(dr["t_fk"]);
                obj.t_cat = (int)(dr["t_cat"]);
                obj.t_contact = (string)(dr.IsNull("t_contact") ? -1 : dr["t_contact"]);
                obj.t_desc = (string)(dr["t_desc"]);
                obj.t_location = (string)(dr["t_location"]);
                obj.t_entryfee = (string)(dr["t_entryfee"]);
                obj.t_prize = (string)(dr["t_prize"]);
                quizList.Add(obj);
            }
            return quizList;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}