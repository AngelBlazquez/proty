using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private GameObject timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(timer);
    }
}
