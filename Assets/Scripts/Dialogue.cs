using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public string[] sentences;
    public TextMeshProUGUI textDisplay;
    private int index;
    public float typeSpeed;
    public GameObject continueButton;

    private void Start()
    {
        StartCoroutine(TypeText());
        continueButton.SetActive(true);
    }
    IEnumerator TypeText()
        {
            foreach (char letter in sentences[index].ToCharArray())
            {
                textDisplay.text += letter;
                yield return new WaitForSeconds(typeSpeed);
            }
        }

    // Update is called once per frame
    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
            Debug.Log("Inside of Update");
        }
    }

    public void NextSentence()
    {
        continueButton.SetActive(false);
        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = " ";
            StartCoroutine(TypeText());
        }
        else
        {
            textDisplay.text = " ";
            continueButton.SetActive(false);
        }
    }
}
