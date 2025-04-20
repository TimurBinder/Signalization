using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SignalizationPlayer : MonoBehaviour
{
    [SerializeField] private Signalization _signalization;
    [SerializeField] private float _changeVolumeSpeed = 0.05f;

    private IEnumerator _changeVolumeCoroutine;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out var player))
            Play();
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent<Player>(out var player))
            Stop();
    }

    private void Play()
    {
        _signalization.Audio.Play();

        if (_changeVolumeCoroutine != null)
            StopCoroutine(_changeVolumeCoroutine);

        float maxValue = 1f;
        _changeVolumeCoroutine = ChangeVolume(maxValue);
        StartCoroutine(_changeVolumeCoroutine);
    }

    private void Stop()
    {
        if (_changeVolumeCoroutine != null)
            StopCoroutine(_changeVolumeCoroutine);

        float minValue = 0f;
        _changeVolumeCoroutine = ChangeVolume(minValue);
        StartCoroutine(_changeVolumeCoroutine);

        if (_signalization.Audio.volume == 0)
            _signalization.Audio.Stop();
    }

    private IEnumerator ChangeVolume(float volume)
    {
        while (_signalization.Audio.volume != volume)
        {
            _signalization.Audio.volume = Mathf.MoveTowards(_signalization.Audio.volume, volume, _changeVolumeSpeed);
            yield return null;
        }
    }
}
