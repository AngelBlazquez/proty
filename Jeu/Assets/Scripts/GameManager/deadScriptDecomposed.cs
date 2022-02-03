using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class deadScriptDecomposed : MonoBehaviour
{
    [SerializeField]
    private GameObject particuleDeath;

    private GameObject player; // On ne l'utiulise pas

    [SerializeField]
    private GameObject armsPlayer; 

    [SerializeField]
    private GameObject legsPlayer;

    [SerializeField]
    private GameObject classicPlayer;

    [SerializeField]
    private GameObject decomposedPlayer;

    private CountDeath CountDeath;

    public TextMeshProUGUI nbMorts;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;


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

    private IEnumerator Death(GameObject player)
    {
        CountDeath.addDeath();

        Instantiate(particuleDeath, player.transform.position, Quaternion.identity);
        player.SetActive(false);

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartDeathCoroutineArmsPlayer()
    {
        StartCoroutine(Death(armsPlayer));
    }

    public void StartDeathCoroutineLegsPlayer()
    {
        StartCoroutine(Death(legsPlayer));
    }

    public void StartDeathCoroutineClassicPlayer()
    {
        StartCoroutine(Death(classicPlayer));
    }

    public void StartDeathCoroutineDecomposedPlayer()
    {
        StartCoroutine(Death(decomposedPlayer));
    }
}
