using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    [SerializeField]
    private GameObject particuleDeath;
    private GameObject player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    private IEnumerator Death()
    {
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
