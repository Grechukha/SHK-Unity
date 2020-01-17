using UnityEngine;

[RequireComponent(typeof(EnemyList))]
public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject _endGamePanel;

    private EnemyList _enemies;

    private void Awake()
    {
        _enemies = GetComponent<EnemyList>();
 
        _enemies.EnemiesDied += () => OnEnemiesDied();
    }

    public void OnEnemiesDied()
    {
        _endGamePanel.SetActive(true);
    }
}
