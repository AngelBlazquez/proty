using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchInput : MonoBehaviour
{
    [SerializeField]
    [Tooltip("1 = ^ / 2 = < / 3 = >")]
    private Button[] touchUI;

    PlayerMovement mvPlayer;
    HeadMovements hdmvPlayer;

    bool inputLeft = false;
    bool inputRight = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(Input.touchCount > 0)
        {
            Touch ltouch = Input.GetTouch(1);
            Touch rtouch = Input.GetTouch(0);
            


            if(ltouch.phase == TouchPhase.Began)
            {

            }

        }
    }
}
