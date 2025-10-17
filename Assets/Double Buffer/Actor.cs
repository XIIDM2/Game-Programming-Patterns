using UnityEngine;

public abstract class Actor
{
    public string Name => _name;
    private bool _currentSlapped = false;
    private bool _nextSlapped = false;
    private string _name;

    public Actor(string name)
    {
        _name = name;
    }

    public void Slap() => _nextSlapped = true;
    public bool WasSlapped() => _currentSlapped;

    public void Swap()
    {
        _currentSlapped = _nextSlapped;

        _nextSlapped = false;
    }

    public virtual void Update() { }

}
