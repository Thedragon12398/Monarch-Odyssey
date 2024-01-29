using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capture : MonoBehaviour
{
    public Material[] materials;
    public Renderer Rend;
    private int index = 1;

    public void buttonPressed()
    {
        if (materials.Length == 0) return;

        index += 1;

        if (index == materials.Length + 1) index = 1;

        print(index);
        Rend.sharedMaterial = materials[index - 1]; 
    }
}