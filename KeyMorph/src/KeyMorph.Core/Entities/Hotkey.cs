using KeyMorph.Core.ValueObjects;

namespace KeyMorph.Core.Entities;

public sealed class Hotkey
{
    public Guid Id { get; init; }

    public string Name { get; private set; }

    public KeyGesture Gesture { get; private set; }

    public bool Enabled { get; private set; }

    public Hotkey(string name, KeyGesture gesture)
    {
        Id = Guid.NewGuid();
        Name = name;
        Gesture = gesture;
        Enabled = true;
    }

    public void Rename(string name)
    {
        Name = name;
    }

    public void ChangeGesture(KeyGesture gesture)
    {
        Gesture = gesture;
    }

    public void Enable()
    {
        Enabled = true;
    }

    public void Disable()
    {
        Enabled = false;
    }
}