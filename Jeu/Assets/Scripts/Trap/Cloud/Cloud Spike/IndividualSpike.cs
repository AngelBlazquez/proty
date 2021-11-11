using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void changeState(bool newState) 
    {
        isShown = newState;
        manageState();
    }

<<<<<<< HEAD
    private void manageState()
=======
    void manageState()
>>>>>>> 668f8b2 (Nuage avec effet de rebond terminé)
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
}
