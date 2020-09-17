using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleDistanceScale : MonoBehaviour
{
    [SerializeField]
    Dropdown dropDown;
    Text dropDownSelection;
    GameObject[] particles;
    
    float million = Mathf.Pow(10f,6f);
    float billion = Mathf.Pow(10f,9f);
    EnvironmentController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("EnvironmentControls").GetComponent<EnvironmentController>();
        PopulateList();
        Dropdown drp = dropDown.GetComponent<Dropdown>();
        drp.onValueChanged.AddListener(delegate{ToggleDistanceScaleVal(drp);});
    }

    void ToggleDistanceScaleVal(Dropdown drp)
    {
        int index = drp.value;
        string selection = drp.options[index].text;
        EnvironmentController.DistanceScale AU = EnvironmentController.DistanceScale.AU;
        EnvironmentController.DistanceScale earthRadius = EnvironmentController.DistanceScale.EarthRadius;
        EnvironmentController.DistanceScale jupiterRadius = EnvironmentController.DistanceScale.JupiterRadius;
        EnvironmentController.DistanceScale solarRadius = EnvironmentController.DistanceScale.SolarRadius;
        EnvironmentController.DistanceScale oneToOne = EnvironmentController.DistanceScale.oneToOne;
        // Debug.Log(selection);
        // Debug.Log(Enum.GetName(typeof(EnvironmentController.DistanceScale),AU));
        if(String.Equals(selection,Enum.GetName(typeof(EnvironmentController.DistanceScale),AU))){
            controller.SetDistanceScale(AU);
        }
        else if(String.Equals(selection,Enum.GetName(typeof(EnvironmentController.DistanceScale),earthRadius))){
            controller.SetDistanceScale(earthRadius);
        }
        else if(String.Equals(selection,Enum.GetName(typeof(EnvironmentController.DistanceScale),jupiterRadius))){
            controller.SetDistanceScale(jupiterRadius);
        }
        else if(String.Equals(selection,Enum.GetName(typeof(EnvironmentController.DistanceScale),solarRadius))){
            controller.SetDistanceScale(solarRadius);
        }
        else if(String.Equals(selection,Enum.GetName(typeof(EnvironmentController.DistanceScale),oneToOne))){
            controller.SetDistanceScale(oneToOne);
        }
        else{
            throw new SystemException("Unrecognized Selection");
        }
        particles = GameObject.FindGameObjectsWithTag("Particle");
        foreach (GameObject particle in particles){
            ParticleBehaviour particleBehaviour = particle.GetComponent<ParticleBehaviour>();
            particleBehaviour.distanceMultiplier = controller.distVal;
        }
    }

    void PopulateList()
    {
        string[] enumNames = Enum.GetNames(typeof(EnvironmentController.DistanceScale));
        List<string> names = new List<string>(enumNames);
        dropDown.AddOptions(names);
    }

    
}
