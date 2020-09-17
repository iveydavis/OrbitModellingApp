using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglePause : MonoBehaviour
{
    enum TimeToggle{
        on,
        off
    }
    TimeToggle timeToggle; 
    [SerializeField]
    Button pauseButton;
    Text txt;
    public GameObject[] buttons;
    // Start is called before the first frame update
    void Start()
    {   
        buttons = GameObject.FindGameObjectsWithTag("InteractiveGUI");
        timeToggle = TimeToggle.off;
        Button btn = pauseButton.GetComponent<Button>();
        txt = GetComponentInChildren<Text>();
        btn.onClick.AddListener(DoToggle);   
    }

    TimeToggle TogglePlay(TimeToggle toggle)
    {
        
        switch (toggle){
            case TimeToggle.on:
                foreach (GameObject button in buttons){
                        button.SetActive(true);
                    }
                Time.timeScale = 0f;
                txt.text = "Play";
                return TimeToggle.off;
            case TimeToggle.off:
                foreach (GameObject button in buttons){
                    button.SetActive(false);
                }
                Time.timeScale = 1f;
                txt.text = "Pause";
                return TimeToggle.on;
            default:
                throw new System.Exception("Unrecognized input");
        }

    }

    void DoToggle()
    {
        timeToggle = TogglePlay(timeToggle);
    }
}
