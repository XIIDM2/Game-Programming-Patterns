using UnityEngine;

public class SkyLaunch : SuperPower
{
    protected override void Activate()
    {
        if (getHeroZ() == 0)
        {
            // On the ground, so spring into the air.
            playSound(1.0f);
            spawnParticles(10);
            move(0, 0, 20);
        }
        else if (getHeroZ() < 10.0f)
        {
            // Near the ground, so do a double jump.
            playSound(1.0f);
            move(0, 0, getHeroZ() + 20);
        }
        else
        {
            // Way up in the air, so do a dive attack.
            playSound(0.7f);
            spawnParticles(1);
            move(0, 0, -getHeroZ());
        }
    }
}

