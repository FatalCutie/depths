using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    bool fucker = false;
    bool pisser = true;
    List<bool> shitter = new List<bool>();
    void Start()
    {
        shitter.Add(fucker);
        shitter.Add(pisser);
        foreach (bool b in shitter)
        {
            Debug.Log(b);
        }

        Debug.Log(shitter.Find(x => fucker));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
