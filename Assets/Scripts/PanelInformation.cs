using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelInformation : MonoBehaviour
{
    public int panelLabel = 0;
    
[SerializeField]
    GameObject panelPrefab;

    public Vector3 particleInitPos = Vector3.zero;

    

    public Vector3 particleInitVel = Vector3.zero;

    public float massCoefficient;
    public float massOOM;

    

    public void UpdateLabelText()
    {
        GameObject labelTextGO = transform.Find("panelLabel").gameObject;
        Text labelText = labelTextGO.GetComponentInChildren<Text>();
        labelText.text = panelLabel.ToString();
    }

    public Vector3 GetPositionConditions()
    {
        float xpos;
        float ypos;
        float zpos;
        try{
            xpos = float.Parse(transform.Find("posx").gameObject.GetComponentInChildren<Text>().text);
            Debug.Log(xpos);
        }
        catch{
            xpos = 0f;
        }
        try{
            ypos = float.Parse(transform.Find("posy").gameObject.GetComponentInChildren<Text>().text);
        }
        catch{
            ypos = 0f;
        }
        try{
            zpos = float.Parse(transform.Find("posz").gameObject.GetComponentInChildren<Text>().text);
        }
        catch{
            zpos = 0f;
        }
        Vector3 newPosition = new Vector3(xpos,ypos,zpos);
        Debug.Log(newPosition);
        return new Vector3(xpos,ypos,zpos);

    }
    public Vector3 GetVelocityConditions()
    {
        float xvel = 0f;
        float yvel = 0f;
        float zvel = 0f;
        xvel = float.Parse(transform.Find("velx").gameObject.GetComponentInChildren<Text>().text);
        yvel = float.Parse(transform.Find("vely").gameObject.GetComponentInChildren<Text>().text);
        zvel = float.Parse(transform.Find("velz").gameObject.GetComponentInChildren<Text>().text);
        return new Vector3(xvel,yvel,zvel);
    }

    public float GetMassCoefficient()
    {
        float mass = 6.6f;
        mass = float.Parse(transform.Find("factor").gameObject.GetComponentInChildren<Text>().text);
        return mass;
    }

    public float GetMassOOM()
    {
        float OOM = 20f;
        OOM = float.Parse(transform.Find("OOM").gameObject.GetComponentInChildren<Text>().text);
        return OOM;
    }

}
