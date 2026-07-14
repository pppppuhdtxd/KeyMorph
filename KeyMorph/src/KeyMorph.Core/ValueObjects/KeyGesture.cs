namespace KeyMorph.Core.ValueObjects;

public sealed record KeyGesture(
    string Key,
    bool Ctrl = false,
    bool Alt = false,
    bool Shift = false,
    bool Win = false);