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
    private bool activate = false;
    private float time;
    
    public void OpenDoor()
    {
        Door.SetActive(false);
        StartCoroutine(timer());
        activate = true;
    }

    public void CloseDoor()
    {
        Door.SetActive(true);
        activate = false;
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
        if(!activate && col.gameObject.CompareTag("Player"))
        {
            OpenDoor();
        }
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            CloseDoor();
            activate = false;
            StopCoroutine(timer());
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(110);
        CloseDoor();
    }
}