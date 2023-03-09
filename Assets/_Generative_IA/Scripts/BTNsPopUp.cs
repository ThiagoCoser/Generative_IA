using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BTNsPopUp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // private bool isFirstSelected = true;

    public GameObject SpherePoints;

    public void OnPointerEnter(PointerEventData eventData)
    {
        //if (isFirstSelected)
        //  {

        //  Debug.Log("entrou");

        //  EventSystem.current.SetSelectedGameObject(gameObject);
        //  }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        // isFirstSelected = false;
        // EventSystem.current.SetSelectedGameObject(null);
        //  Debug.Log("saiu");
    }



    public void click()
    {

        SpherePoints.GetComponent<PointDistribution>().createSpherePoints();

    }

}
