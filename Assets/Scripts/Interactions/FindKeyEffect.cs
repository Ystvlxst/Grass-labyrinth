using System.Collections;
using UnityEngine;

public class FindKeyEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem _findKEyWithoutAllStars;
    [SerializeField] private float _durationTime;
    [SerializeField] private bool _isShot;
    [SerializeField] private float _speed;

    private void Start()
    {
        _isShot = false;
    }

    private void Update()
    {
        CheckTimeShot(_isShot);
    }

    public void CheckTimeShot(bool isShot)
    {
        _isShot = isShot;

        if (isShot)
        {
            _findKEyWithoutAllStars.gameObject.SetActive(true);
            StartCoroutine(Shooting(_durationTime));
        }
    }

    private IEnumerator Shooting(float durationTime)
    {
        _findKEyWithoutAllStars.transform.Translate(Vector3.up * _speed * Time.deltaTime, Space.World);
        yield return new WaitForSeconds(durationTime);
        _findKEyWithoutAllStars.gameObject.SetActive(false);
    }
}
