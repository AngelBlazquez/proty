//Authors : BLAZQUEZ Angel / GANDELIN Benjamin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The script applied to the spikes to manage their state (and their animation)
///</summary>
public class IndividualSpike : MonoBehaviour
{
    [SerializeField]
    private bool isShown = false;

    [SerializeField]
    private SpriteRenderer sr;
    [SerializeField]
    private EdgeCollider2D ec2D;

    /// <summary>
    /// Apply the defined starting on the level start.
    /// </summary>
    void Start()
    {
        manageState();
    }

    /// <summary>
    /// Change the state of the spike (Shown or not) by the parameter bool new state and call manageState() to update the spike mesh. 
    /// </summary>
    /// <param name="newState">The new state of the spike</param>
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
            GetComponent<AudioSource>().Play();
        }
        else
        {
            sr.enabled = false;
            ec2D.enabled = false;
        }
    }
}