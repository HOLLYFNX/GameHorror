using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVida : MonoBehaviour
{
    public static float VIDA = 100;
    void Update()
    {
        if (VIDA <= 0)
        {
            Debug.Log("morreu");
        }
    }
}
