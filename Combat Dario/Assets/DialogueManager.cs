using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance { get; private set; }

    public GameObject panel; 
    public Text name_box;
    public Text dialogue_box;
    public Image avatar_box;
    private Queue<string> sentences;
    private Queue<Dialogue> diags;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        diags = new Queue<Dialogue>();
    }

    public void StartDialogue(Dialogue[] dialogue)
    {
        foreach(Dialogue d in dialogue)
        {
            diags.Enqueue(d);
        }
        StartDialogue();
    }

    public void StartDialogue()
    {
        Dialogue dialogue = diags.Dequeue();

        Time.timeScale = 0;
        panel.SetActive(true);


        name_box.text = dialogue.name;
        avatar_box.sprite = dialogue.avatar;
        

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0 && diags.Count == 0)
        {
            EndDialogue();
            return;
        }else if(sentences.Count == 0)
        {
            StartDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogue_box.text = sentence;
    }

    public void EndDialogue()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
        Debug.Log("Dialogue Ended");
    }
}
