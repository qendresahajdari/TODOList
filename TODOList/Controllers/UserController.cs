using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TODOList.Domain;
using TODOList.Exceptions;
using TODOList.Repository;

namespace TODOList
{
    public class UserController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IEnumerable<User> users = unitOfWork.userRepository.GetAll();
            return Ok(users);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            User user = unitOfWork.userRepository.GetByID(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]User value)
        {
            try
            {
                User existUser = unitOfWork.userRepository.GetByUserName(value.UserName);
                if (existUser != null)
                {
                    throw new InvalidUserException(value.UserName);
                }

                unitOfWork.userRepository.Create(value);
                unitOfWork.Save();// Persist data to database

            }catch (InvalidUserException ue) {
                return BadRequest(ue.Message);
            }catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(value);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]User value)
        {
            User user = unitOfWork.userRepository.GetByID(id);
            if(user == null)
            {
                return NotFound();
            }
            user.UserName = value.UserName;
            user.Password = value.Password;
            user.RoleId = value.RoleId;
            user.Role = value.Role;
            
            try
            {
                unitOfWork.userRepository.Update(user);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(user);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                unitOfWork.userRepository.Delete(id);
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