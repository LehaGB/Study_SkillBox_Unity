using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAnimator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private AudioSource _audioSource;
    private Animator _animator;
    private bool _isPointerInside = false;

    public Button button;

    public AudioMixerManager mixer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        button = GetComponent<Button>();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        _animator.SetTrigger("Highlighted");
        _isPointerInside = true;
        mixer.PlayButtonClick();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _animator.SetTrigger("Disabled");
        _isPointerInside = false;
        mixer.StopButtonClick();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ResetToDefaultState();
    }

    private void ResetToDefaultState()
    {
        _animator.SetTrigger("Normal");
    }
}
