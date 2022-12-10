using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private AutoFade LeftScratch;
    [SerializeField] private AutoFade RightScratch;

    public void ShowLeftScratch()
    {
        LeftScratch.ShowScratch();
    }
    public void ShowRightScratch()
    {
        RightScratch.ShowScratch();
    }
}
