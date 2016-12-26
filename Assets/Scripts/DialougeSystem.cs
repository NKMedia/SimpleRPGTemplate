using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeSystem : MonoBehaviour
{
    public static DialougeSystem Instance { get; set; }
    public GameObject dialougePannel;
   [HideInInspector] public string npcName;
   [HideInInspector] public List<string> dialogueLines = new List<string>();

    private Button continueButton;
    private Text dialogueText;
    private Text nameText;
    private int dialogueIndex;
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        } else {
            //This instance is the first and only one. Now we set it up.
            Instance = this;

            //Find Display Text and Lable References
            continueButton = dialougePannel.transform.FindChild("Continue_Button").GetComponent<Button>();
            dialogueText = dialougePannel.transform.FindChild("DialogueText").GetComponent<Text>();
            nameText = dialougePannel.transform.FindChild("NameLable").GetComponentInChildren<Text>();

            //Setup Button OnClick Event
            continueButton.onClick.AddListener(delegate { ContinueDialouge(); });

            //Disable the dialougePanel, because we don´t need it from the beginning.
            dialougePannel.SetActive(false);
        }
    }

    public void AddNewDialouge(string[] lines, string npcName)
    {
        //Reset the index
        dialogueIndex = 0;

        //Create a new empty list
        dialogueLines = new List<string>(lines.Length);
        
        //Populate the new list with the lines of dialouge for this npc.
        dialogueLines.AddRange(lines);

        //Set the panel nameLable to display this npc´s name
        this.npcName = npcName;

        //Set up the dialougeDisplay Pannel and Set it Active
        CreateDialouge();
    }

    public void CreateDialouge()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialougePannel.SetActive(true);
    }

    //Handle button clicks
    public void ContinueDialouge()
    {
        if (dialogueIndex < dialogueLines.Count - 1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }        else
        {
            dialougePannel.SetActive(false);
        }
    }
}
