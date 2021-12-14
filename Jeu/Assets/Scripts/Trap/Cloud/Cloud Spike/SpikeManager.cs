//Authors : BLAZQUEZ Angel / GANDELIN Benjamin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manage the state of all the spikes on the cloud.  
///</summary>
public class SpikeManager : MonoBehaviour
{
    [SerializeField]
    private float delayedSpikeTime = 2f;

    [SerializeField]
    private int[] sequence;

    [SerializeField]
    private float intervalBetweenSequence = 1f;
    [SerializeField]
    private float sequenceResetInterval = 1.5f;

    [SerializeField]
    private GameObject[] cloudSpikes;

    private enum SpikeType { instant, delayed, sequence, randomSequence };

    [SerializeField]
    private SpikeType spikeType;

    // Start is called before the first frame update
    void Start()
    {
        if (spikeType == SpikeType.sequence || spikeType == SpikeType.randomSequence)
        {
            StartCoroutine(SequenceCoroutine());
        }
    }

    /// <summary>
    /// When the trigger is triggered the spikes are deployed based on the choice made in the spikeType attribute.  
    ///</summary>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
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
    }

    /// <summary>
    /// Coroutine used to delay the spike activation.
    ///</summary>
    private IEnumerator DelayedSpikeCoroutine()
    {
        yield return new WaitForSeconds(delayedSpikeTime);
        DeployAllSpikes();
    }

    /// <summary>
    /// Coroutine used to play a sequence of spikes with delays.
    ///</summary>
    private IEnumerator SequenceCoroutine()
    {
        while (true)
        {
            if (spikeType == SpikeType.sequence)
            {
                for (int i = 0; i < sequence.Length; i++)
                {
                    StartCoroutine(SpikeControlWithDelay(sequence[i]));
                    yield return new WaitForSeconds(intervalBetweenSequence);
                }
            } else
            {
                for (int i = 0; i < cloudSpikes.Length; i++)
                {
                    StartCoroutine(SpikeControlWithDelay((int)Random.Range(0,cloudSpikes.Length)));
                    yield return new WaitForSeconds(intervalBetweenSequence);
                }
            }
            yield return new WaitForSeconds(sequenceResetInterval);
            yield return null;
        }
    }

    /// <summary>
    /// SequenceCoroutine helper that deal with the spike show and hide system with a delay.
    /// </summary>
    /// <param name="index">Current spike to show and hide</param>
    /// <returns>Wait for (intervalBetweenSequence) seconds</returns>
    private IEnumerator SpikeControlWithDelay(int index)
    {
        cloudSpikes[index].GetComponent<IndividualSpike>().changeState(true);
        yield return new WaitForSeconds(intervalBetweenSequence);
        cloudSpikes[index].GetComponent<IndividualSpike>().changeState(false);
    }

    /// <summary>
    /// Deploy all the spikes instantly.
    ///</summary>
    private void DeployAllSpikes()
    {
        foreach (GameObject g in cloudSpikes)
        {
            g.GetComponent<IndividualSpike>().changeState(true);
        }
    }
}
