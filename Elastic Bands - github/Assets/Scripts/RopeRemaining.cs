using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RopeRemaining : MonoBehaviour
{
    public int ropeRemained;
    private int count = 0;
    public List<GameObject> baskets = new List<GameObject>();
    public GameObject pinholder;
    private List<GameObject> pins = new List<GameObject>();
    private int pinCount;
    private int totalConnectedNum = 0;
    public TMP_Text resultText;
    public TMP_Text pinsLeft;
    void start(){
        resultText = GetComponent<TextMeshProUGUI>(); 
        pins = pinholder.GetComponent<PinHolder>().pins;
        pinCount=pins.Count;
    }
    void Update()
    {
        foreach (GameObject basket in baskets){
            
            count += basket.GetComponent<RopeGenerator>().ropeCount;
            
        }
        ropeRemained = count;
        if(ropeRemained == 0){
            Debug.Log("GAME OVER!!");
            resultText.text = "GAME OVER!!";
        }
        count = 0;

        score();
    }
    private void score(){

        foreach (GameObject pin in pins){
            totalConnectedNum += pin.GetComponent<CollisionDetector>().collided;
        }
            int x = pinCount - totalConnectedNum;
            string y = ""+x;
            pinsLeft.text = y;
        if(totalConnectedNum == pinCount){
            Debug.Log("U WIN!");
            resultText.text = "YOU WIN!";
            Application.Quit();
        }else{
            totalConnectedNum = 0;
        }
    }
}
