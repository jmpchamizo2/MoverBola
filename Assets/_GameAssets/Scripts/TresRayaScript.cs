using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TresRayaScript : MonoBehaviour {
    [SerializeField] Camera camara;
    [SerializeField] GameObject prefabFichaPlayer;
    [SerializeField] GameObject prefabFichaRival;
    [SerializeField] Text ganadorText;
    bool turnoPlayer = true;
    int[] celdas = { -1, -1, -1, -1, -1, -1, -1, -1, -1 };
    int numTurnos = 0;
    int ganador;
    bool hayTresEnRaya;
    string ganadorTxt = "Tablas";
    [SerializeField] GameObject canvas;


    private void Start() {
        canvas.SetActive(false);
    }

    //private void Update() {
    //    if (numTurnos > 9) {
    //        return;
    //    }
    //    if(numTurnos == 9) {
    //        ganadorTxt = "Tablas";
    //        ActualizarTexto();
    //        canvas.SetActive(true);
    //        Invoke("Recargar", 10);
    //        numTurnos++;
    //    }else if(turnoPlayer && Input.GetMouseButtonDown(0)) {
    //        Ray ray = camara.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit rch;
    //        if (Physics.Raycast(ray, out rch)) {
    //            int indice = int.Parse(rch.transform.gameObject.name.Substring(4, 1));
    //            if(celdas[indice] != -1) {
    //                return;
    //            }
    //            GameObject ficha = Instantiate(prefabFichaPlayer, rch.transform.gameObject.transform);
    //            celdas[indice] = 0;
    //            turnoPlayer = false;
    //            numTurnos++;
    //            ComprobarTresEnRaya();
    //            if (numTurnos < 9) {
    //                Invoke("TurnoRival", 1);
    //            }
    //        }
    //    }
    //}


    private void Update() {
        if (numTurnos > 9) {
                    return;
        }
        if(numTurnos == 9) {
            ganadorTxt = "Tablas";
            ActualizarTexto();
            canvas.SetActive(true);
            Invoke("Recargar", 10);
            numTurnos++;
        }else if(turnoPlayer && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            Ray ray = camara.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit rch;
            if(Physics.Raycast(ray, out rch)) {
                int indice = int.Parse(rch.transform.gameObject.name.Substring(4, 1));
                if(celdas[indice] != -1) {
                    return;
                }
                GameObject ficha = Instantiate(prefabFichaPlayer, rch.transform.gameObject.transform);
                celdas[indice] = 0;
                turnoPlayer = false;
                numTurnos++;
                ComprobarTresEnRaya();
                if (numTurnos < 9) {
                    Invoke("TurnoRival", 1);
                }
            }
        }
    }

    private void TurnoRival() {
        turnoPlayer = true;
        GameObject casilla;
        int indice;
        do {
            indice = Random.Range(0, 8);
        } while (celdas[indice] != -1);
        casilla = GameObject.Find("Cube" + indice);
        GameObject ficha = Instantiate(prefabFichaRival, casilla.transform);
        celdas[indice] = 1;
        ComprobarTresEnRaya();
        turnoPlayer = true;
        numTurnos++;
    }


    private void ComprobarTresEnRaya() {
        hayTresEnRaya = false;
        if(celdas[0] != -1 && celdas[0] == celdas[1] && celdas[0] == celdas[2]) {
            hayTresEnRaya = true;
            ganador = celdas[0];
        }
        if (celdas[3] != -1 && celdas[3] == celdas[4] && celdas[3] == celdas[5]) {
            hayTresEnRaya = true;
            ganador = celdas[3];
        }
        if (celdas[6] != -1 && celdas[6] == celdas[7] && celdas[6] == celdas[8]) {
            hayTresEnRaya = true;
            ganador = celdas[6];
        }
        if (celdas[0] != -1 && celdas[0] == celdas[4] && celdas[0] == celdas[8]) {
            hayTresEnRaya = true;
            ganador = celdas[0];
        }
        if (celdas[1] != -1 && celdas[1] == celdas[4] && celdas[1] == celdas[7]) {
            hayTresEnRaya = true;
            ganador = celdas[1];
        }
        if (celdas[0] != -1 && celdas[0] == celdas[3] && celdas[0] == celdas[6]) {
            hayTresEnRaya = true;
            ganador = celdas[0];
        }
        if (celdas[2] != -1 && celdas[2] == celdas[4] && celdas[2] == celdas[6]) {
            hayTresEnRaya = true;
            ganador = celdas[2];
        }
        if (celdas[2] != -1 && celdas[2] == celdas[5] && celdas[2] == celdas[8]) {
            hayTresEnRaya = true;
            ganador = celdas[2];
        }
        if (hayTresEnRaya) {
            if (ganador == 0) {
                ganadorTxt = "Player Wins";
            } else if (ganador == 1) {
                ganadorTxt = "IA Wins";
            }
            ActualizarTexto();
            canvas.SetActive(true);
            Invoke("Recargar", 10);
            numTurnos = 10;
        }
        

    }

    private void Recargar() {
        SceneManager.LoadScene(0);
    }

    private void ActualizarTexto() {
        ganadorText.text = ganadorTxt;
    }


}
