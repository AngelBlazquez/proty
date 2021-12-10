using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public int timer = 0;

    IEnumerator CoroutineTimer() 
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            timer += 1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(CoroutineTimer());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
