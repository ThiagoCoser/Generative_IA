using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menuControl : MonoBehaviour
{

    public GameObject myCanvas;
    public bool hideCanvas;
    public bool canHideCanvas;

    // Start is called before the first frame update
    void Start()
    {
        myCanvas = GameObject.Find("Canvas");
        canHideCanvas = true;

    }

    IEnumerator hideCanvasFunction()
    {


        canHideCanvas = false;



        if (hideCanvas == false)
        {
            myCanvas.SetActive(false);
            hideCanvas = true;

        }

        else if (hideCanvas == true)
        {
            myCanvas.SetActive(true);
            hideCanvas = false;

        }


        yield return new WaitForSeconds(0.5f);
        canHideCanvas = true;
    }


    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.Escape))
        {

            Application.Quit();
        }


        if (Input.GetKey(KeyCode.A))
        {

            SceneManager.LoadScene(0);
        }

        if (Input.GetKey(KeyCode.B))
        {

            SceneManager.LoadScene(1);
        }
        if (Input.GetKey(KeyCode.Space) && canHideCanvas == true)
        {

            StartCoroutine(hideCanvasFunction());

        }

    }


}
