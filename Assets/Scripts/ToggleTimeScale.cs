using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleTimeScale : MonoBehaviour
{
    [SerializeField]
    Dropdown dropDown;
    Text dropDownSelection;
    EnvironmentController controller;
    GameObject[] particles;

    void Start()
    {
        controller = GameObject.Find("EnvironmentControls").GetComponent<EnvironmentController>();
        PopulateList();
        Dropdown drp = dropDown.GetComponent<Dropdown>();
        drp.onValueChanged.AddListener(delegate{ToggleTimeScaleVal(drp);});
        // Debug.Log(controller.timeScale);
    }
    void PopulateList()
    {
        string[] enumNames = Enum.GetNames(typeof(EnvironmentController.TimeScale));
        List<string> names = new List<string>(enumNames);
        dropDown.AddOptions(names);
    }
    void ToggleTimeScaleVal(Dropdown drp)
    {
        int index = drp.value;
        string selection = drp.options[index].text;
        

        EnvironmentController.TimeScale sec = EnvironmentController.TimeScale.second;
        EnvironmentController.TimeScale minute = EnvironmentController.TimeScale.minute;
        EnvironmentController.TimeScale hour = EnvironmentController.TimeScale.hour;
        EnvironmentController.TimeScale day = EnvironmentController.TimeScale.day;
        EnvironmentController.TimeScale week = EnvironmentController.TimeScale.week; 
        EnvironmentController.TimeScale month =  EnvironmentController.TimeScale.month;

        if(String.Equals(selection,Enum.GetName(typeof(EnvironmentController.TimeScale),sec))){
            controller.SetTimeScale(sec);
        }
        else if(String.Equals(selection,Enum.GetName(typeof(EnvironmentController.TimeScale),day))){
            controller.SetTimeScale(day);
        }
        else if(String.Equals(selection,Enum.GetName(typeof(EnvironmentController.TimeScale),week))){
            controller.SetTimeScale(week);
        }
        else if(String.Equals(selection,Enum.GetName(typeof(EnvironmentController.TimeScale),month))){
            controller.SetTimeScale(month);
        }
        else if(String.Equals(selection,Enum.GetName(typeof(EnvironmentController.TimeScale),minute))){
            controller.SetTimeScale(minute);
        }
        else if(String.Equals(selection,Enum.GetName(typeof(EnvironmentController.TimeScale),hour))){
            controller.SetTimeScale(hour);
        }
        else{
            // controller.SetTimeScale(sec);
            throw new SystemException("Unrecognized time scale");
        }
        // Debug.Log(controller.timeVal);
        particles = GameObject.FindGameObjectsWithTag("Particle"); 
        foreach (GameObject particle in particles){
            ParticleBehaviour particleBehaviour = particle.GetComponent<ParticleBehaviour>();
            particleBehaviour.velocityMultiplier = controller.timeVal;
        }
    }
}


