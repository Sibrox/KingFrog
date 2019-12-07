using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetStrega : MonoBehaviour
{

    public GameObject[] numbers = null;

    public Vector2[] positions;

    // Start is called before the first frame update
    void Start()
    {
        positions = new Vector2[numbers.Length];

        for(int i = 0; i < numbers.Length; i++)
        {
            positions[i] = numbers[i].transform.localPosition;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i].transform.localPosition = positions[i];
        }
    }
}
