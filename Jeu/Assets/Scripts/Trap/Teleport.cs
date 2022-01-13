using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Teleports the player to an other point
/// Made by Léo PUYASTIER
/// </summary>
public class Teleport : MonoBehaviour
{
    [SerializeField]
    private GameObject otherPoint;
    private bool canTeleport = true;

    /// <summary>
    /// Teleports the player if the player didn't just teleport
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player") && canTeleport) {          
            Teleport otp = otherPoint.GetComponent<Teleport>();
            otp.DeactivateTeleportation();
            other.gameObject.transform.position = otherPoint.transform.position;
        } 
    }

    public void DeactivateTeleportation() {
        canTeleport = false;
        StartCoroutine(WaitForTeleportation());
    }

    private IEnumerator WaitForTeleportation(){
        yield return new WaitForSeconds(5);
        canTeleport = true;
    }
}
