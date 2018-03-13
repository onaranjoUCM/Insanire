using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inicio : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Iniciar()
    {
        Application.LoadLevel("Introduccion");
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void Nuevo()
    {
        Application.LoadLevel("SeleccionPersonaje");
    }
    public void Volver()
    {
        Application.LoadLevel("MenuInicio");
    }
    public void Intrucciones()
    {
        Application.LoadLevel("Instrucciones");
    }
}
