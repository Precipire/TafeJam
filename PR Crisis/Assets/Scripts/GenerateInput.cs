using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GenerateInput : MonoBehaviour
{
    public Image[] sequence;
    public Sprite[] types;
    public Transform previousObject, firstPiece, lastPiece;
    public GameObject empty;
    public float distance;
    public bool first = true;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log(previousObject);
        SpawnSequence();
    }

    // Update is called once per frame
    void Update()
    {
      

        
        
    }
    public void SpawnSequence()
    {
        sequence = new Image[Random.Range(4, 10)];
        for (int i = 0; i < sequence.Length; i++)
        {
            if (first)
            {
                sequence[i] = Instantiate(empty, new Vector3(previousObject.position.x, previousObject.position.y, previousObject.position.z), Quaternion.identity, this.transform).GetComponent<Image>();
                first = false;
                firstPiece = sequence[i].transform;
                continue;
            }
            sequence[i] = Instantiate(empty, new Vector3(previousObject.position.x + distance, previousObject.position.y, previousObject.position.z), Quaternion.identity, this.transform).GetComponent<Image>();
            previousObject = sequence[i].transform;
            Debug.Log(previousObject);
        }
        lastPiece = sequence[sequence.Length - 1].transform;
        foreach (Image piece in sequence)
        {
            piece.sprite = types[Random.Range(0, 2)];
            //Debug.Log(types[Random.Range(0, 2)]);
        }
        float offset = Vector3.Distance(firstPiece.position, lastPiece.position) / 2;
        transform.position = new Vector3(transform.position.x - offset, transform.position.y, transform.position.z);
    }
}
