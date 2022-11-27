using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByMouse : MonoBehaviour
{
    public float angleYaw;
    public float anglePitch;
    public float minPitch;
    public float maxPitch;
    [SerializeField] private Transform cameraHolder;
    private float pitch;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UpdatePitch()
    {
        var mouseY = Input.GetAxis("Mouse Y");
        var deltaPitch = -mouseY * anglePitch;
        pitch = Mathf.Clamp(pitch + deltaPitch, minPitch, maxPitch);
        cameraHolder.localEulerAngles = new Vector3(pitch, 0, 0);
    }

    void UpdateYaw()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var yaw = mouseX * angleYaw ;
        transform.Rotate(0, yaw, 0);
    }
    // Update is called once per frame
    void Update()
    {
        UpdateYaw();
        UpdatePitch();

    }
}
