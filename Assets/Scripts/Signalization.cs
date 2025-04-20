using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Signalization : MonoBehaviour
{
    [SerializeField] private float _changeVolumeSpeed = 0.1f;

    private AudioSource _audioSource;
    private bool _isPlaying = false;
    private IEnumerator _changeVolumeCoroutine;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
        _audioSource.loop = true; 
    }

    private void Update()
    {
        Debug.Log($"Signalization volume: {_audioSource.volume}");
    }

    public void Play()
    {
        if (_isPlaying)
            return;

        _isPlaying = true;
        _audioSource.Play();

        if (_changeVolumeCoroutine != null)
            StopCoroutine(_changeVolumeCoroutine);

        float maxValue = 1f;
        _changeVolumeCoroutine = ChangeVolume(maxValue);
        StartCoroutine(_changeVolumeCoroutine);
    }

    public void Stop()
    {
        if (_isPlaying == false)
            return;

        _isPlaying = false;

        if (_changeVolumeCoroutine != null)
            StopCoroutine(_changeVolumeCoroutine);

        float minValue = 0f;
        _changeVolumeCoroutine = ChangeVolume(minValue);
        StartCoroutine(_changeVolumeCoroutine);

        if (_audioSource.volume == 0)
            _audioSource.Stop();
    }

    private IEnumerator ChangeVolume(float volume)
    {
        while (_audioSource.volume != volume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, volume, _changeVolumeSpeed);
            yield return null;
        }
    }
}
