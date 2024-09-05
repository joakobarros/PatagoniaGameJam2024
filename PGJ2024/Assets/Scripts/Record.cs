using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record : MonoBehaviour
{
    public static Record Instance { get; private set; }

    [SerializeField] public int pescadores;
    [SerializeField] public int calamares;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void Setpescadores()
    {
        pescadores++;
    }

    public void SetCalamares(int camtC)
    {
        calamares += camtC;
    }

    public int GetPescadores()
    {
        return pescadores;
    }

    public int GetCalamares()
    {
        return calamares;
    }
}
