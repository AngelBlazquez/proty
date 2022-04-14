using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchCoin : MonoBehaviour
{

    [SerializeField]
    private DataManager data;
    // Start is called before the first frame update
    void Start()
    {
        data = FindObjectOfType<DataManager>().GetComponent<DataManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            data.AddCoin();
            Destroy(this.gameObject);
        }
    }
}
