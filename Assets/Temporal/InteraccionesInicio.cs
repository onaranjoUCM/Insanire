using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionesInicio : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void IniciarJuego()
    {
        Application.LoadLevel("Introduccion");
    }
    public void Salir()
    {
        Debug.Log("Saliste jeje");
        Application.Quit();
    }
    public void NuevoPersonaje()
    {
        Application.LoadLevel("SeleccionPersonaje");
    }
    public void MenuInicio()
    {
        Time.timeScale = 1f;
        Application.LoadLevel("MenuInicio");
    }
    public void Intrucciones()
    {
        Application.LoadLevel("Instrucciones");
    }
    public void ReanudarJuego()
    {
        Debug.Log("Reanudar progreso)pendiente de cambio)");
        Application.LoadLevel("Introduccion"); // temporal
    }

}
