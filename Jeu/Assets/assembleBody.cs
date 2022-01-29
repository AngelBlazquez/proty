using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class assembleBody : MonoBehaviour
{
    public AssembleManager assembleManager;
    public GameObject Item;
    public GameObject BodyPart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        //GetComponent<GameManager>().GetComponent<AssembleManager>().assembleBody();
        assembleManager.assemble(Item, BodyPart);
    }
}
