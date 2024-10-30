using Microsoft.JSInterop;
namespace BlazorPunchOutTest.Controllers
{
    public class CookieService
    {
        private readonly IJSRuntime _jsRuntime;

        public CookieService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task SetCookieAsync(string name, string value, int days)
        {
            await _jsRuntime.InvokeVoidAsync("cookieHelper.setCookie", name, value, days);
        }

        public async Task<string> GetCookieAsync(string name)
        {
            return await _jsRuntime.InvokeAsync<string>("cookieHelper.getCookie", name);
        }

        public async Task DeleteCookieAsync(string name)
        {
            await _jsRuntime.InvokeVoidAsync("cookieHelper.deleteCookie", name);
        }
    }
}

