using System;
using System.Collections;
using UnityEngine;

public class ListManager : MonoBehaviour
{
    private UserInput _input;
    private int _selectedGame;
    private RectTransform _rectTransform;
    private Animator _animator;
        
    private bool isMoving;
    private float inputValue;
    private static readonly int MovementInput = Animator.StringToHash("movementInput");

    private void OnEnable()
    {
        _input = new UserInput();
        _input.UiNavigation1.Enable();
        _input.UiNavigation1.Press.performed += _ => StartGame();
    }

    private void OnDisable()
    {
        _input.UiNavigation1.Disable();
    }

    private void Start()
    {
        _selectedGame = 1;
        switchCardState();
        _rectTransform = GetComponent<RectTransform>();
        _animator = GetComponent<Animator>();
    }

    private void StartGame()
    {
        var childTransform = transform.GetChild(_selectedGame);
        if ( childTransform.TryGetComponent(out Card cardScript))
        {
            cardScript.LaunchGame();
        }
    }
    private void Update()
    {
        inputValue = _input.UiNavigation1.move.ReadValue<Vector2>().x;
        if (!isMoving && inputValue != 0 && _selectedGame + inputValue >=  0 && _selectedGame+inputValue<transform.childCount)
        {
            StartCoroutine(moveGames());
        }
    }

    IEnumerator moveGames()
    { 
        isMoving = true;    
        switchCardState();
        int value = -Mathf.RoundToInt(inputValue);
        for (int i = 0; i<35; i++)
        {
            transform.parent.localPosition += new Vector3(4 * value, 0,0);
            yield return new WaitForSeconds(0.0001f);
        }
        _selectedGame -= value;
        switchCardState();
        yield return new WaitForSeconds(0.25f);
        isMoving = false;
    }
        

    private void switchCardState()
    {
        var child = transform.GetChild(_selectedGame);
        var cardScript = child.GetComponent<Card>();
        cardScript.isSelected = cardScript.isSelected != true;
    }

    bool AnimatorIsPlaying(){
        return _animator.GetCurrentAnimatorStateInfo(0).length >
               _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }
}