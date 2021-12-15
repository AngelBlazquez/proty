using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public GameObject particuleDeath;

    public static bool playerDead = false;

    private void Start()
    {
        playerDead = false;
    }
    private IEnumerator Death()
    {
        playerDead = true;
        GameObject player = FindObjectOfType<PlayerMovement>().gameObject;
        Instantiate(particuleDeath, player.transform.position, Quaternion.identity);
        player.SetActive(false);

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartDeathCoroutine()
    {
        StartCoroutine(Death());
    }
}
