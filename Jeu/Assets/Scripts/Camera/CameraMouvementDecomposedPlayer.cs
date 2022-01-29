using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouvementDecomposedPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject legsPlayer;
    [SerializeField]
    private GameObject armsPlayer;
    [SerializeField]
    private GameObject decomposedPlayer;

    public HeadMovements headMovements;


    // Update is called once per frame
    void Update()
    {
        
        if (headMovements.etat == 0) {
            positionCam(decomposedPlayer);
        }

        if (headMovements.etat == 1) {
            positionCam(legsPlayer);
        }

        if (headMovements.etat == 2) {
            positionCam(armsPlayer);
        }

        if (headMovements.etat == 3) {
            positionCam(player);
        }
    }

    void positionCam(GameObject go) {
        transform.position = go.transform.position + new Vector3(0, 0, -10);
    } 
}
