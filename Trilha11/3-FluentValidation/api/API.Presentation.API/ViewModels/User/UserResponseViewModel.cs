using System;
using System.ComponentModel.DataAnnotations;
using API.Presentation.API.ViewModels.Utils;

namespace API.Presentation.API.ViewModels.User
{
    public class UserReponseViewModel 
    {  
        public string Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public GenericComboboxViewModel Profile { get; set; }
    }
}