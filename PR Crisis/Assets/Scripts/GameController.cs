using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    float startTime;
    public float holdTime = 5f;
    public GenerateInput input;
    bool held, pressed, doneHold, isRunning, alreadyHeld;
    public Sprite heldDone, pressedDone;
    // Start is called before the first frame update
    void Start()
    {
        
            StartCoroutine("KeyHold");
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    IEnumerator KeyHold()
    {
        if (isRunning)
        {
            yield break;
        }
        else
        {
            isRunning = true;
        }

        int sequenceNumber = 0;
        
        Debug.Log(sequenceNumber);
        while (isRunning)
        {
            
            /*if (!Input.anyKey)
            {
                alreadyHeld = false;
            }*/
            Debug.Log(sequenceNumber);
            if (input.sequence[sequenceNumber].sprite.name == "Button_Hold")
            {
                
                /*while (alreadyHeld)
                {
                    
                    yield return null;
                }*/
                if (sequenceNumber >= input.sequence.Length)
                {

                    isRunning = false;
                    yield break;
                }

                while (startTime < holdTime)
                {
                    while (Input.anyKey)
                    {
                        //Debug.Log(startTime);
                        startTime += Time.deltaTime;
                        if (startTime > holdTime)
                        {
                            input.sequence[sequenceNumber].sprite = heldDone;
                            
                        }
                        yield return null;
                    }
                    
                    yield return null;
                }
                Debug.Log("test");
                startTime = 0;
                
                sequenceNumber++;
                alreadyHeld = true;
                //yield return null;
            }
            if(input.sequence[sequenceNumber].sprite.name == "Button_Tap")
            {
                
                
                if (sequenceNumber >= input.sequence.Length)
                {
                   
                    yield break;
                }
                while(pressed)
                {
                    yield return null;
                }

                while (!pressed)
                {

                    if (Input.anyKeyDown)
                    {
                        pressed = true;
                    }
                    yield return null;
                }
                input.sequence[sequenceNumber].sprite = pressedDone;
                sequenceNumber++;
                alreadyHeld = true;
                pressed = false;
            }
            if (sequenceNumber >= input.sequence.Length)
            {
                foreach (Image t in input.sequence)
                {
                    Destroy(t.gameObject);
                }
                sequenceNumber = 0;
                input.previousObject = GameObject.Find("SequenceSpawner").GetComponent<Transform>();
                input.first = true;
                input.SpawnSequence();
                yield return null;
            }
        }
        
    }

    
}
