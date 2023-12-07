using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cronometro : MonoBehaviour
{
    [SerializeField]
    float Timer = 0;

    [SerializeField]

    Text textoTimer;

    void Update()
    {
        Timer -= Time.deltaTime;

        textoTimer.text = ""+Timer.ToString("f1");
    }
}
