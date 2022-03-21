using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InteractRadio : MonoBehaviour
{
    public bool isInRange = false;
    private Button interactButton;
    private GameObject interactObject;
    private Text buttonText;

    private void Start()
    {
        interactButton = GameObject.Find("InteractButton").GetComponent<Button>();
        buttonText = interactButton.GetComponentInChildren<Text>();
        buttonText.text = "Radio";
        interactButton.onClick.AddListener(OnClick);
    }

    private void Update()
    {
        buttonText.text = "Radio";
    }

    private void OnClick()
    {
        if (isInRange)
        {
            
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("MainCamera"))
        {
            isInRange = true;
            interactButton.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("MainCamera"))
        {
            isInRange = false;
            interactButton.gameObject.SetActive(false);
        }
    }
}
