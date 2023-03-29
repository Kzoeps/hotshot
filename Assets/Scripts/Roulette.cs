using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;


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
    private bool[] stopped = {false, false, false, false};
    public float delayTime;
    private bool isSlowed = false;
    public int selectedIndex;

    void Start()
    {
        StartCoroutine(SpinItUp(firstCode, letters, 0));    
        StartCoroutine(SpinItUp(secondCode, secondCodes, 1));    
        StartCoroutine(SpinItUp(thirdCode, thirdCodes, 2));    
        StartCoroutine(SpinItUp(fourthCode, fourthCodes, 3));    
    }

/**
    Function to continuosly change the letters like a roulette. It uses IEnumerator which i dont really know mucha bout.
    Based on whether the user has slowed time or not (i.e. isSlowed is true or false), the delay for the text switching is either 1 second(true) or 0.01 seconds(False)
**/
    IEnumerator SpinItUp(TextMeshProUGUI code, char[] codes, int index) {
        // while (stopped[index] == false) {
        //     foreach(char eachCode in codes) {
        //         code.text = eachCode.ToString();
        //         if (isSlowed) {
        //             yield return new WaitForSeconds(1);
        //         } else {
        //             yield return new WaitForSeconds(delayTime);
        //         }
        //     }
        // }
        while (stopped[index] == false) {
        foreach(char eachCode in codes) {
            code.text = eachCode.ToString();
            if (index == 0 && stopped[index]) { // check if the code is the first one and if it should stop
                break; // break out of the loop to stop at the current letter
            }
            if (isSlowed) {
                yield return new WaitForSeconds(1);
            } else {
                yield return new WaitForSeconds(delayTime);
            }
        }
    }
    }

    public void HandleClick(int index)
    {
        stopped[index] = !stopped[index];
        if (!stopped[index]) { // check if the code should start spinning again
            StartCoroutine(SpinItUp(GetCode(index), GetCodes(index), index)); // restart the coroutine
        }
    }

    private TextMeshProUGUI GetCode(int index) {
    switch (index) {
        case 0:
            return firstCode;
        case 1:
            return secondCode;
        case 2:
            return thirdCode;
        case 3:
            return fourthCode;
        default:
            return null;
    }
}

// helper function to get the codes array based on index
private char[] GetCodes(int index) {
    switch (index) {
        case 0:
            return letters;
        case 1:
            return secondCodes;
        case 2:
            return thirdCodes;
        case 3:
            return fourthCodes;
        default:
            return null;
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
