using RecordShop.Frontend.Client.Services;

namespace RecordShop.Frontend.Services
{
    /// <summary>
    /// Dummy profile service for server. Quite a temporary solution until a better method is discovered.
    /// </summary>
    public class ServerProfileService : IProfileService
    {
        public event Action<Preferences>? OnChange;

        public Task<Preferences> GetPreferencesAsync()
        {
            return Task.FromResult(new Preferences() { DarkMode = false });
        }

        public Task ToggleDarkModeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
