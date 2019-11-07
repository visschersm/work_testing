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

        public async Task<TView> CreateAsync<TView>(ViewModel.User.Create create)
        {
            var newUser = _context.Users.Add(new User
            {
                Username = create.Username,
                Firstname = create.Firstname,
                Middlename = create.Middlename,
                Lastname = create.Lastname
            }).Entity;
            await _context.SaveChangesAsync();

            return _mapper.Map<TView>(newUser);
        }

        public async Task<IEnumerable<TView>> GetAsync<TView>()
        {
            var data = _context.Users.AsNoTracking();

            return await _mapper.ProjectTo<TView>(data).ToArrayAsync();
        }
    }
}
