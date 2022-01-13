using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// PressurePlate
/// Made by Antoine
/// </summary>
public class PressurePlate : MonoBehaviour
{
    public GameObject Door;
    private bool isOpen = false;
    private bool collided = false;
    private float time;
    
    public void OpenDoor()
    {
        Door.SetActive(false);
        StartCoroutine(timer());
    }

    public void CloseDoor()
    {
        Door.SetActive(true);
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
        if(isOpen)
        {
            OpenDoor();
        }else {
            CloseDoor();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(!collided && col.gameObject.CompareTag("Player"))
        {
            OpenDoor();
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(110);
        CloseDoor();
    }
}