using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAnimator : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private MenuData _menuData;
    [SerializeField] private Button _button;
    [SerializeField] private AudioMixerManager _mixer;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    private void OnEnable()
    {
        if (_menuData.isAnimationFinished)
        {
            _animator.Play("Button_Idle_State", 0, 1f);
            _animator.SetTrigger("Disabled");
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _menuData.isAnimationFinished = true;
        _animator.SetTrigger("Highlighted");
        //_animator.SetTrigger("Pressed");
        
        _mixer.PlayButtonClick();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _menuData.isAnimationFinished = false;
        _animator.SetTrigger("Disabled");
        //_animator.SetTrigger("Selected");
        
        //_mixer.StopButtonClick();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ResetToDefaultState();
    }

    private void ResetToDefaultState()
    {
      _button.transform.localScale = Vector3.one;
        _menuData.isAnimationFinished = false;
    }
}
