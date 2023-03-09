using UnityEngine;
using UnityEngine.UI;

public class FractalCube : MonoBehaviour
{

    public GameObject cubePrefab; // the prefab for the cube
    public int maxIterations = 2; // maximum number of iterations
    public float scaleFactor = 0.5f; // scale factor for child cubes
    public float distanceFactor = 1f; // distance factor for child cubes

    public Slider SIterations;
    public Slider SScaleFactor;
    public Slider SDistanceFactor;


    void Start()
    {
        // CreateFractalCube(transform.position, transform.localScale, maxIterations);
    }

    public void StartBtn()
    {

        maxIterations = (int)SIterations.value;
        scaleFactor = SScaleFactor.value;
        distanceFactor = SDistanceFactor.value;

        foreach (Transform child in transform)
        {


            Destroy(child.gameObject);
        }

        GameObject childObject = Instantiate(cubePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        childObject.transform.parent = gameObject.transform;

        //Instantiate(cubePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        CreateFractalCube(transform.position, transform.localScale, maxIterations);


    }







    void CreateFractalCube(Vector3 position, Vector3 scale, int iterations, int noIterationFace = -1)
    {
        if (iterations <= 0)
        {
            return; // exit if we have reached the maximum number of iterations
        }

        // instantiate cubes on each face of the parent cube
        for (int i = 0; i < 6; i++)
        {
            if (i != noIterationFace)
            {
                Vector3 faceNormal = GetFaceNormal(i); // get the normal of the face
                Vector3 newPosition = position + faceNormal * (scale.magnitude / 2f + distanceFactor); // calculate the position of the new cube
                GameObject newCube = Instantiate(cubePrefab, newPosition, Quaternion.identity, transform); // instantiate the new cube
                newCube.transform.localScale = scale * scaleFactor; // set the scale of the new cube

                // recursively create child cubes on each face of the new cube, skipping the face pointing to the parent cube
                int oppositeFaceIndex = GetOppositeFaceIndex(i);
                CreateFractalCube(newPosition, scale * scaleFactor, iterations - 1, oppositeFaceIndex);
            }
        }
    }

    Vector3 GetFaceNormal(int faceIndex)
    {
        switch (faceIndex)
        {
            case 0: return Vector3.up;
            case 1: return Vector3.down;
            case 2: return Vector3.right;
            case 3: return Vector3.left;
            case 4: return Vector3.forward;
            case 5: return Vector3.back;
            default: return Vector3.zero;
        }
    }

    int GetOppositeFaceIndex(int faceIndex)
    {
        switch (faceIndex)
        {
            case 0: return 1;
            case 1: return 0;
            case 2: return 3;
            case 3: return 2;
            case 4: return 5;
            case 5: return 4;
            default: return -1;
        }
    }
}
