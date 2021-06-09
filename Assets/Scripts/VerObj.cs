using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerObj : MonoBehaviour
{
    public GameObject[] inspectionObjects;
    private int currIndex;

    public void TurnOnInspection(int index)
    {
        currIndex = index;
        inspectionObjects[index].SetActive(true);
    }

    public void TurnOffInspection()
    {
        inspectionObjects[currIndex].SetActive(false);
    }
}
