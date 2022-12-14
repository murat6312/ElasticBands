using UnityEngine;
 using System.Collections;
 
 public class ObjectLimit : MonoBehaviour 
 {
     public GameObject otherSphere;
	 public float min = 0;
	 public float max = 0;
	 
	 void FixedUpdate()
	 {
		//ekranda tek parmak varken startSphere takip etmek için kullanılıyo
		transform.position = new Vector3(Mathf.Clamp(this.transform.position.x,
											otherSphere.transform.position.x+ min,otherSphere.transform.position.x + max),
											Mathf.Clamp(this.transform.position.y,
											otherSphere.transform.position.y+ min,otherSphere.transform.position.y+ max),
											Mathf.Clamp(this.transform.position.z,
											otherSphere.transform.position.z+min,otherSphere.transform.position.z+ max));
	 
	 }
 
 }