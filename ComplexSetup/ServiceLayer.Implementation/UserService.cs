using AutoMapper;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Implementation.MappingProfiles;
using ServiceLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Implementation
{
    public class UserService : IUserService
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public UserService(IContext context)
        {
            _context = context;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserMappingProfile());
            });
            _mapper = new Mapper(config);
        }

        public async Task<TView> CreateAsync<TView>(ViewModel.User.Create toCreate)
        {
            var newUser = _mapper.Map<User>(toCreate);
            var createdUser = _context.Users.Add(newUser).Entity;
            var result = await _context.SaveChangesAsync();

            return _mapper.Map<TView>(createdUser);
        }

        public async Task<IEnumerable<TView>> GetAsync<TView>()
        {
            var result = await _context.Users.ToArrayAsync();

            return await _mapper.ProjectTo<TView>(_context.Users).ToArrayAsync();
        }


    }
}
