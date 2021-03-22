using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FractalGenerator : MonoBehaviour
{
    public GameObject cubePrefab;
    public int iterations;

    public int numberOfCubesToDrawPerFrame;

    string test;

    int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        test = "F-F-F-F";

        for(int i = 0; i < iterations; i++)
        {
            test = TestReplace(test);
        }


    }


    // Update is called once per frame
    void Update()
    {
        if(currentIndex < test.Length)
            currentIndex = TurtleDrawing(test, currentIndex);
    }
    


    int TurtleDrawing(string sentence, int startingIndex)
    {

        int endingIndex = startingIndex + numberOfCubesToDrawPerFrame;

        if (endingIndex > sentence.Length)
        {
            endingIndex = sentence.Length;
        }

        for (int i = startingIndex; i < endingIndex; i++)
        {
            if(sentence[i] == 'F')
            {
                Instantiate(cubePrefab, transform.position, transform.rotation);
                transform.position += transform.forward;
            }
            else if (sentence[i] == 'f')
            {
                transform.position += transform.forward;
            }
            else if(sentence[i] == '+')
            {
                transform.Rotate(0.0f, 90.0f, 0.0f);
            }
            else if(sentence[i] == '-')
            {
                transform.Rotate(0.0f, -90.0f, 0.0f);
            }
        }

        return endingIndex;
    }



    string TestReplace(string sentence)
    {
        string temp = null;

        for(int i = 0; i < sentence.Length; i++)
        {
            if (sentence[i] == 'F')
            {
                temp = temp + "F-F+F+FF-F-F+F";
            }
            else
            {
                temp = temp + sentence[i];
            }
        }

        return temp;
    }

}
