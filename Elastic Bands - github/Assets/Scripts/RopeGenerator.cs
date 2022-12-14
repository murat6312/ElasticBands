using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeGenerator : MonoBehaviour
{
    public GameObject rope;
    public int ropeCount = 0;
    private GameObject sphere;
    private GameObject cloneRope;
    private int instantiateCount = 0;
    void Start(){
        if(ropeCount > 0){
            cloneRope = Instantiate(rope, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                                Quaternion.identity );
            sphere = cloneRope.transform.Find("StartSphere").gameObject; //İsmi değişme!!!!!!  
            ropeCount--;
            Debug.Log("first instantiates");
        } 

    }
    void Update()
    {
        if(sphere.GetComponent<Snap>().snapped == true && ropeCount > 0){
            cloneRope = Instantiate(rope, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                                     Quaternion.identity );
            Debug.Log("instantiated");
            sphere.GetComponent<Snap>().snapped = false; //?????????????????
            ropeCount--;
        }
        sphere = cloneRope.transform.Find("StartSphere").gameObject; //İsmi değişme!!!!!!  

        /*
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                Debug.Log("Something Hit");
                if (raycastHit.collider.name == "BasketYellow")
                {
                    Debug.Log("BasketYellow is hit");
                }else if(raycastHit.collider.name == "BasketGreen")
                {
                    Debug.Log("BasketGreen is hit");
                }else if(raycastHit.collider.name == "BasketRed")
                {
                    Debug.Log("BasketRed is hit");
                }
            }
        }
        */ 

        /*
        if(startSphere == null){
            Instantiate(rope, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity );
            Debug.Log("instantiated");
        }
        else{
            Debug.Log("not yet"+ startSphere.name);
        }
        */
    }
}
