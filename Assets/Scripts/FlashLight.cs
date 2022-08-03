using System.Collections;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private Light _light;
    [SerializeField] private float _durationTime;
    [SerializeField] private float _durationDarkTime;
    [SerializeField] private float _timeBetweenFlash;

    private Coroutine _coroutine;

    private void Start()
    {
        _light.enabled = false;

        Flash();
    }

    private IEnumerator PeriodicityFlash(float durationTime, float durationDarkTime, float timeBetweenFlash)
    {
        while (true)
        {
            _light.enabled = true;
            yield return new WaitForSeconds(durationTime);
            _light.enabled = false;
            yield return new WaitForSeconds(durationDarkTime);
            _light.enabled = true;
            yield return new WaitForSeconds(durationTime);
            _light.enabled = false;
            yield return new WaitForSeconds(durationTime);
            _light.enabled = true;
            yield return new WaitForSeconds(durationDarkTime);
            _light.enabled = false;
            yield return new WaitForSeconds(timeBetweenFlash);
        }
    }

    private void Flash()
    {
        _coroutine = StartCoroutine(PeriodicityFlash(_durationTime, _durationDarkTime, _timeBetweenFlash));

        if (_coroutine != null)
            StopCoroutine(PeriodicityFlash(_durationTime, _durationDarkTime, _timeBetweenFlash));

        Debug.Log("startCoroutine");
    }
}
