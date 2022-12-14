using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
public class GetEndSpherePos : MonoBehaviour
{
    public GameObject otherSphere;
    //private bool flag2 = true;
    private float posy;
    private Vector3 startPos;
    private Vector3 direction;
    public float min = 0;
    public float max = 0;
    private bool ssmoving = false;
    void Start(){
        posy = this.transform.position.y;
    }
    void FixedUpdate()
    {

         if (Input.touchCount > 1 && ssmoving == true)
        {
        
            Touch touch = Input.GetTouch(1);
            Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);

            pos = new Vector3(pos.x, posy, pos.z); //y pozisyonu dokunmadan önceki pozisyona eşit (diğer türlü sıkıntı çıkarıyo)


            this.transform.position = pos;
            
            this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x ,
                                    otherSphere.transform.position.x + min,otherSphere.transform.position.x + max),
                                    Mathf.Clamp(this.transform.position.y ,
                                    otherSphere.transform.position.y + min,otherSphere.transform.position.y + max),
                                    Mathf.Clamp(this.transform.position.z ,
                                    otherSphere.transform.position.z + min,otherSphere.transform.position.z + max));
                                  

            ////////////////////////////////////////////////////////////////////////////////////      
            
            /*

            if(flag2==true){

                this.transform.position = new Vector3(otherSphere.transform.position.x + (pos.x-otherSphere.transform.position.x)/3,
                                                posy, otherSphere.transform.position.z + (pos.z-otherSphere.transform.position.z)/3);
                
                flag2 = false;
            }
            else
            {

                direction= pos-startPos;
                this.transform.position = new Vector3(this.transform.position.x + direction.x, posy,
                                                    this.transform.position.z + direction.z);
                
                
                //transform.position = new Vector3(Mathf.Clamp(this.transform.position.x + direction.x,
                                        otherSphere.transform.position.x+ minX,otherSphere.transform.position.x + maxX),
                                        Mathf.Clamp(this.transform.position.y + direction.y,
                                        otherSphere.transform.position.y+ minY,otherSphere.transform.position.y+ maxY),
                                        Mathf.Clamp(this.transform.position.z + direction.z,
                                        otherSphere.transform.position.z+minZ,otherSphere.transform.position.z+ maxZ));
                
            }
            startPos = pos;

            */
            

            /*
            if(touch.phase==TouchPhase.Began){
                
                startPos = pos;
                this.transform.position = new Vector3(otherSphere.transform.position.x + (pos.x-otherSphere.transform.position.x)/5, posy,
                                    otherSphere.transform.position.z + (pos.z-otherSphere.transform.position.z)/5);
            }
            else if(touch.phase==TouchPhase.Moved){
                direction= pos-startPos;
                this.transform.position = new Vector3(pos.x + direction.x, posy, pos.z + direction.z);
            }
            */

        
        }
        
    }
    public void startSphereMoving(){
        ssmoving = true;
    }
    public void startSphereStopped(){
        ssmoving = false;
    }
    
}
