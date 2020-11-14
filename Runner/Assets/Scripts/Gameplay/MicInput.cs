using System;
using UnityEngine;

public class MicInput : MonoBehaviour
{
    private const float measureInterval = 0.1f;

    [SerializeField] private float inputThreshold = 0.25f;
    [SerializeField] private AudioSource audioSource;

    public static event Action MicInputEvent;

    private float time = 0;

    private void Start()
    {
        var devices = Microphone.devices;

        if (devices.Length > 0)
        {
            audioSource.clip = Microphone.Start(Microphone.devices[0], true, 10, 44100);
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("MicInput: No Microphone Available!");
        }
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time > measureInterval)
        {
            time = 0;
            var samples = new float[1024];
            audioSource.GetOutputData(samples, 0);

            var maxAmplitude = 0f;
            foreach (var sample in samples)
                if (sample > maxAmplitude)
                    maxAmplitude = sample;

            if (maxAmplitude > inputThreshold)
            {
                MicInputEvent?.Invoke();
                Debug.LogWarning($"PV-MicInputEvent, maxAmplitude: {maxAmplitude}");
            }
        }
    }
}
