using NaughtyAttributes;
using Supyrb;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] [Tag] protected string playerTag;
    [SerializeField] [Tag] protected string destroyerTag;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            Signals.Get<PlayerJumpSignal>().Dispatch();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(destroyerTag))
        {
            this.gameObject.SetActive(false);
        }
    }
}
