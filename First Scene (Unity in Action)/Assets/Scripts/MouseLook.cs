using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationsAxes
    {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationsAxes axes = RotationsAxes.MouseXandY;

    public float sensivityHorisontal = 9.0f;
    public float sensivityVertical = 9.0f;
    public float minVertical = -45.0f;
    public float maxVertical = 45.0f;

    private float _rotationX = 0;

    private void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
    }

    void Update()
    {
        if (axes == RotationsAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensivityHorisontal, 0);
        }
        else if (axes == RotationsAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensivityVertical;
            _rotationX = Mathf.Clamp(_rotationX, minVertical, maxVertical);

            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensivityVertical;
            _rotationX = Mathf.Clamp(_rotationX, minVertical, maxVertical);

            float delta = Input.GetAxis("Mouse X") * sensivityHorisontal;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
