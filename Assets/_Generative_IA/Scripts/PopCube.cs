using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopCube : MonoBehaviour
{



    public float fadeTime = 0.5f;
    private Material objectMaterial;


    public AudioClip[] clips;


    public bool autoClick;

    private void Start()
    {
        //   ChangeColor();
        objectMaterial = GetComponent<Renderer>().material;
    }



    // public void ChangeColor()
    // {
    //     // Generate a random color with similar hue, saturation, and value as the original color
    //     Color originalColor = GetComponent<Renderer>().material.color;

    //     // Convert the original color to the HSV color space
    //     Color.RGBToHSV(originalColor, out float h, out float s, out float v);

    //     // Generate a random color with similar hue, saturation, and value as the original color
    //     float hue = Random.Range(h - 0.1f, h + 0.1f);
    //     float saturation = Random.Range(s - 0.1f, s + 0.1f);
    //     float value = Random.Range(v - 0.1f, v + 0.1f);
    //     Color newColor = Color.HSVToRGB(hue, saturation, value);

    //     // Set the new color of the GameObject
    //     GetComponent<Renderer>().material.color = newColor;



    // }



    public void DestroyObject()
    {

        Destroy(gameObject);

    }


    private IEnumerator FadeObject()
    {
        float t = 0f;
        Color color = objectMaterial.color;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, t / fadeTime);
            color.a = alpha;
            objectMaterial.color = color;
            yield return null;
        }
        gameObject.SetActive(false);
    }


    public void OnMouseDown()
    {
        int clipIndex = Random.Range(0, clips.Length);

        gameObject.GetComponent<AudioSource>().clip = clips[clipIndex];
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        Invoke("DestroyObject", 1);
        //  StartCoroutine(FadeObject());

    }


    void OnMouseOver()
    {

        if (autoClick == true)
        {

            int clipIndex = Random.Range(0, clips.Length);

            gameObject.GetComponent<AudioSource>().clip = clips[clipIndex];
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Invoke("DestroyObject", 1);
        }

    }
}
