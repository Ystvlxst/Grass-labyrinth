using UnityEngine;
using TMPro;

public class StarCountText : MonoBehaviour
{
    [SerializeField] private StarCounter _starCounter;
    [SerializeField] private TMP_Text _text;

    private void Update()
    {
        _text.text = _starCounter.CurrentStarsCount.ToString() + "/3";
    }
}
