using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeManager : MonoBehaviour
{
<<<<<<< HEAD
    public float delayedSpikeTime = 2f;

    public int[] sequence;

    public float intervalBetweenSequence = 1f;
    public float sequenceResetInterval = 1.5f;

=======
    public int[] sequence;

>>>>>>> 668f8b2 (Nuage avec effet de rebond terminé)
    public GameObject[] cloudSpikes;

    public enum SpikeType { instant, delayed, sequence };
    public SpikeType spikeType;

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        if (spikeType == SpikeType.sequence)
        {
            StartCoroutine(SequenceCoroutine());
        }
    }

=======
        if ((int)spikeType == (int)SpikeType.sequence)
        {
            Sequence();
        }
    }

    // Update is called once per frame
    void Update()
    {


    }

>>>>>>> 668f8b2 (Nuage avec effet de rebond terminé)
    private void OnTriggerEnter2D(Collider2D collider)
    {

        switch (spikeType)
        {
            case SpikeType.instant:
                DeployAllSpikes();
                break;
            case SpikeType.delayed:
                StartCoroutine(DelayedSpikeCoroutine());
                break;
<<<<<<< HEAD
            default:
=======
            case SpikeType.sequence:
>>>>>>> 668f8b2 (Nuage avec effet de rebond terminé)
                break;
        }
    }

<<<<<<< HEAD
    IEnumerator DelayedSpikeCoroutine()
    {
        yield return new WaitForSeconds(delayedSpikeTime);
=======


    IEnumerator DelayedSpikeCoroutine()
    {
        yield return new WaitForSeconds(5);
>>>>>>> 668f8b2 (Nuage avec effet de rebond terminé)
        DeployAllSpikes();
    }

    IEnumerator SequenceCoroutine()
    {
        while (true)
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                cloudSpikes[sequence[i]].GetComponent<IndividualSpike>().changeState(true);
<<<<<<< HEAD
                yield return new WaitForSeconds(intervalBetweenSequence);
                cloudSpikes[sequence[i]].GetComponent<IndividualSpike>().changeState(false);
            }
            yield return new WaitForSeconds(sequenceResetInterval);
=======
                yield return new WaitForSeconds(1.5f);
                cloudSpikes[sequence[i]].GetComponent<IndividualSpike>().changeState(false);
            }
            yield return new WaitForSeconds(2.5f);
>>>>>>> 668f8b2 (Nuage avec effet de rebond terminé)
            yield return null;
        }
    }

    void DeployAllSpikes()
    {
        foreach (GameObject g in cloudSpikes)
        {
<<<<<<< HEAD
            g.GetComponent<IndividualSpike>().changeState(true);
        }
    }
=======

            g.GetComponent<IndividualSpike>().changeState(true);
        }
    }

    void Sequence()
    {
        StartCoroutine(SequenceCoroutine());
    }
>>>>>>> 668f8b2 (Nuage avec effet de rebond terminé)
}
