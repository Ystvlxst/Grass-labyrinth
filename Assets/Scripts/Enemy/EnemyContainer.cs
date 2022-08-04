using UnityEngine;

public class EnemyContainer : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    private Enemy[] _enemies;
    private SignalizationTransition[] _signalizationTransitions;
    
    private void Awake()
    {
        _enemies = GetComponentsInChildren<Enemy>();
        _signalizationTransitions = GetComponentsInChildren<SignalizationTransition>();

        foreach (Enemy enemy in _enemies) 
            enemy.Init(_player);
    }

    public void Signal()
    {
        foreach (SignalizationTransition transition in _signalizationTransitions) 
            transition.Signal();
    }
}
