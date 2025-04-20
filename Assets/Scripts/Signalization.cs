using UnityEngine;

public class Signalization : MonoBehaviour
{
    public AudioSource Audio { get; private set; }

    private void Awake()
    {
        Audio = GetComponent<AudioSource>();
        Audio.volume = 0;
        Audio.loop = true;
    }
}
