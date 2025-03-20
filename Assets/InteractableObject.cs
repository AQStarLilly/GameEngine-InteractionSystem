using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }


    public void Interact()
    {
        Debug.Log("Interacting with Object" + gameObject.name);
    }
}
