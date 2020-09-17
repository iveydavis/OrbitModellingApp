using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputConditionsController : MonoBehaviour
{
    int panelLabel =0;
    PanelInformation panelInformation;
    Vector3 particlePosition = Vector3.zero;
    Vector3 particleVelocity = Vector3.zero;

    enum ConditionType{
        x,
        y,
        z,
        vx,
        vy,
        vz,
        massCo,
        OOM,
    }
    [SerializeField]
    ConditionType conditionType;
    float massCoefficient = 6.6f;
    float massOOM = 24f;
    InputField inputField;

    void Awake()
    {
        panelInformation = GetComponentInParent<PanelInformation>();
        inputField = GetComponent<InputField>();
        inputField.contentType = InputField.ContentType.DecimalNumber;
        inputField.onEndEdit.AddListener(delegate{LockInput(inputField);});

    }

    // void SetConditionValues()
    // {
    //     particlePosition = panelInformation.GetPositionConditions();
    //     // particleVelocity = panelInformation.GetVelocityConditions();
    //     // massCoefficient = panelInformation.GetMassCoefficient();
    //     // massOOM = panelInformation.GetMassOOM();
    // }

    void SetConditionValues(ParticleBehaviour particleCont, GameObject particleGO)
    {
        Vector3 positionPreservation = particleGO.transform.position;
        Vector3 velocityPreservation = particleCont.velocity;
        float initx;
        Vector3 oneDimension = Vector3.zero;
        Vector3 newDimensionVal = Vector3.zero;
        switch(conditionType){
            case ConditionType.x:
                initx = positionPreservation.x;
                oneDimension = new Vector3(initx,0,0);
                newDimensionVal = new Vector3(float.Parse(inputField.text),0,0);
                particleGO.transform.position = positionPreservation -oneDimension + newDimensionVal;
                return;
            case ConditionType.y:
                initx = positionPreservation.y;
                oneDimension = new Vector3(0,initx,0);
                newDimensionVal = new Vector3(0,float.Parse(inputField.text),0);
                particleGO.transform.position = positionPreservation -oneDimension + newDimensionVal;
                return;
            case ConditionType.z:
                initx = positionPreservation.z;
                oneDimension = new Vector3(0,0,initx);
                newDimensionVal = new Vector3(0,0,float.Parse(inputField.text));
                particleGO.transform.position = positionPreservation -oneDimension + newDimensionVal;
                return;
            case ConditionType.vx:
                particleCont.velocity.x = float.Parse(inputField.text);
                return;
            case ConditionType.vy:
                particleCont.velocity.y = float.Parse(inputField.text);
                return;
            case ConditionType.vz:
                particleCont.velocity.z = float.Parse(inputField.text);
                return;
            case ConditionType.massCo:
                massCoefficient = float.Parse(inputField.text);
                panelInformation.massCoefficient = massCoefficient;
                massOOM = panelInformation.massOOM;
                particleCont.mass = massCoefficient*Mathf.Pow(10f,massOOM);
                return;
            case ConditionType.OOM:
                massOOM = float.Parse(inputField.text);
                panelInformation.massOOM = massOOM;
                massCoefficient = panelInformation.massCoefficient;
                particleCont.mass = massCoefficient*Mathf.Pow(10f,massOOM);
                return;
            default:
                throw new System.Exception("Unrecognized Condition type");
        }

    }
    void UpdateParticle()
    {
        panelLabel = panelInformation.panelLabel;
        GameObject[] particles = GameObject.FindGameObjectsWithTag("Particle");
        foreach(GameObject particle in particles){
            ParticleBehaviour particleController = particle.GetComponent<ParticleBehaviour>();
            int particleLabel = particleController.particleLabel;
            
            if (particleLabel == panelLabel){
                SetConditionValues(particleController,particle);
                break;
            }
        }
    }

    void LockInput(InputField input)
    {
        if (input.text.Length > 0){
            UpdateParticle();
        }
        else if (input.text.Length == 0){
            Debug.Log("Main Input Empty");
        }
    }
  

}
