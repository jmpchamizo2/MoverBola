using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour {
    [SerializeField] int velocidad = 5;
    [SerializeField] Transform target;
    private int sentido = 0;


    private void Update() {
        target.transform.Translate(new Vector3(sentido,0,0) * velocidad * Time.deltaTime);
    }


    public void MoverDerecha() {
        sentido = 1;
        Invoke("Parar", 2);
    }

    public void MoverIzquierda() {
        sentido = -1;
        Invoke("Parar", 2);
    }

    public void Parar() {
        sentido = 0;
    }


}
