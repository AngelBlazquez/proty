using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDisplayHolder : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> levelDisplays;

    #region Getter
    public List<GameObject> GetDisplay() { return levelDisplays; }
    #endregion
}
