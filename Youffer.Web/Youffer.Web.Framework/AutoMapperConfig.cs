using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Youffer.Resources.Enum;
using Youffer.Resources.Models;
using Youffer.Resources.CRMModel;
using Youffer.Resources.ViewModel;
using Youffer.Web.Resources.ViewModel;
using Youffer.Web.Common.Extensions;
using Youffer.Web.Common.Helper;

namespace Youffer.Web.Framework
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.CreateMap<WebClientWishListModel, UserReviewsDto>()
                .ForMember(dest => dest.CompanyId, src => src.MapFrom(m => m.CompanyId))
                .ForMember(dest => dest.UserId, src => src.MapFrom(m => m.WishListId))
                .ForMember(dest => dest.Rating, src => src.MapFrom(m => m.Review.Rating.RateThis(true)))
                .ForMember(dest => dest.Feedback, src => src.MapFrom(m => m.Review.Message))
                .ForMember(dest => dest.CreatedBy, src => src.MapFrom(m => m.Review.CreatedBy))
                .ForMember(dest => dest.CreatedOn, src => src.MapFrom(m => m.Review.CreatedOn))
                .ForMember(dest => dest.ModifiedBy, src => src.MapFrom(m => m.Review.ModifiedBy))
                .ForMember(dest => dest.ModifiedOn, src => src.MapFrom(m => m.Review.ModifiedOn))
                .ForMember(dest => dest.Id, src => src.MapFrom(m => m.Review.Id))
                .ForMember(dest => dest.InterestName, src => src.MapFrom(m => m.PurchasedInterest))
                .ForMember(dest => dest.IsDeleted, src => src.MapFrom(m => m.Review.IsDeleted));

            Mapper.CreateMap<WebNoteModel, CompanyNotesDto>().ReverseMap();

            Mapper.CreateMap<UserResultModel, WebClientWishListModel>()
                .ForMember(dest => dest.Interest, src => src.MapFrom(s => s.MainInterest))
                .ForMember(dest => dest.WishListId, src => src.MapFrom(s => s.Id))
                .ForMember(dest => dest.Ranking, src => src.MapFrom(s => s.Rank.RateThis(false)))
                .ForMember(dest => dest.Client, src => src.MapFrom(s => Mapper.Map<UserResultModel, WebClientModel>(s)))
                .ForMember(dest => dest.ReviewList, src => src.MapFrom(s => Mapper.Map<List<UserReviewsDto>, List<WebClientReviewModel>>(s.UserReviews)))
                .ReverseMap()
                .ForMember(dest => dest.MainInterest, src => src.MapFrom(s => s.Interest))
                .ForMember(dest => dest.Id, src => src.MapFrom(s => s.WishListId))
                .ForMember(dest => dest.Rank, src => src.MapFrom(s => s.Ranking.RateThis(false)));



            Mapper.CreateMap<UserReviewsDto, WebClientReviewModel>()
                .ForMember(desc => desc.ClientWishListId, src => src.MapFrom(s => s.UserId))
                .ForMember(desc => desc.Message, src => src.MapFrom(s => s.Feedback))
                .ForMember(desc => desc.Rating, src => src.MapFrom(s => s.Rating.RateThis(true)));

            Mapper.CreateMap<UserResultModel, WebClientModel>()
              .ForMember(dest => dest.ClientId, src => src.MapFrom(s => s.Id))
              .ForMember(dest => dest.CountryName, src => src.MapFrom(s => s.CountryDetails.CountryName))
              .ForMember(dest => dest.FirstName, src => src.MapFrom(s => s.FirstName))
              .ForMember(dest => dest.Gender, src => src.MapFrom(s => s.Gender))
              .ForMember(dest => dest.ImageUrl, src => src.MapFrom(s => s.ImageURL))
              .ForMember(dest => dest.Interests, src => src.MapFrom(s => s.MainInterest))
              .ForMember(dest => dest.IsActive, src => src.MapFrom(s => s.IsActive))
              .ForMember(dest => dest.IsAvailable, src => src.MapFrom(s => s.IsAvailable))
              .ForMember(dest => dest.Ranking, src => src.MapFrom(s => s.Rank.RateThis(false)))
              .ForMember(dest => dest.WishListId, src => src.MapFrom(s => s.Id))
              .ForMember(dest => dest.Age, src => src.MapFrom(s => s.Birthday.ToAge()))
              .ForMember(dest => dest.PhoneNumber, src => src.MapFrom(s => s.Phone.ToPhoneNumber()))
              .ForMember(dest => dest.Flag, src => src.MapFrom(s => s.CountryDetails.ISO2.ToCountryFlag()))
              .ForMember(dest => dest.CanCall, src => src.MapFrom(s => s.CanCall))
              .ForMember(dest => dest.Availability, src => src.MapFrom(s => s.Availability))
              .ReverseMap();        

            Mapper.CreateMap<OrgResultModel, WebCompanyDashboardModel>()
                .ForMember(dest => dest.CompanyLogo, src => src.MapFrom(s => s.ImageURL))
                .ForMember(dest => dest.CompanyName, src => src.MapFrom(s => s.Name))
                .ForMember(dest => dest.SubBusinessType, src => src.MapFrom(s => s.MainBusinessType))
                .ReverseMap()
                .ForMember(dest => dest.ImageURL, src => src.MapFrom(s => s.CompanyLogo))
                .ForMember(dest => dest.Name, src => src.MapFrom(s => s.CompanyName))
                .ForMember(dest => dest.MainBusinessType, src => src.MapFrom(s => s.SubBusinessType));

            Mapper.CreateMap<OrganisationModel, WebCompanyProfileModel>()
                .ForMember(dest => dest.CompanyName, src => src.MapFrom(s => s.AccountName))
                .ForMember(dest => dest.CompanyId, src => src.MapFrom(s => s.Id))
                .ForMember(dest => dest.Country, src => src.MapFrom(s => s.BillCountry))
                .ForMember(dest => dest.FacebookUrl, src => src.MapFrom(s => s.FacebookURL))
                .ForMember(dest => dest.ImageUrl, src => src.MapFrom(s => s.ImageURL))
                .ForMember(dest => dest.PhoneNumber, src => src.MapFrom(s => s.Phone))
                .ForMember(dest => dest.SelectedMainBusinessTypes, src => src.MapFrom(s => s.MainBusinessType))
                .ForMember(dest => dest.SelectedSubBusinessTypes, src => src.MapFrom(s => s.SubBusinessType))
                .ForMember(dest => dest.WebsiteUrl, src => src.MapFrom(s => s.Website))
                .ReverseMap()
                .ForMember(dest => dest.AccountName, src => src.MapFrom(s => s.CompanyName))
                .ForMember(dest => dest.Id, src => src.MapFrom(s => s.CompanyId))
                .ForMember(dest => dest.BillCountry, src => src.MapFrom(s => s.Country))
                .ForMember(dest => dest.FacebookURL, src => src.MapFrom(s => s.FacebookUrl))
                .ForMember(dest => dest.ImageURL, src => src.MapFrom(s => s.ImageUrl))
                .ForMember(dest => dest.Phone, src => src.MapFrom(s => s.PhoneNumber))
                .ForMember(dest => dest.MainBusinessType, src => src.MapFrom(s => s.SelectedMainBusinessTypes))
                .ForMember(dest => dest.SubBusinessType, src => src.MapFrom(s => s.SelectedSubBusinessTypes))
                .ForMember(dest => dest.Website, src => src.MapFrom(s => s.WebsiteUrl));

            Mapper.CreateMap<OrgResultModel, WebCompanyProfileModel>()
                .ForMember(dest => dest.CompanyId, src => src.MapFrom(s => s.Id))
                .ForMember(dest => dest.CompanyName, src => src.MapFrom(s => s.Name))
                .ForMember(dest => dest.Country, src => src.MapFrom(s => s.CountryDetails.CountryName))
                .ForMember(dest => dest.FacebookUrl, src => src.MapFrom(s => s.FacebookURL))
                .ForMember(dest => dest.ImageUrl, src => src.MapFrom(s => s.ImageURL))
                .ForMember(dest => dest.PhoneNumber, src => src.MapFrom(s => s.Phone))
                .ForMember(dest => dest.SelectedMainBusinessTypes, src => src.MapFrom(s => s.MainBusinessType))
                .ForMember(dest => dest.SelectedSubBusinessTypes, src => src.MapFrom(s => s.SubBusinessType))
                .ForMember(dest => dest.WebsiteUrl, src => src.MapFrom(s => s.Website))
                .ReverseMap()
                .ForMember(dest => dest.Id, src => src.MapFrom(s => s.CompanyId))
                .ForMember(dest => dest.Name, src => src.MapFrom(s => s.CompanyName))
                .ForMember(dest => dest.CountryDetails, src => src.MapFrom(s => Mapper.Map<WebCompanyProfileModel, CountryModel>(s)))
                .ForMember(dest => dest.FacebookURL, src => src.MapFrom(s => s.FacebookUrl))
                .ForMember(dest => dest.ImageURL, src => src.MapFrom(s => s.ImageUrl))
                .ForMember(dest => dest.Phone, src => src.MapFrom(s => s.PhoneNumber))
                .ForMember(dest => dest.MainBusinessType, src => src.MapFrom(s => s.SelectedMainBusinessTypes))
                .ForMember(dest => dest.SubBusinessType, src => src.MapFrom(s => s.SelectedSubBusinessTypes))
                .ForMember(dest => dest.Website, src => src.MapFrom(s => s.WebsiteUrl));

            Mapper.CreateMap<CountryModel, WebCompanyProfileModel>()
                .ForMember(dest => dest.Country, src => src.MapFrom(s => s.CountryName))
                .ReverseMap()
                .ForMember(dest => dest.CountryName, src => src.MapFrom(s => s.Country));

            Mapper.CreateMap<UserModel, WebRegisterModel>()
                .ForMember(dest => dest.CompanyName, src => src.MapFrom(s => s.Name))
                .ForMember(dest => dest.ConfirmPassword, src => src.MapFrom(s => s.ConfirmPassword))
                .ForMember(dest => dest.Email, src => src.MapFrom(s => s.EmailId))
                .ForMember(dest => dest.Password, src => src.MapFrom(s => s.Password))
                .ForMember(dest => dest.Role, src => src.MapFrom(s => s.Role))
                .ForMember(dest => dest.Timezone, src => src.MapFrom(s => s.Timezone))
                .ForMember(dest => dest.Country, src => src.MapFrom(s => s.Country))
                .ForMember(dest => dest.OSType, src => src.MapFrom(s => s.OSType))
                .ForMember(dest => dest.SubBusinessType, src => src.MapFrom(s => s.SubBusinessType))
                .ForMember(dest => dest.PhoneNumber, src => src.MapFrom(s => s.Phone))
                .ReverseMap()
                .ForMember(dest => dest.Name, src => src.MapFrom(s => s.CompanyName))
                .ForMember(dest => dest.ConfirmPassword, src => src.MapFrom(s => s.ConfirmPassword))
                .ForMember(dest => dest.EmailId, src => src.MapFrom(s => s.Email))
                .ForMember(dest => dest.Password, src => src.MapFrom(s => s.Password))
                .ForMember(dest => dest.Role, src => src.MapFrom(s => s.Role))
                .ForMember(dest => dest.Timezone, src => src.MapFrom(s => s.Timezone))
                .ForMember(dest => dest.Country, src => src.MapFrom(s => s.Country))
                .ForMember(dest => dest.OSType, src => src.MapFrom(s => s.OSType))
                .ForMember(dest => dest.MainBusinessType, src => src.MapFrom(s => s.SelectedBusinessType))
                .ForMember(dest => dest.SubBusinessType, src => src.MapFrom(s => s.SubBusinessType))
                .ForMember(dest => dest.Phone, src => src.MapFrom(s => s.PhoneNumber));

            Mapper.CreateMap<WebRegisterModel, LoginModel>().ReverseMap();

            Mapper.CreateMap<WebYoufferUserModel, WebFormLoginResultModel>().ReverseMap();



            // under working pankaj nema
            Mapper.CreateMap<PurchasedClientsDto, WebClientWishListModel>()
                .ForMember(dest => dest.WishListId, src => src.MapFrom(s => s.ClientId))
                .ForMember(dest => dest.PurchasedInterest, src => src.MapFrom(s => s.Interest))
                .ForMember(dest => dest.Client, src => src.MapFrom(s => Mapper.Map<PurchasedClientsDto, WebClientModel>(s)))
                .ForMember(dest => dest.Rating, src => src.MapFrom(s => Mapper.Map<PurchasedClientsDto, WebRatingModel>(s)))
                .ForMember(dest => dest.Ranking, src => src.MapFrom(s => s.Rank.RateThis(false)))
                .ForMember(dest => dest.Review, src => src.MapFrom(s => Mapper.Map<PurchasedClientsDto, WebClientReviewModel>(s)))
                .ReverseMap();

            Mapper.CreateMap<PurchasedClientsDto, WebRatingModel>()
                .ForMember(dest => dest.Rating, src => src.MapFrom(s => s.Rating.RateThis(false)))
                .ReverseMap()
                .ForMember(dest => dest.Rating, src => src.MapFrom(s => s.Rating));

            Mapper.CreateMap<PurchasedClientsDto, WebClientReviewModel>()
                .ForMember(dest => dest.ClientWishListId, src => src.MapFrom(s => s.ClientId))
                .ForMember(dest => dest.Message, src => src.MapFrom(s => s.Review))
                .ForMember(dest => dest.Rating, src => src.MapFrom(s => s.Rating))
                .ReverseMap()
                .ForMember(dest => dest.ClientId, src => src.MapFrom(s => s.ClientWishListId))
                .ForMember(dest => dest.Review, src => src.MapFrom(s => s.Message))
                .ForMember(dest => dest.Rating, src => src.MapFrom(s => s.Rating));


            Mapper.CreateMap<PurchasedClientsDto, WebClientModel>()
                .ForMember(dest => dest.WishListId, src => src.MapFrom(s => s.ClientId))
                .ForMember(dest => dest.FirstName, src => src.MapFrom(s => s.Name))
                .ForMember(dest => dest.Age, src => src.MapFrom(s => s.BirthDay.ToAge()))
                .ForMember(dest => dest.Gender, src => src.MapFrom(s => s.Gender))
                .ForMember(dest => dest.Ranking, src => src.MapFrom(s => s.Rank.RateThis(false)))
                .ForMember(dest => dest.PhoneNumber, src => src.MapFrom(s => s.PhoneNumber.ToPhoneNumber()))
                .ForMember(dest => dest.CanCall, src => src.MapFrom(s => s.CanCall)).ReverseMap();


            Mapper.CreateMap<MessagesDto, WebMessageModel>()
                .ForMember(dest => dest.MessageId, src => src.MapFrom(s => s.ThreadId))
                .ForMember(dest => dest.CreatedOn, src => src.MapFrom(s => s.CreatedOn))
                .ForMember(dest => dest.ImageUrl, src => src.MapFrom(s => s.FromUser.ToLower().Trim().Replace(" ", string.Empty).Equals(GlobalConstants.SuperAdmin.ToLower()) || s.ToUser.ToLower().Trim().Replace(" ", string.Empty).Equals(GlobalConstants.SuperAdmin.ToLower()) ? GlobalConstants.SuperAdmin.GetSuperAdminImage() : s.ToUser.GetFacebookUrl()))
                .ForMember(dest => dest.Name, src => src.MapFrom(s => s.FromUser.ToLower().Trim().Replace(" ", string.Empty).Equals(GlobalConstants.SuperAdmin.ToLower()) || s.ToUser.ToLower().Trim().Replace(" ", string.Empty).Equals(GlobalConstants.SuperAdmin.ToLower()) ? GlobalConstants.SuperAdmin : s.Name))
                .ForMember(dest => dest.MessageDescription, src => src.MapFrom(s => s.Message))
                .ForMember(dest => dest.ClientWishListId, src => src.MapFrom(s => s.FromUser.ToLower().Trim().Replace(" ", string.Empty).Equals(GlobalConstants.SuperAdmin.ToLower()) || s.ToUser.ToLower().Trim().Replace(" ", string.Empty).Equals(GlobalConstants.SuperAdmin.ToLower()) ? GlobalConstants.SuperAdmin : s.UserId))
                .ReverseMap()
                .ForMember(dest => dest.ThreadId, src => src.MapFrom(s => s.MessageId))
                .ForMember(dest => dest.Message, src => src.MapFrom(s => s.MessageDescription))
                .ForMember(dest => dest.ToUser, src => src.MapFrom(s => s.ClientWishListId));
        }
    }
}
