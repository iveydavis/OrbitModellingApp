using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    float time = 0.0f;
    Text textVar;
    // Start is called before the first frame update
    void Start()
    {
        textVar = GetComponent<Text>();
        // Debug.Log(textVar);
    }
    void FixedUpdate()
    {
        textVar.text = "Time: "+ time.ToString("F2");
        time += Time.fixedDeltaTime;
        // textMesh.SetText("Time: {0}",time);
    }
}
