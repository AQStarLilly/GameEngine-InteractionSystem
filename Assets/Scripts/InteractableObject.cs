using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    [Header("Simple info message")]
    public string infoMessage;
    public TMP_Text infoText;
    public float displayDuration = 3f;


    public void Interact()
    {
        //Debug.Log("Interacting with object: " + gameObject.name + " Currently set to: " + interType.ToString());

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
        if (interType == InteractionType.Pickup)
        {
            Debug.Log("You picked up a " + gameObject.name);
            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("Tried to pick up an object but failed");
        }
    }

    public void Info()
    {
        if(infoText != null)
        {
            StopAllCoroutines();
            infoText.text = infoMessage;          
            StartCoroutine(HideInfoAfterDelay());
        }
        else
        {
            Debug.LogWarning("infoText missing");
        }
    }

    private IEnumerator HideInfoAfterDelay()
    {
        yield return new WaitForSeconds(displayDuration);
        infoText.text = "";
    }

    public void Dialogue()
    {
        Debug.Log("Dialogue" + gameObject.name);
    }
}
