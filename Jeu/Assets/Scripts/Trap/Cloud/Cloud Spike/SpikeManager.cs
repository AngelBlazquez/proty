//Authors : BLAZQUEZ Angel / GANDELIN Benjamin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manage the state of all the spikes on the cloud.  
///</summary>
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

    /// <summary>
    /// When the trigger is triggered the spikes are deployed based on the choice made in the spikeType attribute.  
    ///</summary>
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

    /// <summary>
    /// Coroutine used to delay the spike activation.
    ///</summary>
    IEnumerator DelayedSpikeCoroutine()
    {
        yield return new WaitForSeconds(delayedSpikeTime);
        DeployAllSpikes();
    }

    /// <summary>
    /// Coroutine used to play the sequence of spikes with delays.
    ///</summary>
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

    /// <summary>
    /// Deploy all the spikes instantly.
    ///</summary>
    void DeployAllSpikes()
    {
        foreach (GameObject g in cloudSpikes)
        {
            g.GetComponent<IndividualSpike>().changeState(true);
        }
    }
}
