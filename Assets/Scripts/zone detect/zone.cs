using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zone : MonoBehaviour
{
    public GameObject Button;



    public void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Player")
            Button.SetActive(true);
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Button.SetActive(false);
    }
}
