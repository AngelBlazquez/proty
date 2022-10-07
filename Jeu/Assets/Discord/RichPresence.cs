using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiscordPresence;
using UnityEngine.SceneManagement;

public class RichPresence : MonoBehaviour
{
    private string detail;
    private string state;
    private int offset = 2;

    void Start() {

    }

    void Update() {
    #if PLATFORM_ANDROID
    #else
        if (SceneManager.GetActiveScene().buildIndex <= 1
        || SceneManager.GetActiveScene().buildIndex == 12) {
            DansMenu();
        } else if (SceneManager.GetActiveScene().buildIndex == 2) {
            DansSelectionNiveau();
        } else {
            DansLevel(SceneManager.GetActiveScene().buildIndex);
        }
    #endif
    }

    public void DansMenu() {
        detail = "Dans le Menu Principal";
        state = "";
        PresenceManager.UpdatePresence(detail: detail, state: state);
    }

    public void DansSelectionNiveau() {
        detail = "Dans la sélection de niveau";
        state = "";
        PresenceManager.UpdatePresence(detail: detail, state: state);
    }

    public void DansLevel(int level) {
        level-=offset;
        if (level == 1) {
            detail = "Dans le niveau 1";
            state = "Toy Factory";
        } else if (level == 2) {
            detail = "Dans le niveau 2";
            state = "Two Sides";
        } else if (level == 3) {
            detail = "Dans le niveau 3";
            state = "Sky High";
        } else if (level == 4) {
            detail = "Dans le niveau 4";
            state = "Volcano Road";
        } else if (level == 5) {
            detail = "Dans le niveau 5";
            state = "Insanity";
        } else if (level == 6) {
            detail = "Dans le niveau 6";
            state = "Flatlands";
        } else if (level == 7) {
            detail = "Dans le niveau 7";
            state = "Cloudy Bridge";
        } else if (level == 8) {
            detail = "Dans le niveau 8";
            state = "Into The Dephts";
        } else if (level == 9) {
            detail = "Dans le niveau 9";
            state = "Dark Manor";
        }
        
        PresenceManager.UpdatePresence(detail: detail, state: state);
    }
}

