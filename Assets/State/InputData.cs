using Unity.VisualScripting;

public struct InputData
{
    public PlayerAction action;
    public float? value;

    public InputData(PlayerAction action, float? value)
    {
        this.action = action;
        this.value = value;
    }
}