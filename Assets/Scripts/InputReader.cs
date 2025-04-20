using UnityEngine;
using UnityEngine.Events;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    public event UnityAction<float> VerticalInputReading;
    public event UnityAction<float> HorizontalInputReading;

    private void Update()
    {
        float direction = Input.GetAxis(Vertical);
        float rotation = Input.GetAxis(Horizontal);

        if (direction != 0)
            VerticalInputReading.Invoke(direction);

        if (rotation != 0)
            HorizontalInputReading.Invoke(rotation);
    }
}
