using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class PointDistribution : MonoBehaviour
{


    public GameObject toggleBtn;

    public GameObject SphereBasePoints;

    //public bool autoClick;
    public GameObject SpherePoint;
    // public int Quantity;
    public Slider Quantity;
    public Slider Size;

    public Color PrefabColor;


    private void Update()
    {


        if (Input.GetButtonDown("Fire1"))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                if (raycastHit.transform.tag == "SpherePoint")
                {
                    raycastHit.transform.gameObject.GetComponent<PopBallon>().OnMouseDown();

                }
            }
        }



    }




    public void ToggleSwitch()
    {


        StartCoroutine(teste());
    }


    IEnumerator teste()
    {

        bool teste2 = toggleBtn.GetComponent<Toggle>().isOn;

        if (teste2 == true)

            foreach (Transform child in SphereBasePoints.gameObject.transform)
            {


                child.GetComponent<PopBallon>().autoClick = true;
            }

        else if (teste2 == false)

            foreach (Transform child in SphereBasePoints.gameObject.transform)
            {


                child.GetComponent<PopBallon>().autoClick = false;
            }

        yield return null;

    }





    // public enum SwitchState
    // {
    //     On,
    //     Off
    // }

    // private SwitchState currentState = SwitchState.Off;
    // //private SwitchState currentState;
    // public void ToggleSwitch()
    // {
    //     switch (currentState)
    //     {
    //         case SwitchState.On:
    //             currentState = SwitchState.Off;
    //             Debug.Log("Switch is now off");

    //             foreach (Transform child in SphereBasePoints.gameObject.transform)
    //             {


    //                 child.GetComponent<PopBallon>().autoClick = false;
    //             }



    //             break;
    //         case SwitchState.Off:
    //             currentState = SwitchState.On;
    //             Debug.Log("Switch is now on");

    //             foreach (Transform child in SphereBasePoints.gameObject.transform)
    //             {


    //                 child.GetComponent<PopBallon>().autoClick = true;
    //             }

    //             break;
    //     }
    // }


    // if (true)
    // {


    // foreach (Transform child in SphereBasePoints.gameObject.transform)
    // {


    //     child.GetComponent<PopBallon>().autoClick = true;
    // }

    // }

    // else
    // {











    //  gameObject.GetComponent<Toggle>().isOn = true;
    // else if (autoClick == true)
    // {
    //  autoClick = false;


    // foreach (Transform child in SphereBasePoints.transform)
    // transform = GameObject.Find("SphereBasePoints").transfo

    // child.gameObject.transform.GetComponent<PopBallon>().autoClick = false;



















    public void createSpherePoints()
    {

        ResetPoints();


        // Use the normalizedValue as the value of your slider




        // float NormalizeValue(float value, float minValue, float maxValue)
        // {
        //     return Mathf.Clamp01((value - minValue) / (maxValue - minValue)) * 9999 + 1;
        // }

        // float valueToNormalize = Quantity.value;
        // float normalizedValue = NormalizeValue(valueToNormalize, 1, 10000);


        float scalingPos = 0.5f;
        Vector3 scale = new Vector3(Size.value, Size.value, Size.value);
        Vector3[] pts = PointsOnSphere((int)(Quantity.value));
        List<GameObject> uspheres = new List<GameObject>();
        int i = 0;









        foreach (Vector3 value in pts)
        {

            uspheres.Add(Instantiate(SpherePoint, new Vector3(0, 0, 0), Quaternion.identity));

            // uspheres.Add(GameObject.CreatePrimitive(PrimitiveType.Sphere));
            uspheres[i].transform.parent = transform;
            uspheres[i].transform.position = value * scalingPos;
            uspheres[i].transform.localScale = scale;

            i++;
            ToggleSwitch();

        }
    }

    Vector3[] PointsOnSphere(int n)
    {
        List<Vector3> upts = new List<Vector3>();
        float inc = Mathf.PI * (3 - Mathf.Sqrt(5));
        float off = 2.0f / n;
        float x = 0;
        float y = 0;
        float z = 0;
        float r = 0;
        float phi = 0;

        for (var k = 0; k < n; k++)
        {
            y = k * off - 1 + (off / 2);
            r = Mathf.Sqrt(1 - y * y);
            phi = k * inc;
            x = Mathf.Cos(phi) * r;
            z = Mathf.Sin(phi) * r;

            upts.Add(new Vector3(x, y, z));
        }
        Vector3[] pts = upts.ToArray();

        return pts;
    }

    public void ResetPoints()
    {


        foreach (Transform child in transform)
            Destroy(child.gameObject);


    }




}
