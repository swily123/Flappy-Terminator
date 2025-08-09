using UnityEngine;
using UnityEngine.UI;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup _windowGroup;
    [SerializeField] protected Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    public abstract void OnButtonClick();

    public void Open()
    {
        _windowGroup.alpha = 1f;
        _windowGroup.blocksRaycasts = true;
        _button.interactable = true;
    }

    public void Close()
    {
        _windowGroup.alpha = 0f;
        _windowGroup.blocksRaycasts = false;
        _button.interactable = false;
    }
}
