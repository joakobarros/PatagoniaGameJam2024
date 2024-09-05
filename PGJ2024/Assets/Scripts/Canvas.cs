using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Canvas : MonoBehaviour
{
    public TextMeshProUGUI pescadores;
    public TextMeshProUGUI calamares;

    private void Start() 
    {
        pescadores.text = Record.Instance.pescadores.ToString(); 
        calamares.text = Record.Instance.calamares.ToString();     
    }
}
