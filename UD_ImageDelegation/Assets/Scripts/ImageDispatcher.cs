using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Force this gameObject to have "Button" component
[RequireComponent(typeof(Button))]
public class ImageDispatcher : MonoBehaviour
{
    /// <summary>
    /// Sprite that is dispatched to listeners on button press.
    /// </summary>
    public Sprite Sprite;

    /// <summary>
    /// List of Listener functions that are invoked when button is pressed.
    /// </summary>
    public UnityEvent<Sprite> Listener;

    /// <summary>
    /// Button reference to send dispatch.
    /// </summary>
    private Button _Button;

    /// <summary>
    /// Used to hold anonymous method.
    /// </summary>
    private UnityAction hiddenInvokeAction;

    private void Awake()
    {
        // Find button reference, this component forces a button to exist on the gameObject.
        _Button = this.GetComponent<Button>();

        // Construct anonymous method into symbol so it can be removed later.
        hiddenInvokeAction = () => Listener.Invoke(Sprite);
    }

    private void Start()
    {
        // Add action to button on first frame.
        _Button.onClick.AddListener(hiddenInvokeAction);
    }

    private void OnDestroy()
    {
        // Remove action to button on last frame.
        _Button.onClick.RemoveListener(hiddenInvokeAction);
    }
}