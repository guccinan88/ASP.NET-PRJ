using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WIP_PRJ.Models;

namespace WIP_PRJ.Controllers
{
    public class WipController : ApiController
    {
        // GET: api/Wip
        WIPEntities db = new WIPEntities();
        public IEnumerable<WIP> Get()
        {
            var wip = db.WIP;
            return wip.ToList();
        }

        // GET: api/Wip/5
        public WIP Get(string id)
        {
            var wip = db.WIP.Where(m => m.Id == id).FirstOrDefault();
            return wip;
        }

        // POST: api/Wip
        public bool Post(string Id,string Model,string WorkStation,string Machine,int Total_Count,int Produced_Count)
        {
            bool status = true;
            try
            {
                WIP wipPost = new WIP();
                wipPost.Id = Id;
                wipPost.Model = Model;
                wipPost.WorkStation = WorkStation;
                wipPost.Machine = Machine;
                wipPost.Total_Count = Total_Count;
                wipPost.Produced_Count = Produced_Count;
                
                db.WIP.Add(wipPost);
                db.SaveChanges();
            }catch(Exception ex)
            {
                status = false;
            }
            return status;
        }

        // PUT: api/Wip/5
        public bool Put(string Id, string Model, string WorkStation, string Machine, int Total_Count, int Produced_Count)
        {
            bool status = true;
            try
            {
                var wipPut=db.WIP.Where(m=>m.Id==Id).FirstOrDefault();
                wipPut.Model = Model;
                wipPut.WorkStation = WorkStation;
                wipPut.Machine = Machine;
                wipPut.Total_Count = Total_Count;
                wipPut.Produced_Count = Produced_Count;
                db.SaveChanges();
            }catch(Exception ex)
            {
                status=false;
            }
            return status;
        }

        // DELETE: api/Wip/5
        public bool Delete(string id)
        {
            bool status = true;
            try
            {
                var wipDelete=db.WIP.Where(m=>m.Id==id).FirstOrDefault();
                db.WIP.Remove(wipDelete);
                db.SaveChanges();
            }catch(Exception ex)
            {
                status = false;
            }
            return status;
        }
    }
}
