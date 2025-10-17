using UnityEngine;

public class FireBolt : SuperPower
{
    private GameObject _projectlile;
    protected override void Activate()
    {
        // Create a firebolt with sound and particle
        spawnProjectile(_projectlile);
        playSound(1);
        spawnParticles(5);
    }
}
