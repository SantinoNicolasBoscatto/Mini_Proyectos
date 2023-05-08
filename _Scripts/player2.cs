using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float velocidadDeMovimiento = 5.0f;
    public float velocidadDeRotacion = 200.0f;
    Animator animaciones;
    Transform camara;
    CharacterController control;
    int N1;
    int N2;


    // Start is called before the first frame update
    void Start()
    {
        animaciones = GetComponent<Animator>();
        control = GetComponent<CharacterController>();
        camara = transform.GetChild(2).GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(new Vector3(0, mouseX, 0) * velocidadDeRotacion * Time.deltaTime);

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 movimiento = (transform.right * moveX + transform.forward * moveZ) * velocidadDeMovimiento * Time.deltaTime;
        control.Move(movimiento);

        animaciones.SetFloat("VelX", moveX);
        animaciones.SetFloat("VelY", moveZ);
        if (Input.GetKey("q"))
         {
            velocidadDeMovimiento = velocidadDeMovimiento*3;
        }

        else
        {
        }

    }
}
