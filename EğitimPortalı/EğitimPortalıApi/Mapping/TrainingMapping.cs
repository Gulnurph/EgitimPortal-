using AutoMapper;
using EntityLayer;
using EntityLayer.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EğitimPortalıApi.Mapping
{
	public class TrainingMapping : Profile
	{
		protected TrainingMapping()
		{
			CreateMap<CreateTrainingDto,Training>().ReverseMap();
			CreateMap<GetTrainingDto,Training>().ReverseMap();
			CreateMap<UpdateTrainingDto,Training>().ReverseMap();
		}
	}
}
