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
    public class EmailNotificationController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            IEnumerable<EmailNotification> emailNotifications = unitOfWork.emailNotificationRepository.GetAll();
            return Ok(emailNotifications);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            EmailNotification emailNotification = unitOfWork.emailNotificationRepository.GetByID(id);
            if(emailNotification == null)
            {
                return NotFound();
            }
            return Ok(emailNotification);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]EmailNotification value)
        {
            try
            {
                unitOfWork.emailNotificationRepository.Create(value);
                unitOfWork.Save();// Persist data to database

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(value);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]EmailNotification value)
        {
            EmailNotification emailNotification= unitOfWork.emailNotificationRepository.GetByID(id);
            if(emailNotification == null)
            {
                return NotFound();
            }
            emailNotification.Name = value.Name;
           
            try
            {
                unitOfWork.emailNotificationRepository.Update(emailNotification);
                unitOfWork.Save();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(emailNotification);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                unitOfWork.emailNotificationRepository.Delete(id);
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