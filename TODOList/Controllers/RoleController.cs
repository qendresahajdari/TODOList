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
    public class RoleController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IEnumerable<Role> roles = unitOfWork.roleRepository.GetAll();
            return Ok(roles);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            Role role = unitOfWork.roleRepository.GetByID(id);
            if(role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Role value)
        {
            try
            {
                unitOfWork.roleRepository.Create(value);
                unitOfWork.Save();// Persist data to database

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(value);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]Role value)
        {
            Role role = unitOfWork.roleRepository.GetByID(id);
            if(role == null)
            {
                return NotFound();
            }
            role.Name = value.Name;
            role.Description = value.Description;
          
            try
            {
                unitOfWork.roleRepository.Update(role);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(role);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                unitOfWork.roleRepository.Delete(id);
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