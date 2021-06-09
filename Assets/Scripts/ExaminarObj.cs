using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExaminarObj : MonoBehaviour
{
       
    void Update()
    {
        Ray ray = Camera.main.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(GetComponent<Collider>().Raycast(ray, out hit, 500f))
        {
            print("Sobre o" + gameObject.name);
        }
    }
}
