using UnityEngine;
public class MusicScript : MonoBehaviour
{
    private bool IsPlaying;
    public float offset = 1.5f;
    void Awake()
    {
        IsPlaying = false;
        audio.Stop();
    }

    public void StartPlaying()
    {
        if (IsPlaying) return;
        audio.time = offset;
        audio.Play();
        IsPlaying = true;
    }

    public void StopPlaying()
    {
        if (!IsPlaying) return;

        audio.Stop();
        IsPlaying = false;
    }
}