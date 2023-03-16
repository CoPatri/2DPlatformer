using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class UICoinsText : MonoBehaviour
{
    private TextMeshProUGUI tmproText;

    private void Awake()
    {
        tmproText = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        GameManager.Instance.OnCoinsChanged += HandleCoinsChanged;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnCoinsChanged -= HandleCoinsChanged;
    }

    private void HandleCoinsChanged(int coins)
    {
        tmproText.text = coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
