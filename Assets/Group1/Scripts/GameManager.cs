using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager controller;

    [SerializeField] private GameObject _endGamePanel;
    private GameObject[] _enemyes;

    private void Update()
    {
        _enemyes = GameObject.FindGameObjectsWithTag("Enemy");

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
