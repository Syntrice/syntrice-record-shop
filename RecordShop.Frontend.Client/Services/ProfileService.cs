using Blazored.LocalStorage;

namespace RecordShop.Frontend.Client.Services
{

    /// <summary>
    /// A profile service used to manage user preferences on the client. At some point it might be 
    /// better to handle this in the database (with logins, etc).
    /// </summary>
    public class ProfileService : IProfileService
    {
        private readonly ILocalStorageService _localStorageService;

        public event Action<Preferences>? OnChange;

        public ProfileService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task ToggleDarkModeAsync()
        {
            var preferences = await GetPreferencesAsync();
            var newPreferences = preferences with { DarkMode = !preferences.DarkMode };
            await _localStorageService.SetItemAsync("preferences", newPreferences);

            OnChange?.Invoke(newPreferences);
        }

        public async Task<Preferences> GetPreferencesAsync()
        {
            return await _localStorageService.GetItemAsync<Preferences>("preferences") ?? new Preferences();
        }
    }
}
