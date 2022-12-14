using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public int collided = 0;
    public List<GameObject> collidingRopes = new List<GameObject>();
    void OnTriggerEnter (Collider col){
        
        foreach (GameObject rope in collidingRopes){
            
            if(col.gameObject.name == rope.name){
                collided = 1;
                Debug.Log("collided count --> ");
            }
            
        }

    }

    /*
    void OnCollisionStay (Collision collision){
        Debug.Log("Staying");
    }
    void OnCollisionExit (Collision collision){
        Debug.Log("Exiting");
    }
    */
}
