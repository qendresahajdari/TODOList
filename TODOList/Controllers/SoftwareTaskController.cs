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
    public class SoftwareTaskController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IEnumerable<SoftwareTask> softwareTasks = unitOfWork.softwareTaskRepository.GetAll();
            return Ok(softwareTasks);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            SoftwareTask softwareTask = unitOfWork.softwareTaskRepository.GetByID(id);
            if(softwareTask == null)
            {
                return NotFound();
            }
            return Ok(softwareTask);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]SoftwareTask value)
        {
            try
            {
                unitOfWork.softwareTaskRepository.Create(value);
                unitOfWork.Save();// Persist data to database

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(value);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]SoftwareTask value)
        {
            SoftwareTask softwareTask= unitOfWork.softwareTaskRepository.GetByID(id);
            if(softwareTask == null)
            {
                return NotFound();
            }
            softwareTask.Version = value.Version;
            softwareTask.Module = value.Module;
            
            try
            {
                unitOfWork.softwareTaskRepository.Update(softwareTask);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(softwareTask);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                unitOfWork.softwareTaskRepository.Delete(id);
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