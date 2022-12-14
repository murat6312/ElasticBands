using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Snap : MonoBehaviour
{
    string fingerState;
    private Snap otherSnap;
    private List<Transform> pinPivots = new List<Transform>();
    private List<GameObject> pins = new List<GameObject>();
    private int pinCount;
    private int totalConnectedNum = 0;
    private BoxCollider middleFloorCollider;
    private int middleFloorFlag = 0;
    public GameObject otherSphere;
    public GameObject otherSpherePivot;
    private Vector3 otherSpherePivotPos;
    public GameObject thisSphere;
    public GameObject thisSpherePivot;
    private Vector3 thisSpherePivotPos;
    public float snapDistance = 0.5f;
    //public float lerpTime = 5; //lerpte kullanılır
    public GameObject obiRodDrag;
    private MeshRenderer rodDragMesh;
    public GameObject obiRod;
    private MeshRenderer rodMesh;
    public AudioSource audioSource;
    [HideInInspector]public bool snapped = false;
    public GameObject pinTriggerCube;
    //private TMP_Text resultText;  

     void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        otherSnap = otherSphere.GetComponent<Snap>();

        middleFloorCollider = PinHolder.instance.middleFloor.GetComponent<BoxCollider>();
        middleFloorCollider.enabled = true;

        rodDragMesh = obiRodDrag.GetComponent<MeshRenderer>();
        rodDragMesh.enabled = true;
        rodMesh = obiRod.GetComponent<MeshRenderer>();
        rodMesh.enabled = true; //false

        pinTriggerCube.SetActive(false);

        pinPivots = PinHolder.instance.pinPivots;
        pins = PinHolder.instance.pins;
        pinCount=pins.Count;

        //resultText = GetComponent<TextMeshProUGUI>();
        
    }

    void FixedUpdate()
    {
        //score();
        meshToggle();

        middleFloorFlag++;
        if(middleFloorFlag > 10){ //10 middlefloorcolliderı'nın yeniden aktif olması için beklenen frame sayısı

            middleFloorCollider.enabled = true;
        }

        float smallestDistance = snapDistance;
        /*//lookat kullanmadan çevirme yolu (başka yollarda var linklerde)
        var lookDirection = transform.position - otherSphere.transform.position;
        var lookOrientation = Quaternion.LookRotation(transform.position - otherSphere.transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookOrientation, 0.5f );
        //Startsphere y = -90 endsphere y = 90 */

        this.transform.LookAt(otherSphere.transform, Vector3.up); //Startsphere y = 90 endsphere y = -90
        
        if(snapped == false)
        {
            foreach (Transform pivot in pinPivots)
            {
           
                thisSpherePivotPos = thisSpherePivot.transform.position;
                otherSpherePivotPos = otherSpherePivot.transform.position;
                
                    
                if (Vector3.Distance(pivot.position, thisSpherePivotPos) < smallestDistance)
                {
                    

                    if( Physics.Raycast(thisSpherePivotPos, otherSpherePivotPos - thisSpherePivotPos, 4.0f))
                    {                                       
                        Debug.Log("IN RAYCAST!!");
                                                    
                        if( Input.touchCount == 0 )
                        {
                            Debug.Log("SNAPPED!!");
                            snapped = true;

                            middleFloorFlag = 0;
                            middleFloorCollider.enabled = false; 

                            pinTriggerCube.SetActive(true);
                        
                            thisSpherePivot.transform.position = pivot.position;
                            //StartCoroutine(Example());
                            //Lerp//thisSpherePivot.transform.position = Vector3.Lerp(thisSpherePivot.transform.position, pin.position, Time.deltaTime/snapTime);
                                                                                        //3.parametre ne kadar gerekli şüpheli
                                                                                        //Mathf.SmoothStep() yada direk 0.5f te mümkün
                            smallestDistance = Vector3.Distance(pivot.position, thisSpherePivotPos);
                            if (audioSource != null){
                                audioSource.Play();
                            }else{
                                Debug.Log("null");
                            }

                            Destroy(thisSphere, 1f); //snaplemeden yokediyo galiba
                            Destroy(otherSphere, 1f);
                        
                        }
                    }
                }
            }
        }
    }

    private void meshToggle(){
        if( fingerState == "down" && otherSnap.fingerState == "down" ){
            rodDragMesh.enabled = false;
            rodMesh.enabled = true;
        }
        if( fingerState == "up" && otherSnap.fingerState == "down" ){
            rodDragMesh.enabled = true;
            rodMesh.enabled = true; //false
        }
        if( fingerState == "down" && otherSnap.fingerState == "up" ){
            rodDragMesh.enabled = true;
            rodMesh.enabled = true; //false
        }
        if( fingerState == "up" && otherSnap.fingerState == "up" ){
            rodDragMesh.enabled = false;
            rodMesh.enabled = true;
        }
    }
    public void fingerDown()
    {fingerState = "down";}

    public void fingerUp()
    {fingerState = "up";}

    /*
    private void score(){

        foreach (GameObject pin in pins){
            totalConnectedNum += pin.GetComponent<CollisionDetector>().collided;
        }
        if(totalConnectedNum == pinCount){
            Debug.Log("U WIN!");
            resultText.text = "YOU WIN!";
            Application.Quit();
        }else{
            totalConnectedNum = 0;
        }
    }
    */
}