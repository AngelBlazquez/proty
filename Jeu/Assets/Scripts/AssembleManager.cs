using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssembleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] playerModels;

    private Dictionary<string, bool> parts;
    private GameObject activePlayer;
    private CameraMovement cameraMvt;

    void Start()
    {
        activePlayer = GameObject.Find("HeadPlayer");
        cameraMvt = GameObject.Find("Camera").GetComponent<CameraMovement>(); ;
        parts = new Dictionary<string, bool>
        {
            { "Body",false },
            { "Arms",false },
            { "Legs",false },
        };
    }

    /// <summary>
    /// Adds the body part to the body
    /// </summary>
    /// <param name="name">The name of the part</param>
    /// <returns>If the part has been added</returns>
    public bool Assemble(string name)
    {
        bool integrated = false;
        Vector3 newPos = activePlayer.transform.position + Vector3.up;
        GameObject newPlayer = null;
        if (parts.ContainsKey(name))
        {
            if (name.Equals("Body"))
            {
                newPlayer = Instantiate(playerModels[1], newPos, new Quaternion(0, 0, 0, 0));
                integrated = true;
            }
            else
            {
                if (parts["Body"] == true)
                {
                    integrated = true;
                    if (name.Equals("Arms"))
                    {
                        if (parts["Legs"])
                        {
                            newPlayer = Instantiate(playerModels[4], newPos, new Quaternion(0, 0, 0, 0));
                        }
                        else
                        {
                            newPlayer = Instantiate(playerModels[2], newPos, new Quaternion(0, 0, 0, 0));
                        }
                    }
                    else
                    {
                        if (parts["Arms"])
                        {
                            newPlayer = Instantiate(playerModels[4], newPos, new Quaternion(0, 0, 0, 0));
                        }
                        else
                        {
                            newPlayer = Instantiate(playerModels[3], newPos, new Quaternion(0, 0, 0, 0));
                        }
                    }
                }
            }
        }
        if (integrated)
        {
            parts[name] = true;
            cameraMvt.ChangePlayer(newPlayer);
            Destroy(activePlayer);
            activePlayer = newPlayer;
        }
        return integrated;
    }

}
