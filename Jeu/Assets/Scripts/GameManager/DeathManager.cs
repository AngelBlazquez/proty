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
<<<<<<< HEAD
        SceneManager.LoadScene(0);
=======
        playerDead = false;
    }
    public IEnumerator Death()
    {
        Debug.Log("ok death1");
        playerDead = true;
        GameObject player = FindObjectOfType<PlayerMovement>().gameObject;
        Instantiate(particuleDeath, player.transform.position, Quaternion.identity);
        Destroy(player);

        yield return new WaitForSeconds(2f);
        Debug.Log("ok deaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaath");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
>>>>>>> d6da431a4aa5675022b72562fd1e2dfc192529ca
    }
}
