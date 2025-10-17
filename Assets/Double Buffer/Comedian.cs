using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Comedian : Actor
{
    private Actor _facing;

    public Comedian(string name) : base(name)
    {
    }

    public void Face(Actor actor) => _facing = actor;

    public override void Update()
    {
        if (WasSlapped())
        {
            Debug.Log($"{Name} slapped {_facing.Name}");
            _facing.Slap();
        }
    }

}
