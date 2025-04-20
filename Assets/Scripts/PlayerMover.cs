using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    private float _moveStep = 0.1f;

    private void OnEnable()
    {
        _inputReader.HorizontalInputReading += Rotate;
        _inputReader.VerticalInputReading += Move;
    }

    private void OnDisable()
    {
        _inputReader.HorizontalInputReading -= Rotate;
        _inputReader.VerticalInputReading -= Move;
    }

    private void Move(float direction)
    {
        float distance = _moveStep * _moveSpeed * direction;
        transform.Translate(Vector3.forward * distance * Time.deltaTime);
    }

    private void Rotate(float rotation)
    {
        transform.Rotate(rotation * _rotateSpeed * Time.deltaTime * Vector3.up);
    }
}
