using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Contracts.User;
using WebApi.Models.User;

namespace PDD.NET.WebHost.Controllers
{
    /// <summary>
    /// Пользователи
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UsersController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Получить данные всех пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        [HttpGet]
        public async Task<List<UserModel>> GetAllEntitiesAsync()
        {
            return _mapper.Map<List<UserModel>>(await _service.GetAllAsync());
        }

        /// <summary>
        /// Получить данные пользователя по Id
        /// </summary>
        /// <returns>Данные пользователя</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEntityByIdAsync(int id)
        {
            var entity = _mapper.Map<UserModel>(await _service.GetByIdAsync(id));
            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(entity);
        }

        /// <summary>
        /// Создать нового пользователя по модели из запроса
        /// </summary>
        /// <param name="model">Модель из запроса</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateEntityAsync(CreatingUserModel model)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreatingUserDTO>(model)));
        }

        /// <summary>
        /// Изменить существующего пользователя
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <param name="model">Модель из запроса</param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEntityAsync(int id, UpdatingUserModel model)
        {
            await _service.UpdateAsync(id, _mapper.Map<UpdatingUserModel, UpdatingUserDTO>(model));

            return Ok();
        }

        /// <summary>
        /// Удалить пользователя
        /// </summary>
        /// <param name="id">Id пользователя</param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEntityAsync(int id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
    }
}