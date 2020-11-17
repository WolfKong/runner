using System;
using UnityEngine;

public class MicInput : MonoBehaviour
{
    private const float measureInterval = 0.1f;
    private const int sampleWindow = 128;

    [SerializeField] private FloatVariable inputThreshold;

    public static event Action MicInputEvent;

    private float time = 0;
    private string deviceName;
    private bool initialized;
    private AudioClip audioClip;

    private void OnEnable() => StartMicrophone();

    private void OnDisable() => StopMicrophone();
    private void OnDestroy() => StopMicrophone();

    private void StartMicrophone()
    {
        var devices = Microphone.devices;

        if (devices.Length > 0)
        {
            deviceName = Microphone.devices[0];
            audioClip = Microphone.Start(deviceName, true, 10, 44100);
            initialized = true;
        }
        else
        {
            Debug.LogError("MicInput: No Microphone Available!");
            Destroy(this);
        }
    }

    private void StopMicrophone()
    {
        if (!string.IsNullOrEmpty(deviceName))
        {
            Microphone.End(deviceName);
            initialized = false;
        }
    }

    private void Update()
    {
        time += Time.deltaTime;

        if (time > measureInterval)
        {
            time = 0;
            MeasureInput();
        }
    }

    private void MeasureInput()
    {
        int micPosition = Microphone.GetPosition(deviceName) - (sampleWindow + 1);
        if (micPosition < 0)
            return;

        var samples = new float[sampleWindow];
        audioClip.GetData(samples, micPosition);

        var maxAmplitude = 0f;
        foreach (var sample in samples)
        {
            if (sample * sample > maxAmplitude)
                maxAmplitude = sample * sample;
        }

        var sqrt = Mathf.Sqrt(maxAmplitude);
        if (Mathf.Sqrt(maxAmplitude) > inputThreshold.Value)
        {
            MicInputEvent?.Invoke();
            Debug.LogWarning($"PV-MicInputEvent, maxAmplitude: {maxAmplitude}, sqrt {sqrt}");
        }
        Debug.Log($"PV-maxAmplitude: {maxAmplitude}, sqrt {sqrt}");
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            if (!initialized)
                StartMicrophone();
        }
        else
        {
            StopMicrophone();
        }
    }
}
