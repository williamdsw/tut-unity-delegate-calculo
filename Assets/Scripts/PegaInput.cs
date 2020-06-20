using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// DELEGATES
public delegate void DelegateMethod (object sender, Somatoria somatoria);

public class PegaInput : MonoBehaviour
{
    //--------------------------------------------------------------------//
    // FIELDS 

    // Config
    private float cooldownTimer = 0.5f;

    // State
    private float horizontalCooldown = 0;
    private float verticalCooldown = 0;

    // Cached
    private Somatoria somatoria;

    // Delegates
    private DelegateMethod Soma;

    //--------------------------------------------------------------------//
    // MONOBEHAVIOUR FUNCTIONS 

    private void Start () 
    {
        somatoria = new Somatoria ();
        somatoria.SetSoma (1000f);
    }

    private void Update () 
    {
        int horizontal = Mathf.RoundToInt (Input.GetAxisRaw ("Horizontal"));
        int vertical = Mathf.RoundToInt (Input.GetAxisRaw ("Vertical"));
        Vector2Int input = new Vector2Int (0, 0);

        if (horizontal != 0)
        {
            input.x = GetInput (ref horizontalCooldown, horizontal);
        }
        else 
        {
            horizontalCooldown = 0;
        }

        if (vertical != 0)
        {
            input.y = GetInput (ref verticalCooldown, vertical);
        }
        else 
        {
            verticalCooldown = 0;
        }

        if (input != Vector2Int.zero)
        {
            if (input.x != 0)
            {
                Debug.Log("pushed x: " + input.x);
                Soma += TesteSoma;
            }

            if (input.y != 0 && Soma != null)
            {
                Debug.Log("pushed y: " + input.y);
                Soma (null, somatoria);
            }
        }
    }

    //--------------------------------------------------------------------//
    // HELPER FUNCTIONS

    private int GetInput (ref float cooldown, int axis)
    {
        if (Time.time > cooldown)
        {
            cooldown += (Time.time + cooldownTimer);
            return axis;
        }

        return 0;
    }

    private void TesteSoma (object sender, Somatoria somatoria)
    {
        float soma = somatoria.GetSoma ();
        soma += (soma * somatoria.GetJuros ());
        somatoria.SetSoma (soma);
        Debug.Log ("Soma: " + soma);
    }
}