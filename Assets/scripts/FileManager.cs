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
        Debug.Log("test opening jar file");
        var strCmdText= "/C notepad";   //This command to open a new notepad
        System.Diagnostics.Process.Start("CMD.exe",strCmdText); //Start cmd process
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
