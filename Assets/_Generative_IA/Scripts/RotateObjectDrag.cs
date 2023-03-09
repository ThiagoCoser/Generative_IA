using UnityEngine;
using System.Collections;

public class RotateObjectDrag : MonoBehaviour
{

    public float rotationVelocity = 10f;

    public bool canRotate;

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
            transform.rotation = Quaternion.AngleAxis(-rotX, up) * transform.rotation;
            transform.rotation = Quaternion.AngleAxis(rotY, right) * transform.rotation;
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
