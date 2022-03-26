using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssemblePart : MonoBehaviour
{
    private AssembleManager assembleManager;
    [SerializeField]
    private string bodyPart;
    // Start is called before the first frame update
    void Start()
    {
        assembleManager = GameObject.Find("GameManager").GetComponent<AssembleManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<Rigidbody2D>().gameObject.CompareTag("Player"))
        {
            if (assembleManager.Assemble(bodyPart))
            {
                Destroy(gameObject);
            }
        }
    }
}
