using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAnimator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Animator _animator;
    private bool _isPointerInside = false;

    public Button button;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        button = GetComponent<Button>();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        _animator.SetTrigger("Highlighted");
        _isPointerInside = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _animator.SetTrigger("Disabled");
        _isPointerInside = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ResetToDefaultState();
    }

    private void ResetToDefaultState()
    {
        button.transform.localScale = Vector3.one;
    }
}
