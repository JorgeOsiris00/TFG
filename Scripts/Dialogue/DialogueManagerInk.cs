using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Ink.UnityIntegration;

public class DialogueManagerInk : MonoBehaviour
{
    [Header("Globals Ink File")]
    [SerializeField] private InkFile globalsInkFile;
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;

    // es publica en el get y private en el set
    public bool dialogueIsPlaying { get; private set; }

    private static DialogueManagerInk instance;


    private DialogueVariables dialogueVariables;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene.");
        }
         instance = this;

        dialogueVariables = new DialogueVariables(globalsInkFile.filePath);
    }


    public static DialogueManagerInk GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        // cogemos todos los textos de ls opciones
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
        // retorna true cuando el sistema de dialogo no se esta usando 
        if(!dialogueIsPlaying)
        {
            return;
        }

        // continua con la siguiente linea del dialogo cuando se pulsa el boton
        if (Input.GetKeyDown("space"))
        {
            ContinueStory();

        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        dialogueVariables.StartListening(currentStory);


        ContinueStory();
    }


    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.5f);

        dialogueVariables.StopListening(currentStory);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }


    private void ContinueStory()
    {

        if (currentStory.canContinue)
        {
            // manda el texto de currentDialogue
            dialogueText.text = currentStory.Continue();
            // pone las opcions de la linea, si tiene
            DisplayChoices();
        }
        else
        {
            StartCoroutine( ExitDialogueMode() );
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        // comprobacion de que la UI puede con el numero de opciones que se añaden
        if(currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. " +
                "           Number of choices given:  " + currentChoices.Count);
        }


        int index = 0;
        // iniciador y indicativo de que coincide la opcion I con su texto correspondiente
        foreach( Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);

        }
        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
    }

    // coger los valores de las variables globales de Global.ink
    public Ink.Runtime.Object getVariablesState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);
        if(variableValue == null)
        {
            Debug.LogWarning("Variable Ink se encontro como null: " + variableValue);
        }
        return variableValue;
    }
}
