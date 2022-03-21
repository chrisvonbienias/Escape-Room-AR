using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InteractChest : MonoBehaviour
{
    public bool isInRange = false;
    private Button interactButton;
    private GameObject interactObject;
    private Text buttonText;

    private void Start()
    {
        interactButton = GameObject.Find("InteractButton").GetComponent<Button>();
        buttonText = interactButton.GetComponentInChildren<Text>();
        buttonText.text = "Chest";
        interactButton.onClick.AddListener(OnClick);

        interactObject = GameObject.Find("InputCodePanel");
    }

    private void Update()
    {
        buttonText.text = "Chest";
    }

    private void OnClick()
    {
        if (isInRange)
        {
            interactObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("MainCamera") || true)
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
