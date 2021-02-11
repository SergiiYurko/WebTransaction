using AutoMapper;
using WebTransaction.Domain.Models;
using WebTransaction.Handlers.DTO;

namespace WebTransaction.Handlers.Helpers
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<FileInfoDTO, Transaction>();
        }
    }
}