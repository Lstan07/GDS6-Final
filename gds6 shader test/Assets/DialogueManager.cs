using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using TMPro;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    //[SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private string currentSentence;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    public bool dialogueIsPlaying { get; private set; }

    public Animator animator;

    private float speed = 0.03f;



    private static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene!");
        }
        instance = this;
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        //dialoguePanel.SetActive(false);
        animator.SetBool("IsOpen", false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }

        if (Input.GetMouseButtonDown(1))
        {

            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        //dialoguePanel.SetActive(true);
        animator.SetBool("IsOpen", true);

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        dialogueIsPlaying = false;
        // dialoguePanel.SetActive(false);
        animator.SetBool("IsOpen", false);
        //dialogueText.text = ""; 
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();

            string currentSentence = dialogueText.text;

            DisplayChoices();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(currentSentence));
        }
        else
        {

            ExitDialogueMode();
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support: " + currentChoices.Count);
        }

        int index = 0;

        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;


        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFristChoice());

    }

    private IEnumerator SelectFristChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

    IEnumerator TypeSentence(string currentSentence)
    {
        dialogueText.text = "";
        foreach (char letter in currentSentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(speed);
        }

    }
}
