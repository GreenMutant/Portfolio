using System.Collections.Generic;

namespace Portfolio.Models
{
    public class PeopleViewModel
    {

        public List<PersonE> peopleList = GetPeopleList();

        public static List<PersonE> GetPeopleList()
        {

            var persons = new List<PersonE>()
            {
                new PersonE() { Name = "Anders Samuelsson", City = "Gothenburg", PhoneNumber = "004631152659", Id = 1 },
                new PersonE() { Name = "Jens Rasmussen", City = "Copenhagen", PhoneNumber = "0047454862", Id = 2 },
                new PersonE() { Name = "Ole Bramserud", City = "Oslo", PhoneNumber = "0045786525", Id = 3 },
                
            };

            return persons;

        }

        public CreatePersonViewModel person = new CreatePersonViewModel();

    }

    public static class PeopleList
    {
        public static List<PersonE> _list;

        static PeopleList()
        {

            _list = PeopleViewModel.GetPeopleList();
        }


    }
}