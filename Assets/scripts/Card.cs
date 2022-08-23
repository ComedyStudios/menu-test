using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Card: MonoBehaviour
    {
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
    }
}