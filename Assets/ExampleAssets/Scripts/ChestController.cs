using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField]
    private GameObject inputCodePanel;

    public void OpenInputCodePanel()
    {
        bool isOpen = inputCodePanel.activeSelf;
        inputCodePanel.SetActive(!isOpen);
    }
}
