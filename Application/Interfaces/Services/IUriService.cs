using Application.FIlters;

namespace Application.Interfaces.Services
{
    public interface IUriService
    {
        Uri GetPageUri(PaginationFilter filter, string route);
    }
}
