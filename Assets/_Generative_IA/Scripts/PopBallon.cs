using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PopBallon : MonoBehaviour
{

    public AudioClip[] clips;


    public bool autoClick;

    private void Start()
    {
        ChangeColor();
    }
    public void ChangeColor()
    {
        // Generate a random color with similar hue, saturation, and value as the original color
        Color originalColor = GetComponent<Renderer>().material.color;
        //  Color originalColor = Color.red;
        // Color originalColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        // Convert the original color to the HSV color space
        Color.RGBToHSV(originalColor, out float h, out float s, out float v);

        // Generate a random color with similar hue, saturation, and value as the original color
        float hue = Random.Range(h - 0.1f, h + 0.1f);
        float saturation = Random.Range(s - 0.1f, s + 0.1f);
        float value = Random.Range(v - 0.1f, v + 0.1f);
        Color newColor = Color.HSVToRGB(hue, saturation, value);

        // Set the new color of the GameObject
        GetComponent<Renderer>().material.color = newColor;



    }



    public void DestroyObject()
    {

        Destroy(gameObject);

    }

    public void OnMouseDown()
    {
        int clipIndex = Random.Range(0, clips.Length);

        gameObject.GetComponent<AudioSource>().clip = clips[clipIndex];
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        Invoke("DestroyObject", 1);
    }


    void OnMouseOver()
    {

        if (autoClick == true)
        {

            int clipIndex = Random.Range(0, clips.Length);

            gameObject.GetComponent<AudioSource>().clip = clips[clipIndex];
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<SphereCollider>().enabled = false;
            Invoke("DestroyObject", 1);
        }

    }
}
