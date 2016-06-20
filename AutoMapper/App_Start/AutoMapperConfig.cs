using AutoMapper;
using AutoMapper.Models;
using AutoMapper.Context;

namespace AutoMapper.App_Start
{

    // всю настройку AutoMapperа мы можем вынести в отдельный класс,
    // чтобы сделать код контроллеров проще
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<User, IndexUserViewModel>();

            Mapper.CreateMap<CreateUserViewModel, User>()
                    .ForMember("Name", opt => opt.MapFrom(c => c.FirstName + " " + c.LastName))
                    .ForMember("Email", opt => opt.MapFrom(src => src.Login));

            Mapper.CreateMap<User, EditUserViewModel>()
               .ForMember("Login", opt => opt.MapFrom(src => src.Email));

            Mapper.CreateMap<EditUserViewModel, User>()
               .ForMember("Email", opt => opt.MapFrom(src => src.Login));
        }

        // И чтобы применить этот класс, нам надо вызвать метод RegisterMappings
        // в файле Global.asax в методе Application_Start
    }
}