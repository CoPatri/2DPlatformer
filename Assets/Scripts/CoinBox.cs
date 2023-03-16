using UnityEngine;

public class CoinBox : MonoBehaviour, ITakeShellHits
{
    [SerializeField]
    private SpriteRenderer enabledSprite;
    [SerializeField]
    private SpriteRenderer disabledSprite;
    [SerializeField]
    private int totalCoins = 1;


    private Animator animator;
    private int remainingCoins;

    public void HandleShellHit(ShellFlipped shellFlipped)
    {
        if(remainingCoins > 0)
        {
            TakeCoin();
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        remainingCoins = totalCoins;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (remainingCoins > 0 && collision.WasHitByPlayer() && collision.WasBottom())
        {
            TakeCoin();
        }
    }

    private void TakeCoin()
    {
        animator.SetTrigger("FlipCoin");
        GameManager.Instance.AddCoin();
        remainingCoins--;

        if (remainingCoins <= 0)
        {
            enabledSprite.enabled = false;
            disabledSprite.enabled = true;
        }
    }
}
