using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float rotationSpeed;
    private float horizontalInput;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("HorizontalCam");
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * -horizontalInput);

        transform.position = GameObject.FindObjectOfType<playerController>().transform.position;
    }
}
