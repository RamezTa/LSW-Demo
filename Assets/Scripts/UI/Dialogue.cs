using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed = 0.02f;
    public GameObject canvas;
    public GameObject continueButton;
    public AudioClip continueBtnSFX;
    AudioSource audioSource;

    private void Start()
    {
        textDisplay.text = "";
        StartCoroutine(Type());
        audioSource = GetComponent<AudioSource>();
    }


    private void Update()
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

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            canvas.SetActive(false);
            continueButton.SetActive(false);
        }
    }
}
