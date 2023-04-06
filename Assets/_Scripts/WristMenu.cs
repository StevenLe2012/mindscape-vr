using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WristMenu : MonoBehaviour
{
 
    [SerializeField] private TMP_Text textArea;

    public void SendAdd()
    {
        textArea.text = "Pressed Add";
    }
    
    public void SendReset()
    {
        textArea.text = "Pressed Reset";
    }
    
    public void SendDiffusion()
    {
        textArea.text = "Pressed Stable Diffusion";
    }
}
