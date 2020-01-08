using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _endGamePanel;

    private Enemy[] _enemyes;

    private void Update()
    {
        _enemyes = GameObject.FindObjectsOfType<Enemy>();

        if (_enemyes.Length == 0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        _endGamePanel.SetActive(true);
    }
}
