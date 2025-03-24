using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public enum InteractionType
    {
        Nothing,
        Pickup,
        Info,
        Dialogue
    }


    [Header("Type of Interactable")]
    public InteractionType interType;

    public void Interact()
    {
        Debug.Log("Interacting with object: " + gameObject.name + " Currently set to: " + interType.ToString());

        switch(interType)
        {
            case InteractionType.Nothing:
                Nothing();
                break;
            case InteractionType.Pickup:
                Pickup();
                break;
            case InteractionType.Info:
                Info();
                break;
            case InteractionType.Dialogue:
                Dialogue();
                break;
        }
    }

    public void Nothing()
    {
        Debug.Log("Interaction type not defined");
    }

    public void Pickup()
    {
        Debug.Log("Picking up Object" + gameObject.name);
    }

    public void Info()
    {
        Debug.Log("Displaying info message on object" + gameObject.name);
    }

    public void Dialogue()
    {
        Debug.Log("Dialogue" + gameObject.name);
    }
}
