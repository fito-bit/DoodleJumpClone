using System.Collections;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class MovingPlatform : Platform
{
    [SerializeField] [Range(-10,10)] private float moveRange=3;
    [SerializeField] private float moveTime;
    
    private Vector3 endPos;
    private Vector3 startPos;
    private bool upDown = false;
    private Sequence moveSequence;


    private void OnEnable()
    {
        moveSequence = DOTween.Sequence();
        endPos = transform.position;
        startPos = transform.position;
        moveTime = Random.Range(1, moveTime);
        moveRange = Random.Range(1, moveRange);
        if (Random.Range(0, 1000) > 500)
        {
            upDown = true;
            endPos.y += moveRange;
        }
        else
        {
            endPos.x += moveRange;
        }
        StartCoroutine(StartMoving());
    }

    private void OnDisable()
    {
        moveSequence.Complete();
        StopAllCoroutines();
    }

    IEnumerator StartMoving()
    {
        while (true)
        {
            Move(endPos);
            yield return new WaitForSeconds(moveTime);
            Move(startPos);
            yield return new WaitForSeconds(moveTime);
        }
    }

    void Move(Vector3 pos)
    {
        moveSequence.Append(transform.DOMove(pos, moveTime));
    }
}
