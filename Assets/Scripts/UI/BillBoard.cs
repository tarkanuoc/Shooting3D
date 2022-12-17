using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    private Camera _mainCamera;

    void Start()
    {
        _mainCamera = Player.Instance.MainCamera;
        LookTowardCamera();
    }

    void Update()
    {
        LookTowardCamera();
    }

    private void LookTowardCamera()
    {
        transform.forward = -_mainCamera.transform.forward;
    }

}
