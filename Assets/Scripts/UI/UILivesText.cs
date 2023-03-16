using TMPro;
using UnityEngine;

public class UILivesText : MonoBehaviour
{
    private TextMeshProUGUI tmproText;

    private void Awake()
    {
        tmproText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameManager.Instance.OnLivesChanged += HandleOnLivesChanged;
        tmproText.text = GameManager.Instance.Lives.ToString();
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnLivesChanged -= HandleOnLivesChanged;
    }

    private void HandleOnLivesChanged(int livesRemaining)
    {
        tmproText.text = livesRemaining.ToString();
    }
}