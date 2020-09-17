using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddObject : MonoBehaviour
{
    
    float mass;
    float radius;

    int panelLabel;

    [SerializeField]
    GameObject objectPrefab;

    [SerializeField]
    GameObject panelPrefab;
    Vector3 initPanelPos;
    float initLeft = 18.5f;
    float initRight = 572f;
    float initTop = 112f;
    float initBottom = 147f;

    float panelWidth;
    float panelHeight;

    float maxWidth;
    float maxHeight;

    Vector3 initialPos = Vector3.zero;
    Vector3 initialVel = Vector3.zero;
    [SerializeField]
    Button addObjectButton;

    
    public GameObject GUIGameObject;

    [SerializeField]
    GameObject pauseButton;
    
    int maxObjects = 10;
    int nParticles;
    // Start is called before the first frame update
    void Start()
    {
        maxWidth = GUIGameObject.GetComponent<RectTransform>().rect.width;
        maxHeight = GUIGameObject.GetComponent<RectTransform>().rect.height;
        panelHeight = maxHeight - initBottom - initTop;
        panelWidth = maxWidth - initRight - initLeft;
        Button btn = addObjectButton.GetComponent<Button>();
        btn.onClick.AddListener(InstantiateObject);
    }


    // Update is called once per frame
    void InstantiateObject()
    {
        if(nParticles < maxObjects){
        GameObject panelObject = Instantiate(panelPrefab,initPanelPos,Quaternion.identity);
        PanelInformation panelInfo = panelObject.GetComponent<PanelInformation>();
        panelObject.transform.SetParent(GUIGameObject.transform);
        initialPos = panelInfo.particleInitPos;
        initialVel = panelInfo.particleInitVel;
        

        GameObject gameObject = Instantiate(objectPrefab,initialPos,Quaternion.identity);
        ParticleBehaviour objectBehavior = gameObject.GetComponent<ParticleBehaviour>();
        objectBehavior.velocity = initialVel;
        
        GameObject[] particles = GameObject.FindGameObjectsWithTag("Particle");
        nParticles = particles.Length;
        objectBehavior.particleLabel = nParticles;
        panelInfo.panelLabel = nParticles;
        // Debug.Log(nParticles);
        SetPanelPosition(panelObject,nParticles);
        panelInfo.UpdateLabelText();

        TogglePause pauseControl = pauseButton.GetComponent<TogglePause>();
        pauseControl.buttons = GameObject.FindGameObjectsWithTag("InteractiveGUI");
        }
    }

    void SetPanelPosition(GameObject panel, int panelNumber)
    {
        RectTransform panelTransform = panel.GetComponent<RectTransform>();
        float panelFactor = (float)(panelNumber-1);
        // Debug.Log(panelFactor);
        // Debug.Log(panelHeight);
        panelTransform.offsetMin = new Vector2(initLeft + panelWidth*panelFactor,initBottom);
        panelTransform.offsetMax = new Vector2(-initRight + panelWidth*panelFactor, -initTop);
        if (-initRight +panelWidth*panelFactor > 0f){
            panelFactor = (float)(maxObjects - panelNumber);
            // Debug.Log(initBottom + panelHeight);
            panelTransform.offsetMin = new Vector2(initLeft + panelWidth*panelFactor,initBottom - panelHeight);
            panelTransform.offsetMax = new Vector2(-initRight + panelWidth*panelFactor, -initTop - panelHeight);
        }

    }
}
