using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent( typeof(CanvasGroup) )]
public class DialoguePanel : MonoBehaviour
{
    CanvasGroup canvasGroup;
    public TextMeshProUGUI textDisplay;
    public List<string> sentences;
    private int index;
    public float typingSpeed = 0.02f;
    public GameObject continueButton;
    public AudioClip continueBtnSFX;
    AudioSource audioSource;


    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    void Start()
    {
        StartNewDialogue( sentences );
    }

    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        audioSource.PlayOneShot(continueBtnSFX);
        continueButton.SetActive(false);

        if (index < sentences.Count - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;

            continueButton.SetActive(false);
        }
    }

    public void StartNewDialogue( List<string> newSentences )
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        index = 0;

        sentences = new List<string>( newSentences );
        textDisplay.text = "";
        StartCoroutine(Type());
    }

    
}
