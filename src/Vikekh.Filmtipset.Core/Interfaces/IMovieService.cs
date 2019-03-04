using System.Threading.Tasks;
using Vikekh.Filmtipset.Core.Models;

namespace Vikekh.Filmtipset.Core.Interfaces
{
    public interface IMovieService
    {
        Task<Movie> GetMovieAsync(int id);
    }
}
