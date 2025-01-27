namespace RecordShop.Frontend.Client.Services
{
    public interface IProfileService
    {
        event Action<Preferences>? OnChange;

        Task<Preferences> GetPreferencesAsync();
        Task ToggleDarkModeAsync();
    }
}