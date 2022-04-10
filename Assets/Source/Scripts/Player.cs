using NaughtyAttributes;
using Source.Scripts;
using Supyrb;
using UnityEngine;

public class Player : Movement
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float maxYDifference;
    [SerializeField] [Tag] private string deathZoneTag;
    [SerializeField] private float scoreMultiplier=10;

    private Vector2 currentVelocity;
    private float lastYPos;
    private int score=0;
    private SetScoreSignal setScoreSignal;

    private void Start()
    {
        setScoreSignal = Signals.Get<SetScoreSignal>();
        rb = GetComponent<Rigidbody2D>();
        lastYPos = transform.position.y;
        Signals.Get<PlayerJumpSignal>().AddListener(Jump);
        Signals.Get<StartGameSignal>().AddListener(InvokeFirstSpawn);
    }

    void InvokeFirstSpawn()
    {
        Signals.Get<SpawnPlatformsSignal>().Dispatch(transform.position.y);
        Signals.Get<SpawnPlatformsSignal>().Dispatch(transform.position.y+maxYDifference);
    }

    protected override void InvokePlatformSpawn()
    {
        if (transform.position.y - lastYPos > maxYDifference)
        {
            lastYPos = transform.position.y;
            Signals.Get<SpawnPlatformsSignal>().Dispatch(lastYPos+maxYDifference);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(deathZoneTag))
        {
            Signals.Get<LoseSignal>().Dispatch();
            this.gameObject.SetActive(false);
        }
    }

    int CalculateScore()
    {
        return (int) (transform.position.y * scoreMultiplier);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x,jumpForce);
        setScoreSignal.Dispatch(CalculateScore());
    }
}
