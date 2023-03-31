using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using BLL.Interfaces.DataServices;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BLL.Services.Data
{
    internal class ForumDataService : IForumDataServcie
    {
        private IForumRepository _repository;
        private IMapper _mapper;

        public ForumDataService(IForumRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IBaseResponse<bool>> DeleteAsync(ForumDTO entity)
        {
            try
            {
                if (entity == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Data = false,
                        StatusCode = new NotFoundResult(),
                        Description = "Null object"
                    };
                }

                var mapData = _mapper.Map<Forum>(entity);
                var response = await _repository.DeleteAsync(mapData);

                return new BaseResponse<bool>()
                {
                    Data = response,
                    StatusCode = new OkResult(),
                    Description = "Ok result"
                };
            }
            catch
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    StatusCode = new BadRequestResult(),
                    Description = "Inevitable error"
                };
            }
        }

        public async Task<IBaseResponse<List<ForumDTO>>> GetAllAsync()
        {
            try
            {
                var data = await _repository.GetAllAsync();
                var response = _mapper.Map<List<ForumDTO>>(data);

                return new BaseResponse<List<ForumDTO>>()
                {
                    Data = response,
                    Description = "Data received successfully.",
                    StatusCode = new OkResult()
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<ForumDTO>>()
                {
                    Data = new List<ForumDTO>(),
                    Description = ex.Message,
                    StatusCode = new BadRequestResult()
                };
            }
        }

        public async Task<IBaseResponse<ForumDTO>> GetValueAsync(int id)
        {
            try
            {
                var data = await _repository.GetValueAsync(id);
                var response = _mapper.Map<ForumDTO>(data);

                if (response == null)
                {
                    return new BaseResponse<ForumDTO>()
                    {
                        Data = new ForumDTO(),
                        StatusCode = new BadRequestResult(),
                        Description = "A value with this id doesn't exist"
                    };
                }

                return new BaseResponse<ForumDTO>()
                {
                    Data = response,
                    Description = "The value was successfully found.",
                    StatusCode = new BadRequestResult()
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<ForumDTO>()
                {
                    Data = new ForumDTO(),
                    Description = ex.Message,
                    StatusCode = new BadRequestResult()
                };
            }
        }

        public async Task<IBaseResponse<bool>> CreateAsync(ForumDTO entity)
        {
            try
            {
                var data = _mapper.Map<Forum>(entity);
                var response = await _repository.CreateAsync(data);

                return new BaseResponse<bool>()
                {
                    Data = response,
                    Description = "The value was successfully added.",
                    StatusCode = new OkResult()
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Description = ex.Message,
                    StatusCode = new BadRequestResult()
                };
            }
        }

        public async Task<IBaseResponse<bool>> UpdateAsync(ForumDTO entity)
        {
            try
            {
                var data = _mapper.Map<Forum>(entity);
                var response = await _repository.UpdateAsync(data);

                return new BaseResponse<bool>()
                {
                    Data = response,
                    Description = "The value information was successfully updates.",
                    StatusCode = new OkResult()
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Data = false,
                    Description = ex.Message,
                    StatusCode = new BadRequestResult()
                };
            }
        }
    }
}
