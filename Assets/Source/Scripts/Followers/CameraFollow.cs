using System;
using DG.Tweening;
using Source.Scripts;
using UnityEngine;

public class CameraFollow : Follower
{
    [SerializeField] private float moveTime=0.5f;

    protected override void Move()
    {
        if (Math.Abs(transform.position.y - player.position.y) > maxDifference)
            transform.DOMoveY(player.position.y, moveTime);
    }
}
