using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class displayText : MonoBehaviour {

    public Text displayTexto;
    public float typingSpeed = 0.1f;

    //string awesomeString = "D:/Unity/Projects/Unity test project/Assets/splashes.txt"; //Remember to change file path
    private string awesomeString;                                                        //Hi, yes I remembered !
    private string filePath;

    private string[] documentLines;
    //private int currentLineIndex = 0;


    // Use this for initialization
    void Start () {

        string relativePath = "resources/splashes.txt";
       // awesomeString = Path.Combine(Application.persistentDataPath, "splashes.txt");
      //  documentLines = System.IO.File.ReadAllLines(awesomeString);
        //DisplayNextLine();
        // StartCoroutine(TypeText(documentLines[Random.Range(0, documentLines.Length)]))
       // StartCoroutine(DisplayLinesWithDelay());
        // Get the full path to the persistent data path

       filePath = Path.Combine(Application.persistentDataPath, "splashes.txt");
      if (!File.Exists(filePath))
        {
            // Load the text asset from the Resources folder
            //string[] documentLines = File.ReadAllLines(filePath);
            TextAsset textAsset = Resources.Load<TextAsset>(Path.GetFileNameWithoutExtension("splashes.txt"));

            if (textAsset != null)
            {
                // Save the content of the text asset to the persistent data path
                File.WriteAllText(filePath, textAsset.text);
                Debug.Log("File created: " + filePath);
            }
            else
            {
                Debug.LogError("Could not load " + "splashes.txt" + " from Resources folder.");

            }
        }

        awesomeString = Path.Combine(Application.persistentDataPath, "splashes.txt");
        documentLines = System.IO.File.ReadAllLines(awesomeString);
        StartCoroutine(DisplayLinesWithDelay());
    }

    // Update is called once per frame
    void Update () { 
    }

    IEnumerator DisplayLinesWithDelay()
    {
        while (true)
        {
            // Select a random index
            int randomIndex = Random.Range(0, documentLines.Length);

            // am folosit yield return pentru a produce unul câte unul din elementele din lista, în loc să le producă pe toate odată.
            yield return StartCoroutine(TypeText(documentLines[randomIndex])); //Initial incercasem cu un for dar am gasit ca e mai usor cu un yield

            //Dupa 60 de secunde apare o noua linie
            yield return new WaitForSeconds(60f);
        }
    }

    IEnumerator TypeText(string textToType)
    {
        displayTexto.text = "";

        foreach (char letter in textToType)
        {
            displayTexto.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}


/* [Chorus]
Can you blow my whistle, baby, whistle, baby? Let me know
Girl, I'm gonna show you how to do it and we start real slow
You just put your lips together and you come real close
Can you blow my whistle, baby, whistle, baby? Here we go
*/
