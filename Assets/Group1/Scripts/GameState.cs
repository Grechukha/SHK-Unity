using UnityEngine;

[RequireComponent(typeof(EnemyList))]
public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject _endGamePanel;

    private EnemyList _enemies;

    private void OnEnable()
    {
        _enemies = GetComponent<EnemyList>();
 
        _enemies.EnemiesDied += OnEnemiesDied;
    }

    private void OnDisable()
    {
        _enemies.EnemiesDied -= OnEnemiesDied;
    }

    public void OnEnemiesDied()
    {
        _endGamePanel.SetActive(true);
    }
}
