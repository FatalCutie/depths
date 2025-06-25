public class StatModifier
{
    public ModifierType Type;
    public float Value;
    public object Source;

    public StatModifier(float value, ModifierType type, object source)
    {
        Value = value;
        Type = type;
        Source = source;
    }
}