using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CheckCode : MonoBehaviour
{
    public InputField code1;
    public InputField code2;
    public InputField code3;
    public UnityEvent interactAction;

    private void Awake()
    {
 
    }
    public void IsCodeCorrect()
    {
        if(code1.text == "3" && code2.text == "1" && code3.text == "4")
        {
            interactAction.Invoke();
        }
    }
}
