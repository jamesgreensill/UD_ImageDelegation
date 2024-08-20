using UnityEngine;
using UnityEngine.UI;

// Force this gameObject to have "Image" component
[RequireComponent(typeof(Image))]
public class ImageListener : MonoBehaviour
{
    /// <summary>
    /// Hidden reference to Image component
    /// </summary>
    private Image _Image;

    /// <summary>
    /// Event function for ImageDispatcher.
    /// </summary>
    /// <param name="texture"></param>
    public void ReceiveImage(Sprite texture)
    {
        // Lazy load Image component. the ??= operator is the same as "if (_Image == null)"
        // Only executes when _Image is null
        _Image ??= this.GetComponent<Image>();

        // Set sprite to the incoming texture.
        _Image.sprite = texture;
    }
}