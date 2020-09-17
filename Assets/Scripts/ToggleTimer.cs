using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToggleTimer : MonoBehaviour
{
    Color opaque = new Color(1,1,1,1);
    Color transparent = new Color(1,1,1,0);
    enum ToggleTimerRender{
        rendered,
        hidden
        
    }
    ToggleTimerRender toggleTimer;
    [SerializeField]
    Button timerButton;
    GameObject timeTextGO;
    Text timeText;
    void Start()
    {
        Button btn = timerButton.GetComponent<Button>();
        toggleTimer = ToggleTimerRender.rendered;
        timeTextGO = GameObject.Find("TimeText");
        timeText = timeTextGO.GetComponent<Text>();
        btn.onClick.AddListener(DoToggle);
    }

    ToggleTimerRender ToggleTimerVisibility(ToggleTimerRender toggle)
    {
        switch(toggle){
            case ToggleTimerRender.hidden:
                timeText.color = opaque;
                return ToggleTimerRender.rendered;
            case ToggleTimerRender.rendered:
                timeText.color = transparent;
                return ToggleTimerRender.hidden;
            default:
            throw new System.Exception("Unrecognized input");
        }
    }

    void DoToggle()
    {
        toggleTimer = ToggleTimerVisibility(toggleTimer);
    }

}
