using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseBehaviour : MonoBehaviour
{


    public RectTransform CustomCursor;

    void Start()
    {
        CustomCursor = GameObject.Find("Cursor").GetComponent<RectTransform>();

        Cursor.visible = false;

    }


    void Update()
    {
        CustomCursor.GetComponent<RectTransform>().position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    }
}
