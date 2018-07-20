using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LSystemScript : MonoBehaviour {

    /*AXIOM - taken to be true.
    Rules:
    A -> A, B
    B -> A
    */


    public Button generateButton;
    public Text L_SystemText;
    private string axiom = "F";
    public string sentence;

    string[] rule1 = { "F", "FF+[+F-F-F]-[-F+F+F]" };
    //string[] rule1 = { "A", "AB" };
    //string[] rule2 = { "B", "A" };



    // Use this for initialization
    void Start () {
        //ui setup
        generateButton.onClick.AddListener(Generate);

        sentence = axiom;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Generate()
    {
        string nextSentence = "";
        for(int i =0; i < sentence.Length; i++)
        {
            string current = sentence[i].ToString();
            if (current == rule1[0])
            {
                nextSentence += rule1[1];
            }
            //else if (current == rule2[0])
            //{
            //    nextSentence += rule2[1];
            //}
            else
            {
                nextSentence += current;
            }
        }
        sentence = nextSentence;
        L_SystemText.text = sentence;
    }

    void Spawn()
    {
        for(var i = 0; i <sentence.Length; i++)
        {
            string current = sentence[i].ToString();
            if (current == "F")
            {//Draw line
            }
            if (current == "+")
            {//Rotate Right
            }
            if (current == "-")
            {//Rotate Left
            }
            if (current == "[")
            {//Save Position
            }
            if (current == "]")
            {//Teleport to saved position
            }
        }
    }
}
