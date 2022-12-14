using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinHolder : MonoBehaviour
{
    public static PinHolder instance{ get; private set; } //Singleton
    public List<GameObject> pins = new List<GameObject>();
    public List<Transform> pinPivots = new List<Transform>();
    public GameObject middleFloor;
    private void Awake() 
    { 
    // If there is an instance, and it's not me, delete myself.
    
        if (instance != null && instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            instance = this; 
        } 
    }

}
