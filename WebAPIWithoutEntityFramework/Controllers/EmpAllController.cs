using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CompleteWebAPIApp.Models;

namespace CompleteWebAPIApp.Controllers
{
    public class EmpAllController : ApiController
    {

        ContextDB cd = new ContextDB();
        
        // GET: api/EmpAll
        [HttpGet]
        public IEnumerable<EmpModelClass> Get()
        {
            return cd.Get().ToList();
        }

        // GET: api/EmpAll/5
        [HttpGet]
        public IEnumerable<EmpModelClass> Get(string id)
        {
            yield return cd.Get().Where(Models => Models.ID == id).FirstOrDefault();
        }

        // POST: api/EmpAll
        [HttpPost]
        public bool Post(EmpModelClass obj)
        {
            if (ModelState.IsValid == true)
            {
               return cd.Add(obj);
            }
            else
            {
                return false;
            }
        }

        // PUT: api/EmpAll/5
        public void Put(string id, EmpModelClass obj)
        {
            if(ModelState.IsValid == true)
            {
                cd.Edit(id, obj);
            }
        }

        // DELETE: api/EmpAll/5
        public void Delete(string id)
        {

            if (ModelState.IsValid == true)
            {
                cd.Delete(int.Parse(id));
            }

        }
    }
}
