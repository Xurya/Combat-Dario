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
    private Queue<string> sentences;

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
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Time.timeScale = 0;
        panel.SetActive(true);


        name_box.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
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
