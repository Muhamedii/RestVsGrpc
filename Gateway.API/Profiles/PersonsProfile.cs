using AutoMapper;
using Gateway.API.Models;
using Google.Protobuf.Collections;

namespace Gateway.API.Profiles
{
    public class PersonsProfile : Profile
    {
        public PersonsProfile()
        {
            try
            {
                CreateMap<Service.Grpc.Person, Person>();
            }
            catch (Exception ex)
            {

            }
            CreateMap<RepeatedField<Service.Grpc.Person>, List<Person>>();
        }
    }
}
