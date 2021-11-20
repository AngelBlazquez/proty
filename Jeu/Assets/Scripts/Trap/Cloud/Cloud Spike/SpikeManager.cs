using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeManager : MonoBehaviour
{
    public float delayedSpikeTime = 2f;

    public int[] sequence;

    public float intervalBetweenSequence = 1f;
    public float sequenceResetInterval = 1.5f;

    public GameObject[] cloudSpikes;

    public enum SpikeType { instant, delayed, sequence };
    public SpikeType spikeType;

    // Start is called before the first frame update
    void Start()
    {
        if (spikeType == SpikeType.sequence)
        {
            StartCoroutine(SequenceCoroutine());
        }
    }

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
            default:
                break;
        }
    }

    IEnumerator DelayedSpikeCoroutine()
    {
        yield return new WaitForSeconds(delayedSpikeTime);
        DeployAllSpikes();
    }

    IEnumerator SequenceCoroutine()
    {
        while (true)
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                cloudSpikes[sequence[i]].GetComponent<IndividualSpike>().changeState(true);
                yield return new WaitForSeconds(intervalBetweenSequence);
                cloudSpikes[sequence[i]].GetComponent<IndividualSpike>().changeState(false);
            }
            yield return new WaitForSeconds(sequenceResetInterval);
            yield return null;
        }
    }

    void DeployAllSpikes()
    {
        foreach (GameObject g in cloudSpikes)
        {
            g.GetComponent<IndividualSpike>().changeState(true);
        }
    }
}
