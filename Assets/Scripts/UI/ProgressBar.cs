using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public RectTransform rectTransform;
    public RectTransform mask;
    public RectTransform progressImage;

    private float maxWidth;
    private float maxHeight;

    private void Awake()
    {
        maxWidth = mask.rect.width;
        maxHeight = mask.rect.height;
    }

    public void SetProgressValue(float progress)
    {
        float currentWidth = Mathf.Clamp01(progress) * maxWidth;
        mask.sizeDelta = new Vector2(currentWidth, maxHeight);
    }
}
