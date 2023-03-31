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
    internal class UserDataService : IUserDataService
    {
        private IUserRepository _repository;
        private IMapper _mapper;

        public UserDataService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IBaseResponse<bool>> DeleteAsync(UserDTO entity)
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

                var mapData = _mapper.Map<User>(entity);
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

        public async Task<IBaseResponse<List<UserDTO>>> GetAllAsync()
        {
            try
            {
                var data = await _repository.GetAllAsync();
                var response = _mapper.Map<List<UserDTO>>(data);

                return new BaseResponse<List<UserDTO>>()
                {
                    Data = response,
                    Description = "Data received successfully.",
                    StatusCode = new OkResult()
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<UserDTO>>()
                {
                    Data = new List<UserDTO>(),
                    Description = ex.Message,
                    StatusCode = new BadRequestResult()
                };
            }
        }

        public async Task<IBaseResponse<UserDTO>> GetValueAsync(int id)
        {
            try
            {
                var data = await _repository.GetValueAsync(id);
                var response = _mapper.Map<UserDTO>(data);

                if (response == null)
                {
                    return new BaseResponse<UserDTO>()
                    {
                        Data = new UserDTO(),
                        StatusCode = new BadRequestResult(),
                        Description = "A value with this id doesn't exist"
                    };
                }

                return new BaseResponse<UserDTO>()
                {
                    Data = response,
                    Description = "The value was successfully found.",
                    StatusCode = new BadRequestResult()
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<UserDTO>()
                {
                    Data = new UserDTO(),
                    Description = ex.Message,
                    StatusCode = new BadRequestResult()
                };
            }
        }

        public async Task<IBaseResponse<bool>> CreateAsync(UserDTO entity)
        {
            try
            {
                var data = _mapper.Map<User>(entity);
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

        public async Task<IBaseResponse<bool>> UpdateAsync(UserDTO entity)
        {
            try
            {
                var data = _mapper.Map<User>(entity);
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
