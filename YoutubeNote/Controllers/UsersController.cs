using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using YoutubeNote.Models;

namespace YoutubeNote.Controllers
{
    public class UsersController : ApiController
    {
        private YoutubeNoteContext db = new YoutubeNoteContext();

        // GET: api/Users
        public IQueryable<Users> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult GetUsers(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsers(int id, Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.UsersId)
            {
                return BadRequest();
            }

            db.Entry(users).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [System.Web.Http.HttpPost]
        [ResponseType(typeof(Users))]
        public IHttpActionResult PostUsers(Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(users);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = users.UsersId }, users);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(Users))]
        public IHttpActionResult DeleteUsers(int id)
        {
            Users users = db.Users.Find(id);
            if (users == null)
            {
                return NotFound();
            }

            db.Users.Remove(users);
            db.SaveChanges();

            return Ok(users);
        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Users/GetNotes")]
        public IHttpActionResult GetNotes(Users user)
        {
            // ...
            var Name = user.Name;
            var Url = user.Url;
            var response = db.Users.Where(d => d.Name == Name && d.Url == Url);
            return Ok(response);

        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/Users/GetVideos")]
        public IHttpActionResult GetVideos(Users user)
        {
            // ...
            var Name = user.Name;
            var response = db.Users.Where(d => d.Name == Name).Select(x => new
            {
                Title = x.Title,
                Url = x.Url
            }).Distinct();
            return Ok(response);

        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/Users/RemoveNote")]
        public IHttpActionResult RemoveNote(Users user)
        {
            // ...
            var Name = user.Name;
            var Url = user.Url;
            var TimeStamp = user.TimeStamp;
            var response = db.Users.Where(d => d.Name == Name && d.Url == Url && d.TimeStamp == TimeStamp);
            foreach(var user1 in response)
            {
                db.Users.Remove(user1);
            }
            db.SaveChanges();
            return Ok(response);

        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/Users/RemoveVideo")]
        public IHttpActionResult RemoveVideo(Users user)
        {
            // ...
            var Name = user.Name;
            var Url = user.Url;
            var response = db.Users.Where(d => d.Name == Name && d.Url == Url);
            foreach (var user1 in response)
            {
                db.Users.Remove(user1);
            }
            db.SaveChanges();
            return Ok(response);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersExists(int id)
        {
            return db.Users.Count(e => e.UsersId == id) > 0;
        }
    }
}