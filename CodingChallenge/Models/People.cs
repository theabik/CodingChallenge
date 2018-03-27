using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web.Script.Serialization;

namespace CodingChallenge.Models
{
    public class People
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public List<Pet> Pets { get; set; }


        internal static List<People> GetAllPeopleWithPets()
        {
            List<People> output = null;
            try
            {
                using (var client = new WebClient())
                {
                    var uri = new Uri(ConfigurationManager.AppSettings["JsonService.URL"]);
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string json = client.DownloadString(uri);
                    output = (new JavaScriptSerializer()).Deserialize<List<People>>(json);
                }
            }
            catch (Exception ex)
            {
                //handle exception via email or file
            }
            return output;
        }

        internal static PetsViewModel GetOrderedPetsWithOwnersGender()
        {
            var viewModel = new PetsViewModel();
            try
            {
                List<People> people = GetAllPeopleWithPets();
                IEnumerable<dynamic> petsList = people
                    .Where(a => a.Pets != null)
                            .SelectMany(a => a.Pets.Where(b => b.Type.Equals("Cat"))
                                        .Select(b =>
                                       new
                                       {
                                           OwnerGender = a.Gender,
                                           PetName = b.Name
                                       }
                                       ))
                            .OrderBy(b => b.PetName)
                            .Distinct()
                            .GroupBy(c => c.OwnerGender)
                            .Select(a => new
                                {
                                    Key = a.Key,
                                    Items = a
                                })
                            .ToList();
                viewModel.PetsList = petsList;
            }
            catch (Exception ex)
            {
                //handle exception via email or file
            }
            return viewModel;
        }
    }
}