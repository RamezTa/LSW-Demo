using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    
    [SerializeField] DialoguePanel dialoguePanel;

    [SerializeField] List<string> scenteces;

    public void StartConversation()
    {
        dialoguePanel.StartNewDialogue( scenteces );
    }
    
}
