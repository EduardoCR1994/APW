using APW.Architecture;
using APW.Architecture.Providers;
using APW.Web.Models;

namespace APW.Web.Services
{
    public interface IWrapperServiceProvider
    {
        Task<object> GetDataAsync<T>(string endpoint) where T : class;
    }

    public class WrapperServiceProvider : IWrapperServiceProvider
    {
        private readonly IRestProvider _restProvider;

        public WrapperServiceProvider(IRestProvider restProvider)
        {
            _restProvider = restProvider;
        }

        public async Task<object> GetDataAsync<T>(string endpoint) where T : class
        {
            var content = await _restProvider.GetAsync(endpoint, null);
            return JsonProvider.DeserializeSimple<T>(content) ?? default!;
        }
    }
}

