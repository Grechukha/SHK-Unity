using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent GameEnding;

    [SerializeField] private EndGamePanel _endGamePanel;

    private Enemy[] _enemyes;

    private void Start()
    {
        _enemyes = GameObject.FindObjectsOfType<Enemy>();
    }

    private void Update()
    {
        if (IsAnyEnemyAlife() == false)
        {
            GameEnding.Invoke();
        }
    }

    private bool IsAnyEnemyAlife()
    {
        bool isAnyEnemyAlife = false;

        for (int i = 0; i < _enemyes.Length; i++)
        {
            if (_enemyes[i] != null)
            {
                isAnyEnemyAlife = true;
            }
        }

        return isAnyEnemyAlife;
    }
}
