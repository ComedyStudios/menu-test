using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class FileManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var myProcess = new Process();
        myProcess.StartInfo.UseShellExecute = false;
        myProcess.StartInfo.FileName = "java";
        myProcess.StartInfo.Arguments = "-jar C:\\programming\\konsole\\Konsole\\out\\artifacts\\Konsole_jar\\Konsole.jar";
        myProcess.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
