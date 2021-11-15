using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeManager : MonoBehaviour
{
    public int[] sequence;

    public GameObject[] cloudSpikes;

    public enum SpikeType { instant, delayed, sequence };
    public SpikeType spikeType;

    // Start is called before the first frame update
    void Start()
    {
        if (spikeType == SpikeType.sequence)
        {
            Sequence();
        }
    }

    // Update is called once per frame
    void Update()
    {


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
        }
    }



    IEnumerator DelayedSpikeCoroutine()
    {
        yield return new WaitForSeconds(5);
        DeployAllSpikes();
    }

    IEnumerator SequenceCoroutine()
    {
        while (true)
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                cloudSpikes[sequence[i]].GetComponent<IndividualSpike>().changeState(true);
                yield return new WaitForSeconds(1.5f);
                cloudSpikes[sequence[i]].GetComponent<IndividualSpike>().changeState(false);
            }
            yield return new WaitForSeconds(2.5f);
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

    void Sequence()
    {
        StartCoroutine(SequenceCoroutine());
    }
}
