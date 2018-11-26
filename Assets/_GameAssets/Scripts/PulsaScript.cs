using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsaScript : MonoBehaviour {

    [SerializeField] GameObject helicoptero;
    Animator animador;

    private void Start() {
        animador = helicoptero.GetComponent<Animator>();  
    }

    public void AnimarHelicoptero() {
        animador.SetBool("volar", true);
    }
}
