using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float mouseX;
    private float mouseY;
    private float mouseSpeed = 1;
    public float speed = 5.0f;

    private Vector3 offset;

    public Camera playerCam;
    
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 0, 0);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        mouseX += Input.GetAxis("Mouse X");
        mouseY += Input.GetAxis("Mouse Y");
        Movement();
    }
    private void LateUpdate()
    {
        playerCam.transform.position = transform.position + offset;
        //playerCam.transform.Rotate(Vector3.up , mouseX * mouseSpeed);
        ////playerCam.transform.Rotate(Vector3.right * mouseY * mouseSpeed);
        //playerCam.transform.Rotate(-mouseY, 0, 0);
        playerCam.transform.rotation = Quaternion.Euler(-mouseY, mouseX, 0);
        //transform.rotation = playerCam.transform.rotation;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, playerCam.transform.eulerAngles.y, transform.rotation.eulerAngles.z);


    }
    void Movement()
    {
        //transform.Rotate(Vector3.up * horizontalInput * speed * Time.deltaTime);
        //transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
        transform.Translate(horizontalInput * speed * Time.deltaTime, 0, verticalInput * speed * Time.deltaTime);
    }
}
