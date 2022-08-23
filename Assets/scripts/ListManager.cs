using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class ListManager : MonoBehaviour
    {
        private UserInput _input;
        private int _selectedGame;
        private RectTransform _rectTransform;
        private Animator _animator;
        
        private bool isMoving;
        private static readonly int MovementInput = Animator.StringToHash("movementInput");

        private void OnEnable()
        {
            _input = new UserInput();
            _input.UiNavigation1.Enable();
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

        private void Update()
        {
            if (!isMoving)
            {
                StartCoroutine(moveGames());
                
            }
        }

        IEnumerator moveGames()
        {
            Debug.Log(_selectedGame);
            isMoving = true;
            switchCardState();
            int value = -Mathf.RoundToInt(_input.UiNavigation1.move.ReadValue<Vector2>().x);
            transform.parent.localPosition += new Vector3(140 * value, 0,0);
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
}