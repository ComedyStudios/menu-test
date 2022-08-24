using System;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public enum CardType
{
    GameLauncher,
    ShutdownButton,
}

public class Card: MonoBehaviour
{
    [SerializeField] private CardType type;
    [SerializeField] private string path;
    [SerializeField] private string execName;
        
    public bool isSelected = false;

    private Animator _animator;
    private static readonly int IsSelected = Animator.StringToHash("isSelected");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(IsSelected, isSelected);
    }
        
    public void LaunchGame()
    {
        if (type == CardType.GameLauncher)
        {
            if (execName.Length >= 3 )
            {
                var FileType = execName.Substring(execName.Length-3, 3);
                UnityEngine.Debug.Log(FileType);

                if (FileType == "jar")
                {
                    var myProcess = new Process();
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.FileName = "java";
                    myProcess.StartInfo.Arguments = $"-jar {Directory.GetCurrentDirectory()}{path}/{execName}";
                    myProcess.Start();
                }
                else if (FileType == "exe")
                {
                    var myProcess = new Process();
                    myProcess.StartInfo.UseShellExecute = false;
                    myProcess.StartInfo.FileName = $"{Directory.GetCurrentDirectory()}{path}/{execName}";
                    myProcess.Start();
                }
            }
        }
        else if (type == CardType.ShutdownButton)
        {
            UnityEngine.Debug.Log("the console is shutting down");
            Application.Quit(0);
        }
    }
}