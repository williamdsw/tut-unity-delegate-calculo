using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Somatoria
{
    //--------------------------------------------------------------------//
    // FIELDS 

    private float soma = 0;
    private float juros = 0.15f;

    //--------------------------------------------------------------------//
    // GETTERS / SETTERS 

    public float GetSoma ()
    {
        return this.soma;
    }

    public void SetSoma (float soma)
    {
        this.soma = soma;
    }

    public float GetJuros ()
    {
        return this.juros;
    }
}