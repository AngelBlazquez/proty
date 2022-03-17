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

    public TextMeshProUGUI nbMorts;

    private void Start()
    {
        nbMorts.text = data.GetDeath().ToString();
    }

    private IEnumerator Death()
    {
        data.AddDeath();

        data.AddDeathLevel(SceneManager.GetActiveScene().buildIndex - 3);
        
        Instantiate(particuleDeath, player.transform.position, Quaternion.identity);
        player.SetActive(false);

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
        nbMorts.text = data.GetDeath().ToString();
    }

    public void StartDeathCoroutine(GameObject g)
    {
        player = g;
        StartCoroutine(Death());
    }
}
