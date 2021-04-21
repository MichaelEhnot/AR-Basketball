using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using TextSpeech;

public class VoiceController : MonoBehaviour
{
    const string LANG_CODE = "en-US";

    private AudioSource audio;

    private void Start()
    {
        Setup(LANG_CODE);

        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;
        SpeechToText.instance.onPartialResultsCallback = OnPartialSpeechResult;

        CheckPermission();

        audio = gameObject.GetComponent<AudioSource>();
    }

    void CheckPermission()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
    }

    #region Text to Speech

    public void StartSpeaking(string message)
    {
        TextToSpeech.instance.StartSpeak(message);
    }

    public void StopSpeaking()
    {
        TextToSpeech.instance.StopSpeak();
    }

    #endregion

    #region Speech to Text

    public void StartListening()
    {
        SpeechToText.instance.StartRecording();
    }

    public void StopListening()
    {
        SpeechToText.instance.StopRecording();
    }

    void OnFinalSpeechResult(string result)
    {
        
    }

    void OnPartialSpeechResult(string message)
    {
        StopListening();
        if(message == "fans")
        {
            audio.Play();
        }
    }

    #endregion

    void Setup(string code)
    {
        TextToSpeech.instance.Setting(code, 1, 1);

    }
}
