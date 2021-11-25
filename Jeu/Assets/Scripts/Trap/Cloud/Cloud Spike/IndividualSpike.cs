// Authors : Angel Blazquez Benjamin Gandelin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The script applied to the spikes to manage their state (and their animation)
///</summary>
public class IndividualSpike : MonoBehaviour
{
    public bool isShown = false;
    
    public SpriteRenderer sr;
    public EdgeCollider2D ec2D;

    // Start is called before the first frame update
    void Start()
    {
        manageState();
    }

    /// <summary>
    /// Change the state of the spike (Shown or not) by the parameter bool new state and call manageState() to update the spike mesh. 
    ///</summary>
    public void changeState(bool newState) 
    {
        isShown = newState;
        manageState();
    }

    /// <summary>
    /// Manage the state of the spike if the state is enabled the spike is shown and the collider is active and the opposite otherwise.
    ///</summary>
    private void manageState()
    {
        if (isShown)
        {
            sr.enabled = true;
            ec2D.enabled = true;
        }
        else
        {
            sr.enabled = false;
            ec2D.enabled = false;
        }
    }

    /// <summary>
    /// Kill the player when the trigger is activated.
    ///</summary>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Player") {
            GetComponent<DeathManager>().Death();
        }
    }
}