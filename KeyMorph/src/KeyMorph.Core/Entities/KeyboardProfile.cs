namespace KeyMorph.Core.Entities;

public sealed class KeyboardProfile
{
    public Guid Id { get; init; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public bool IsDefault { get; private set; }

    public bool IsEnabled { get; private set; }

    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; private set; }

    // لیست داخلی هوت‌کی‌ها
    private readonly List<Hotkey> _hotkeys = new();

    // دسترسی فقط خواندنی به لیست هوت‌کی‌ها
    public IReadOnlyCollection<Hotkey> Hotkeys => _hotkeys.AsReadOnly();

    public KeyboardProfile(
        string name,
        string description = "")
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        IsDefault = false;
        IsEnabled = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public void Rename(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));

        Name = name;
        UpdatedAt = DateTime.UtcNow;
    }

    public void ChangeDescription(string description)
    {
        Description = description;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Enable()
    {
        IsEnabled = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Disable()
    {
        IsEnabled = false;
        UpdatedAt = DateTime.UtcNow;
    }

    public void SetAsDefault()
    {
        IsDefault = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void RemoveAsDefault()
    {
        IsDefault = false;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AddHotkey(Hotkey hotkey)
    {
        if (hotkey == null) 
            throw new ArgumentNullException(nameof(hotkey));

        _hotkeys.Add(hotkey);
        UpdatedAt = DateTime.UtcNow;
    }

    public void RemoveHotkey(Guid hotkeyId)
    {
        var hotkey = _hotkeys.FirstOrDefault(h => h.Id == hotkeyId);
        if (hotkey != null)
        {
            _hotkeys.Remove(hotkey);
            UpdatedAt = DateTime.UtcNow;
        }
    }
}