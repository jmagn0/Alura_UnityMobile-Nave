using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicaInstancia : MonoBehaviour
{
    [SerializeField] private bool _sobreescrever;

    private void Start()
    {
        var outrasInstancias = GameObject.FindGameObjectsWithTag(this.tag);
        foreach (var instancia in outrasInstancias)
        {
            if(instancia != this.gameObject)
            {
                if (_sobreescrever)
                {
                    Destroy(instancia);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
