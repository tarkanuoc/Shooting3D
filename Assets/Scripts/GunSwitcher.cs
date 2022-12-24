using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSwitcher : MonoBehaviour
{
    public GameObject[] guns;
    private int _currentIndex;

    public string Platform = "PC";

    public void SwitchGun()
    {
        _currentIndex = (_currentIndex + 1) % guns.Length;
        SetActiveGun(_currentIndex);
    }

    private void Update()
    {
        if (Platform.Equals("PC"))
        {
            for (int i = 0; i < guns.Length; i++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + i)
                    || Input.GetKeyDown(KeyCode.Keypad1 + i))
                {
                    SetActiveGun(i);
                    break;
                }
            }
        }
        
    }

    private void SetActiveGun(int gunIndex)
    {
        for (int i = 0; i < guns.Length; i++)
        {
            bool isActive = (i == gunIndex);
            guns[i].SetActive(isActive);

            if (isActive)
            {
                guns[i].SendMessage("OnSelected", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
