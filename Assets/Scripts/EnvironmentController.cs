using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    public enum TimeScale{
        defaultScale,
        second,
        minute,
        hour,
        day,
        week,
        month
    }
    public TimeScale timeScale;


    public enum DistanceScale{
        EarthRadius,
        JupiterRadius,
        SolarRadius,
        AU,
        oneToOne,
        Angstrom
    }
    
    public DistanceScale distanceScale;
    public float distVal;
    public float timeVal;
    float million = Mathf.Pow(10f,6f);
    float billion = Mathf.Pow(10f,9f);

    void Awake()
    {
        Time.timeScale = 0f;
    }
    public void SetTimeScale(TimeScale scale)
    {
        switch(scale){
            case TimeScale.defaultScale:
                Time.fixedDeltaTime = 0.02f;
                timeVal =  1.0f;
                return;
            case TimeScale.second:
                //Time.fixedDeltaTime = 1f;
                timeVal =  1.0f;
                return;
            case TimeScale.minute:
                //Time.fixedDeltaTime = 1f;
                timeVal =  60f;
                return;
            case TimeScale.hour:
                //Time.fixedDeltaTime = 1f;
                timeVal =  3600f;
                return;
            case TimeScale.day:
                //Time.fixedDeltaTime = 1f;
                timeVal =  3600f*24f;
                return;
            case TimeScale.week:
                timeVal =  3600f*24f*7f;
                return;
            case TimeScale.month:
                timeVal =  3600f*24f*30f;
                return;
            default:
                timeVal = 1f;
                throw new System.Exception("Unrecognized time scale: "+scale);
        }

    }
    public void SetDistanceScale(DistanceScale distance)
    {
        switch(distance){
            case DistanceScale.EarthRadius:
                distVal = 6.371f*million;
                return;
            case DistanceScale.JupiterRadius:
                distVal = 69.911f*million;
                return;
            case DistanceScale.SolarRadius:
                distVal = 693.34f*million;
                return;
            case DistanceScale.AU:
                distVal = 149.6f*billion;
                return;
            case DistanceScale.oneToOne:
                distVal = 1f;
                return;
            case DistanceScale.Angstrom:
                distVal = Mathf.Pow(10f,-10f);
                return;
            default:
                distVal = 1f;
                throw new System.Exception("Unrecognized distance scale: "+ distance);
        }
    }
    
}
