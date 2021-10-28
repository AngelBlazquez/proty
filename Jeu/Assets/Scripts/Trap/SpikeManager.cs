using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeManager : MonoBehaviour
{
    int[] sequence;

    public GameObject[] cloudSpikes; 

    public enum SpikeType {instant, delayed, sequence};
    public SpikeType spikeType;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        switch (spikeType)
        {
            case SpikeType.instant:
                instantSpike();
                break;
            case SpikeType.delayed:

                break;
            case SpikeType.sequence:

                break;
        }
    }


    void instantSpike()
    {
        foreach (GameObject g in cloudSpikes) {
            g.GetComponent<IndividualSpike>().changeState(true);
        }
    }
}
