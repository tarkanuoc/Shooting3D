using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoFade : MonoBehaviour
{
    [SerializeField] private Image ImageScratch;

    public float visibleDuration;
    public float fadingDuration;

    private float _startTime;

    public void ShowScratch()
    {
        _startTime = Time.time;
        SetAlpha(1f);
        gameObject.SetActive(true);
    }

    private void Update()
    {
        float _elapsedTime = Time.time - _startTime;
        if (_elapsedTime < visibleDuration) return;

        _elapsedTime -= visibleDuration;
        if (_elapsedTime < fadingDuration)
        {
            SetAlpha(1f - _elapsedTime / fadingDuration);
        }
        else
        {
            HideScratch();
        }
    }

    private void SetAlpha(float alpha)
    {
        Color _newColor = ImageScratch.color;
        _newColor.a = alpha;
        ImageScratch.color = _newColor;
    }

    public void HideScratch()
    {
        gameObject.SetActive(false);
    }
}
