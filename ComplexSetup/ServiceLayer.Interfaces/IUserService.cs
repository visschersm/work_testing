using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IUserService
    {
        Task<TView> CreateAsync<TView>(ViewModel.User.Create create);
        Task<IEnumerable<TView>> GetAsync<TView>();
    }
}
