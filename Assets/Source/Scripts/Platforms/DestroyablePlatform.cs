using System.Collections;
using DG.Tweening;
using UnityEngine;

public class DestroyablePlatform : Platform
{
    [SerializeField] private float destroyTime;
    [SerializeField] private float fallAmount;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            StartCoroutine(DestroyPlatform());
        }
    }

    IEnumerator DestroyPlatform()
    {
        transform.DOMoveY(transform.position.y-fallAmount, destroyTime);
        yield return new WaitForSeconds(destroyTime);
        this.gameObject.SetActive(false);
    }
}
