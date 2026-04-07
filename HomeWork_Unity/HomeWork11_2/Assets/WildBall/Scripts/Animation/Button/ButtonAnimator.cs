using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAnimator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Animator _animator;

    public Button button;

    public AudioMixerManager mixer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        _animator.SetTrigger("Highlighted");
        _animator.SetTrigger("Pressed");
        
        mixer.PlayButtonClick();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _animator.SetTrigger("Disabled");
        _animator.SetTrigger("Selected");
        
        mixer.StopButtonClick();
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
