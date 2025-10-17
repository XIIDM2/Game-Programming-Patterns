using System.Collections.Generic;
using UnityEngine;

public class Scene
{
    private List<Actor> _actors = new List<Actor>();

    public void Add(Actor actor)
    {
        _actors.Add(actor);
    }

    public void Update()
    {
        foreach (Actor actor in _actors)
        {
            actor.Update();
        }

        foreach (Actor actor in _actors)
        {
            actor.Swap();
        }
    }

}
