using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Transform camara;
    CharacterController control;
    public float speedCam;
    public float playerSpeed;
    float rotationY;

     void Start()
    {
        control = GetComponent<CharacterController>();
        camara = transform.GetChild(13).GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(new Vector3(0, mouseX, 0) * speedCam * Time.deltaTime);

        rotationY -= mouseY * Time.deltaTime * speedCam;
        rotationY = Mathf.Clamp(rotationY, -90, 90);
        camara.localRotation = Quaternion.Euler(new Vector3(rotationY, 0, 0));

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 movimiento = (transform.right * moveX + transform.forward * moveZ) * playerSpeed *Time.deltaTime;
        control.Move(movimiento);
    }
}
