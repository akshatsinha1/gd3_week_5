using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float mouseSensitivity;
 
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseXInput = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseSensitivity * Time.deltaTime * mouseXInput);

        
        Vector3 currentRotation = transform.GetChild(0).localEulerAngles;
        currentRotation.x += mouseSensitivity * Time.deltaTime * -Input.GetAxis("Mouse Y");
        if (currentRotation.x > 180) currentRotation.x -= 360;
        currentRotation.x = Mathf.Clamp(currentRotation.x, -15, 45);
        transform.GetChild(0).localEulerAngles = currentRotation;


        transform.position = GameObject.FindObjectOfType<playerController>().transform.position;
    }
}
