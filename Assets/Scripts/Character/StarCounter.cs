using UnityEngine;

public class StarCounter : MonoBehaviour
{
    [SerializeField] private DistanceToKeySignalTransition[] _enemyes;

    private int _requireStarsCount;
    private int _currentStarsCount;

    public int CurrentStarsCount => _currentStarsCount;
    public int RequireStarsCount => _requireStarsCount;

    private void Start()
    {
        _requireStarsCount = 3;
        _currentStarsCount = 0;
    }

    private void Update()
    {
        CheckStarsCount();
    }

    public void FindStar()
    {
        _currentStarsCount++;
    }

    private void CheckStarsCount()
    {
        if(_currentStarsCount == _requireStarsCount)
        {
            foreach(var enemy in _enemyes)
                enemy.enabled = false;
        }
    }
}
