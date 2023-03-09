using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotateOtherBackground : MonoBehaviour
{
    public float rotationVelocity = 4f;

    public bool canRotate;
    public GameObject objToRotate;

    //Drag the camera object here
    public Camera cam;

    public bool mouseDrag;

    private void Start()
    {
        canRotate = true;
    }



    void Update()
    {

        if (mouseDrag == true && canRotate == true)
        {
            float rotX = Input.GetAxisRaw("Mouse X") * rotationVelocity;
            float rotY = Input.GetAxisRaw("Mouse Y") * rotationVelocity;

            Vector3 right = Vector3.Cross(cam.transform.up, transform.position - cam.transform.position);
            Vector3 up = Vector3.Cross(transform.position - cam.transform.position, right);
            objToRotate.transform.rotation = Quaternion.AngleAxis(-rotX, up) * objToRotate.transform.rotation;
            objToRotate.transform.rotation = Quaternion.AngleAxis(rotY, right) * objToRotate.transform.rotation;
        }
    }






    void OnMouseDown()
    {
        mouseDrag = true;
    }

    void OnMouseUp()
    {
        mouseDrag = false;
    }


}
