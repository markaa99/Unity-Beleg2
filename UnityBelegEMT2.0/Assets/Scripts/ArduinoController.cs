using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoController : MonoBehaviour
{
    SerialPort sp = new SerialPort("COM4", 9600);
    private string arduinoData;
    void Start()
    {
        if (!sp.IsOpen)
        {
            sp.Open();
        }
    }

    void Update()
    {
        if (sp.IsOpen && sp.BytesToRead > 0) // Prüfen, ob Daten vorhanden sind
        {
            string data = sp.ReadLine();
            Debug.Log(data);
            arduinoData = data;
        }
    }

    public string GetData()
    {
        return this.arduinoData;
    }

    private void OnApplicationQuit()
    {
        if (sp.IsOpen)
        {
            sp.Close();
        }
    }
}
