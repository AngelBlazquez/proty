using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyRegisterUI : MonoBehaviour
{
    [SerializeField]
    private GameObject button;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            button.GetComponent<Button>().onClick.Invoke();
        }
    }
}
