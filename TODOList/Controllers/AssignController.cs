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
    public class AssignController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IEnumerable<Assign> assigns = unitOfWork.assignRepository.GetAll();
            return Ok(assigns);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            Assign assign = unitOfWork.assignRepository.GetByID(id);
            if(assign == null)
            {
                return NotFound();
            }
            return Ok(assign);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Assign value)
        {
            try
            {
                unitOfWork.assignRepository.Create(value);
                unitOfWork.Save();// Persist data to database

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(value);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]Assign value)
        {
            Assign assign = unitOfWork.assignRepository.GetByID(id);
            if(assign == null)
            {
                return NotFound();
            }
            assign.BaseTaskId = value.BaseTaskId;
            assign.PersonId = value.PersonId;
            assign.Description = value.Description;
            assign.Status = value.Status;
            assign.Date = value.Date;
            assign.Person = value.Person;
            assign.BaseTask = value.BaseTask;
           
            try
            {
                unitOfWork.assignRepository.Update(assign);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(assign);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                unitOfWork.assignRepository.Delete(id);
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