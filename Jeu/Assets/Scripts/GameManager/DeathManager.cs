﻿using System.Collections;
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
        nbMorts.text = (data.GetDeath()/2).ToString();
    }

    private IEnumerator Death()
    {
        data.AddDeath();

        data.AddDeathLevel(SceneManager.GetActiveScene().buildIndex - 3);
        
        Instantiate(particuleDeath, player.transform.position, Quaternion.identity);
        player.SetActive(false);

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator Respawn(KillPlayer piege)
    {
        yield return new WaitForSeconds(2f);
        player.transform.position = TrainingMode.lastPosition;
        player.SetActive(true);
        TrainingMode.canSavePosition = true;
        piege.ActivateTrap();
    }

    public void StartDeathCoroutine(GameObject g, KillPlayer piege)
    {
        player = g;
        data.AddDeath();
        Instantiate(particuleDeath, player.transform.position, Quaternion.identity);
        Animator animator = player.GetComponentInChildren<Animator>();
        if (animator != null)
        {
            animator.Play("IdlePerso");
            animator.Update(0f);
        }
        player.SetActive(false);
        if (TrainingMode.GetIsTraining())
        {
            StartCoroutine(Respawn(piege));
        }
        else
        {
            StartCoroutine(Death());
        }
        nbMorts.text = data.GetDeath().ToString();
    }
}
