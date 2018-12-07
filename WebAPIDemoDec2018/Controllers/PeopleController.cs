using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDemoDec2018.Models;

//you created this controller. rt-click on "controllers"
//then select specific thing you want (here, an API with read/write)
//the defaults are like the values controller
//you can change them, add more, etc
//and in fact, we ARE changing them to match our model Person

namespace WebAPIDemoDec2018.Controllers
{
    public class PeopleController : ApiController
    {
        //this is ours:
        List<Person> people = new List<Person>();

        //so is this:
        public PeopleController()
        {
            //this will "fake" a database by creating entries
            //in a real program, the data would come from the db
            //altho teacher says the program shouldn't even address the db
            //but should go through a library instead
            //(outside the scope of this tutorial)
            people.Add(new Person
            {
                FirstName = "Tim",
                LastName = "Corey",
                Id = 1
            });

            people.Add(new Person
            {
                FirstName = "Susan",
                LastName = "Richards",
                Id = 2
            });

            people.Add(new Person
            {
                FirstName = "Bob",
                LastName = "Dole",
                Id = 3
            });
        }

        //what if we want to make a special GET command?
        //like, a list of all first names?

        //the first line is what will "call" this method from the URL
        //note you can name this anything you want
        //but it will get confusing if you get too cute.
        [Route("api/people/GetFirstNames")]
        //and we decide what type of http type we will accept:
        //we could do more than one, but we'll just use Get
        //(you added Post to see what would happen. It's fine.)
        [HttpGet, HttpPost]
        //here is the logic for it.
        public List<string> GetFirstNames()
        {
            List<string> output = new List<string>();

            foreach (var p in people)
            {
                output.Add(p.FirstName);
            }

            return output;
        }

        //another, for practice:
        //this one allows for passing of more than one value
        //HEY! triple-slash to create the following comment template:
        //you have to fill in some of the info.
        //shows up on the help pages of your application.
        /// <summary>
        /// Gets a list of all last names of users.
        /// </summary>
        /// <param name="userId">The unique identifier for this person.</param>
        /// <param name="age">This person's age.</param>
        /// <returns>A list of last names.</returns>
        [Route("api/people/GetLastNames/{userId:int}/{age:int}")]
        [HttpGet]
        public List<string> GetLastNames(int userId, int age)
        {
            List<string> output = new List<string>();

            foreach (var p in people)
            {
                output.Add(p.LastName);
            }

            return output;
        }



        //make sure you change the default data types
        //here, we change to List<Person> or Person, as required.

        // GET: api/People
        public List<Person> Get()
        {
            //return new string[] { "value1", "value2" };
            //instead, return our list of People (created above)
            return people;
        }

        // GET: api/People/5
        public Person Get(int id)
        {
            return people.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/People
        public void Post(Person val)
        {
            people.Add(val);
        }

        // PUT: api/People/5
        public void Put(int id, [FromBody]string value)
        {
            //we'll ignore this for the tutorial
        }

        // DELETE: api/People/5
        public void Delete(int id)
        {
        }
    }
}

//a related topic (which I THINK I get...):
//don't use GET to show all data. why?
//say a person signed up for a website and created a password
//if it's in GET, it could be seen in a URL
//via that "?stringOfStuff"
//ditto other sensitive info.
//put sensitive stuff in POST instead; it won't show up in URL
//he doesn't give a demo, tho.