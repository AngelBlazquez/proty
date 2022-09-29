using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    [Header("Player related stuff")]
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private RollingMovement rollingMovement;

    [Header("Dialogue Text")]
    [SerializeField]
    private List<string> text;
    [SerializeField]
    private List<string> speaker;

    [Header("No modification expected")]
    [SerializeField]
    private TextMeshProUGUI speakerText;
    [SerializeField]
    private TextMeshProUGUI dialogueText;
    [SerializeField]
    private GameObject dialogueBackground;

    private int currentIndex = 0;
    private bool lineStarted = false;
    private bool skipped = false;
    private bool waitForInteraction = false;

    public void ShowDialogue()
    {
        playerMovement?.FreezeMovement(true);
        rollingMovement?.FreezeMovement(true);
        dialogueBackground.SetActive(true);
        startNewLine();
    }

    private void startNewLine()
    {
        speakerText.text = speaker[currentIndex];
        dialogueText.text = "";
        StartCoroutine(SlowDisplay());
    }


    private IEnumerator SlowDisplay()
    {
        lineStarted = true;
        string currentText = text[currentIndex];
        for (int i = 0; i < currentText.Length; i++)
        {
            dialogueText.text = string.Concat(dialogueText.text, currentText[i]);
            yield return new WaitForSeconds(0.1f);
            if(skipped)
            {
                dialogueText.text = text[currentIndex];
                break;
            }
        }
        lineStarted = false;
        waitForInteraction = true;
        skipped = false;
    }


    public void ButtonInteraction()
    {
        if(waitForInteraction && currentIndex <= text.Count-2)
        {
            currentIndex++;
            waitForInteraction = false;
            startNewLine();
        } 
        else if(waitForInteraction && currentIndex >= text.Count-2)
        {
            dialogueBackground.SetActive(false);
            playerMovement?.FreezeMovement(false);
            rollingMovement?.FreezeMovement(false);
        }
        else if (lineStarted && !skipped)
        {
            skipped = true;
        }
    }
}
