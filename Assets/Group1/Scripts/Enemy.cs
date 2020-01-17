using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public event UnityAction<Enemy> Dead;

    private void OnDestroy()
    {
        Dead?.Invoke(this);
    }
}
