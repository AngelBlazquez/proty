using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchInput : MonoBehaviour
{
    [SerializeField]
    [Tooltip("1 = ^ / 2 = < / 3 = > / 4 = pause")]
    private Button[] touchUI;

    [SerializeField]
    private Canvas touchInputCanvas;

    [SerializeField]
    private PlayerMovement mvPlayer;
    [SerializeField]
    private HeadMovements hdmvPlayer;
    [SerializeField]
    private winManager pauseRef;

    [SerializeField]
    private GameObject menuHolder;

    // Start is called before the first frame update
    void Start()
    {
        #if PLATFORM_ANDROID
                menuHolder.SetActive(true);
        #else
                menuHolder.SetActive(false);
        #endif
    }


    // Update is called once per frame
    void Update()
    {
        Touch t1;
        Touch t2;
        if (Input.touchCount > 0)
        {
            if (Input.touchCount == 2)
            {
                t1 = Input.GetTouch(0);
                t2 = Input.GetTouch(1);


                List<bool> resultTouch1 = ClickedOnButtons(t1.position);
                if (resultTouch1[0])
                {
                    mvPlayer.Jump();
                }
                else if (resultTouch1[1])
                {
                    mvPlayer.MoveLeft();
                }
                else if (resultTouch1[2])
                {
                    mvPlayer.MoveRight();
                }
                else if (resultTouch1[3])
                {
                    pauseRef.pauseGameMenu();
                }

                List<bool> resultTouch2 = ClickedOnButtons(t2.position);
                if (resultTouch2[0])
                {
                    mvPlayer.Jump();
                }
                else if (resultTouch2[1])
                {
                    mvPlayer.MoveLeft();
                }
                else if (resultTouch2[2])
                {
                    mvPlayer.MoveRight();
                }
                else if (resultTouch1[3])
                {
                    pauseRef.pauseGameMenu();
                }

            }
            else if (Input.touchCount == 1)
            {
                t1 = Input.GetTouch(0);

                
                List<bool> resultTouch1 = ClickedOnButtons(t1.position);
                if (resultTouch1[0])
                {
                    Debug.Log("Test");
                    mvPlayer.Jump();
                }
                else if (resultTouch1[1])
                {
                    mvPlayer.MoveLeft();
                }
                else if (resultTouch1[2])
                {
                    mvPlayer.MoveRight();
                }
                else if(resultTouch1[3])
                {
                    pauseRef.pauseGameMenu();
                }
            }
        }
    }

    private List<bool> ClickedOnButtons(Vector2 point)
    {
        List<bool> result = new List<bool>();

        foreach (Button b in touchUI)
        {
            result.Add(RectTransformUtility.RectangleContainsScreenPoint(b.gameObject.GetComponent<RectTransform>(), point, Camera.current));
        }

        return result;
    }

}
