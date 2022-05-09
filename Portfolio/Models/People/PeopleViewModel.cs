using System.Collections.Generic;

namespace Portfolio.Models
{
    public class PeopleViewModel
    {

        public List<Person> peopleList = GetPeopleList();

        public static List<Person> GetPeopleList()
        {

            var persons = new List<Person>()
            {
                new Person() { Name = "Anders Samuelsson", City = "Gothenburg", PhoneNumber = "004631152659", Id = 1 },
                new Person() { Name = "Jens Rasmussen", City = "Copenhagen", PhoneNumber = "0047454862", Id = 2 },
                new Person() { Name = "Ole Bramserud", City = "Oslo", PhoneNumber = "0045786525", Id = 3 },
                
            };

            return persons;

        }

        public List<Person> PeopleList { get; set; }

        public CreatePersonViewModel person = new CreatePersonViewModel();

        public PeopleViewModel()
        {
            PeopleList = new List<Person>(peopleList);
           
        }
    }

    public static class PeopleList
    {
        public static List<Person> _list;

        static PeopleList()
        {

            _list = PeopleViewModel.GetPeopleList();
        }


    }


}