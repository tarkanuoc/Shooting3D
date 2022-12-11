using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;

    void Start()
    {
       // _mainCamera = Camera.main;
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
