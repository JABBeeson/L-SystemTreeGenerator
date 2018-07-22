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
    public GameObject branchPrefab;
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
        Spawn();
    }

    void Spawn()
    {
        
        Vector3 startPoint = this.transform.GetComponent("SpawnPoint").transform.position;
        Vector3 endPoint = Vector3.zero;
        List<Vector3> savePoints =null;    //CANNOT CREATE AN ARRAY WHICH CONTAINS VECTOR3S WHILST ALSO BEING ABLE TO APPEND TO THE ARRAY
        savePoints.Add(startPoint);
        int savePointLength =0;
        //Quaternion angle = Quaternion.identity;
        float degrees = 0;
        for(var i = 0; i <sentence.Length; i++)
        {
            string current = sentence[i].ToString();
            if (current == "F")
            {//Draw line
                var cylinder = Instantiate(branchPrefab, startPoint, Quaternion.identity);
                // float radians = angle.eulerAngles * Mathf.Deg2Rad;
                float radians = degrees * Mathf.Deg2Rad;
                float x = Mathf.Cos(radians);
                float y = Mathf.Sin(radians);
                endPoint.Set(x * cylinder.transform.localScale.x, y * cylinder.transform.localScale.y, 0);
                startPoint = endPoint;

            }
            if (current == "+")
            {//Rotate Right
                degrees += 20;
            }
            if (current == "-")
            {//Rotate Left
                degrees -= 20;
            }
            if (current == "[")
            {//Save Position
                savePoints.Add(startPoint);
                savePointLength++;  
            }
            if (current == "]")
            {//Teleport to saved position
                startPoint = savePoints[savePointLength];    //WHY ISNT THERE AN OPTION TO USE .LENGTH OR .SIZE???
                savePoints.RemoveAt(savePointLength);
                savePointLength--;

            }
        }
    }
}
