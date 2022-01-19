using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssembleManager : MonoBehaviour
{
    public void assemble(GameObject goItem, GameObject go) {
        goItem.SetActive(false);
        go.SetActive(true);
    }
}
