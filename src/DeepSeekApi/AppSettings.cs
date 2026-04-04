namespace DeepSeekApi;

public class AppSettings
{
    public int Port { get; set; } = 5000;
    public string StorageStatePath { get; set; } = "data/storage-state.json";
}
