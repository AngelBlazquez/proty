using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class AllDeath : MonoBehaviour
{
    public CountDeath CountDeath;

    public TextMeshProUGUI nbMorts;

    void Start()
    {
        StartCoroutine(Text());
    }

    private IEnumerator Text()
    {
        yield return new WaitForSeconds(0.001f);

        GameObject tmp = null;

        try
        {
            tmp = new GameObject();
            DontDestroyOnLoad(tmp);
            UnityEngine.SceneManagement.Scene dontDestroy = tmp.scene;
            Destroy(tmp);
            tmp = null;
            foreach(GameObject g in dontDestroy.GetRootGameObjects())
            {
                if (g.name == "CountDeath")
                {
                    CountDeath = g.GetComponent<CountDeath>();
                }
            }
        }
        finally
        {
            if(tmp != null)
            {
                Destroy(tmp);
            }
        }

        nbMorts.text = CountDeath.deaths[0].ToString();
    }
}
