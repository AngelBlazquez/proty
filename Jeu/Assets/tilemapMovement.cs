using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilemapMovement : MonoBehaviour
{
    void Update()
    {
        int r = Random.Range(0, 2);
        for (int i = 0; i < Random.Range(4, 10); i++) {
            if (r%2 == 0) {
                this.transform.position += new Vector3(this.transform.position.x + Random.Range(-0.01f, 0.01f), this.transform.position.y, this.transform.position.z);
                if (this.transform.position.x > 5) {
                    this.transform.position = new Vector3(5, this.transform.position.y, this.transform.position.z);
                } else if (this.transform.position.x < -5) {
                    this.transform.position = new Vector3(-5, this.transform.position.y, this.transform.position.z);
                }
            } else {
                this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + Random.Range(-0.01f, 0.01f), this.transform.position.z);
                if (this.transform.position.y > 5) {
                    this.transform.position = new Vector3(this.transform.position.x, 5, this.transform.position.z);
                } else if (this.transform.position.y < -5) {
                    this.transform.position = new Vector3(this.transform.position.x, -5, this.transform.position.z);
                }
            }
        }
    }
}
