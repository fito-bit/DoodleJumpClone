using Source.Scripts;
using UnityEngine;

public class DeathBorderFolow : Follower
{
    protected override void Move()
    {
        if (player.position.y - transform.position.y > maxDifference)
            transform.position +=Vector3.up*(maxDifference/2);
    }
}
