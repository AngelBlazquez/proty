using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathManager : MonoBehaviour
{
    [SerializeField]
    private GameObject particuleDeath;
    [SerializeField]
    private DataManager data;

    private GameObject player;

    private CountDeath CountDeath;

    public TextMeshProUGUI nbMorts;

    private void Start()
    {
        StartCoroutine(Text());
    }

    private IEnumerator Text()
    {
        yield return new WaitForSeconds(0.5f);

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
        
        nbMorts.text = CountDeath.deaths[SceneManager.GetActiveScene().buildIndex].ToString();
    }

    private IEnumerator Death()
    {
        if(CountDeath != null) {
            data.AddDeath();
        }
        
        Instantiate(particuleDeath, player.transform.position, Quaternion.identity);
        player.SetActive(false);

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartDeathCoroutine(GameObject g)
    {
        player = g;
        StartCoroutine(Death());
    }
}
