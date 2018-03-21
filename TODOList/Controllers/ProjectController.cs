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
    public class ProjectController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IEnumerable<Project> projects = unitOfWork.projectRepository.GetAll();
            return Ok(projects);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            Project project = unitOfWork.projectRepository.GetByID(id);
            if(project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Project value)
        {
            try
            {
                unitOfWork.projectRepository.Create(value);
                unitOfWork.Save();// Persist data to database

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(value);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]Project value)
        {
            Project project = unitOfWork.projectRepository.GetByID(id);
            if(project == null)
            {
                return NotFound();
            }
            project.Description = value.Description;
            project.EndDate = value.EndDate;
            project.Name = value.Name;
            project.StartDate = value.StartDate;
            try
            {
                unitOfWork.projectRepository.Update(project);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(project);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                unitOfWork.projectRepository.Delete(id);
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