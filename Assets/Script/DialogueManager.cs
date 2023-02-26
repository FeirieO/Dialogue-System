using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] RectTransform dialogueBox;
    [SerializeField] static bool isActive;

    Message[] currentMessages;
    Character[] currentCharacter;
    int activeMessage = 0;

    void Start()
    {
        dialogueBox.transform.localScale = Vector3.zero;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            NextMessage();
        }
    }

    public void OpenDialogue(Message[] messages, Character[] characters)
    {
        currentMessages = messages;
        currentCharacter = characters;
        activeMessage = 0;
        isActive = true;
        dialogueBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo(); ;
        Debug.Log("Started Conversation! Loaded Messages: " + messages.Length);
        DisplayMessage();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        dialogueText.text = messageToDisplay.message;

        Character characterToDisplay = currentCharacter[messageToDisplay.characterId];
        nameText.text = characterToDisplay.name;

    }

    void NextMessage()
    {
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            isActive = false;
            Debug.Log("Conversation Ended");
        }
        dialogueBox.LeanScale(Vector3.zero, 10f).setEaseInOutExpo();
        activeMessage++;
    }
}
