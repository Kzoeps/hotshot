using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Roulette : MonoBehaviour
{
    public TMPro.TextMeshProUGUI firstCode;
    public TMPro.TextMeshProUGUI secondCode;
    public TMPro.TextMeshProUGUI thirdCode;
    public TMPro.TextMeshProUGUI fourthCode;
    public bool spin = true;
    public bool slowDown = false;
    public char[] letters;
    private char[] secondCodes = {'A','D', 'E', 'G', 'H'};
    private char[] thirdCodes= {'L','K', 'F', 'R', 'I'};
    private char[] fourthCodes= {'M','B', 'L', 'P', 'Z'};
    public float delayTime;
    private bool isSlowed = false;
    public int selectedIndex;

    void Start()
    {
        StartCoroutine(SpinItUp(firstCode, letters));    
        StartCoroutine(SpinItUp(secondCode, secondCodes));    
        StartCoroutine(SpinItUp(thirdCode, thirdCodes));    
        StartCoroutine(SpinItUp(fourthCode, fourthCodes));    
    }

/**
    Function to continuosly change the letters like a roulette. It uses IEnumerator which i dont really know mucha bout.
    Based on whether the user has slowed time or not (i.e. isSlowed is true or false), the delay for the text switching is either 1 second(true) or 0.01 seconds(False)
**/
    IEnumerator SpinItUp(TextMeshProUGUI code, char[] codes) {
        while (true) {
            foreach(char eachCode in codes) {
                code.text = eachCode.ToString();
                if (isSlowed) {
                    yield return new WaitForSeconds(1);
                } else {
                    yield return new WaitForSeconds(delayTime);
                }
            }
        }
    }

    public void SetIsSlowedTrue() {
        isSlowed = true;
        Invoke("SetIsSlowedFalse", 2f);
    }

    public void SetIsSlowedFalse() {
        isSlowed = false;
    }

    void Update()
    {
        
    }
}
