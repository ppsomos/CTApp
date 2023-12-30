using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zoominout : MonoBehaviour
{
    public float zoomSpeed = 0.1f;
    public float minZoom = 1f;
    public float maxZoom = 5f;
    public RectTransform imageRectTransform;
  

    void Start()
    {
        // Attach your image RectTransform here or assign it in the Inspector
        if (imageRectTransform == null)
        {
            imageRectTransform = GetComponent<RectTransform>();
        }
           

    }

    void Update()
    {
        // Handle zooming with the mouse scroll wheel
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        Zoom(scrollWheel);
    }

   public void ZoomIn()
    {
        Zoom(-zoomSpeed);
    }

   public void ZoomOut()
    {
        Zoom(zoomSpeed);
    }

    void Zoom(float delta)
    {
        float currentZoom = imageRectTransform.localScale.x;
        float newZoom = Mathf.Clamp(currentZoom + delta, minZoom, maxZoom);
        imageRectTransform.localScale = new Vector3(newZoom, newZoom, 2f);
   
    }
}
