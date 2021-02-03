using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Scripts / FPS Input")]
public class FPSInput : MonoBehaviour
{
    private CharacterController _characterController;
    public float speed = 6.0f;
    public float gravity = -9.0f;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        //transform.Translate(deltaX * Time.deltaTime, 0, deltaZ * Time.deltaTime);
        Vector3 move = new Vector3(deltaX, 0, deltaZ);
        move = Vector3.ClampMagnitude(move, speed);
        move.y = gravity;

        move *= Time.deltaTime;
        move = transform.TransformDirection(move);
        _characterController.Move(move);
    }
}
