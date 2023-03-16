using UnityEngine;

public class UIPlayButton : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.MoveToNextLevel();
    }
}
