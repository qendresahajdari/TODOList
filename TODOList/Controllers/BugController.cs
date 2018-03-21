using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TODOList.Domain;
using TODOList.Repository;

namespace TODOList
{
    public class BugController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IEnumerable<Bug> bugs = unitOfWork.bugRepository.GetAll();
            return Ok(bugs);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            Bug bug = unitOfWork.bugRepository.GetByID(id);
            if(bug == null)
            {
                return NotFound();
            }
            return Ok(bug);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Bug value)
        {
            try
            {
                unitOfWork.bugRepository.Create(value);
                unitOfWork.Save();// Persist data to database

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(value);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]Bug value)
        {
            Bug bug = unitOfWork.bugRepository.GetByID(id);
            if(bug == null)
            {
                return NotFound();
            }
            bug.BugType = value.BugType;
            
            try
            {
                unitOfWork.bugRepository.Update(bug);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(bug);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                unitOfWork.bugRepository.Delete(id);
                unitOfWork.Save();// Persist data to database
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}