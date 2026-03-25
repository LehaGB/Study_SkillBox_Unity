using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Animations;

public class ButtonAnimator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        _animator.SetTrigger("PointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _animator.SetTrigger("PointerExit");
    }
}
