using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Application.ViewModels;
using Template.Domain.Entities;

namespace Template.Application.AutoMapper
{
    public class AutoMapperSetup: Profile
    {
        public AutoMapperSetup()
        {
            /*Usuário*/
            #region ViewModelToDomain
            CreateMap<UserViewModel, User>();
            #endregion

            #region DomainToViewModel
            CreateMap<User, UserViewModel>();
            #endregion

            #region ViewModel
            CreateMap<PersonViewModel, Person>();
            #endregion

            #region DomainModel
            CreateMap<Person, PersonViewModel>();
            #endregion

            #region View
            CreateMap<FretistaViewModel, Fretista>();
            #endregion

            #region Domain
            CreateMap<Fretista, FretistaViewModel>();
            #endregion
        }
    }
}
