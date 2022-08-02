using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCounter : MonoBehaviour
{
    private int _requireStarsCount;
    private int _currentStarsCount;

    public int CurrentStarsCount => _currentStarsCount;

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

        }
    }
}
