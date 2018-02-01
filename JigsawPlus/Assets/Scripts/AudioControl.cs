using UnityEngine;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{

    public static AudioControl Instance;

    [SerializeField] private AudioClip clickAudioClip;
    [SerializeField] private AudioClip getAudioClip;
    [SerializeField] private AudioClip overAudioClip;
    [SerializeField] private AudioClip placeBlockAudioClip;
    [SerializeField] private AudioClip removeLineAudioClip;

    [SerializeField]
    private Image _audioImage;
    [SerializeField]
    private Sprite _soundOnSprite;
    [SerializeField]
    private Sprite _soundOffSprite;

    private bool _soundSwitchOn;
    public bool SoundSwitchOn
    {
        get
        {
            if (!PlayerPrefs.HasKey("SoundSwitchOn"))
                return true;
            else
            {
                return PlayerPrefs.GetInt("SoundSwitchOn") == 1;
            }
        }
        set
        {
            _soundSwitchOn = value;
            PlayerPrefs.SetInt("SoundSwitchOn", _soundSwitchOn ? 1 : 0);
        }
    }

    [SerializeField]
    private AudioSource musicAudioSource;
    [SerializeField]
    private AudioSource soundAudioSource;

    
    // Use this for initialization
    void Start ()
	{
	    Instance = this;

	    SoundSwitchOn = SoundSwitchOn;
	    _audioImage.GetComponent<Image>().sprite = SoundSwitchOn ? _soundOnSprite : _soundOffSprite;

        if (SoundSwitchOn)
            musicAudioSource.Play();

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnAudioButtonClicked()
    {
        if (!SoundSwitchOn)
        {
            soundAudioSource.clip = clickAudioClip;
            soundAudioSource.Play();
            if (!musicAudioSource.isPlaying)
                musicAudioSource.Play();
        }
        else
        {
            if (musicAudioSource.isPlaying)
                musicAudioSource.Stop();
        }

        SoundSwitchOn = ! SoundSwitchOn;
        _audioImage.GetComponent<Image>().sprite = SoundSwitchOn ? _soundOnSprite : _soundOffSprite;

    }

    public void PlayClickAudio()
    {
        if (SoundSwitchOn)
        {
            soundAudioSource.clip = clickAudioClip;
            soundAudioSource.Play();
        }

    }

    public void PlayGetAudio()
    {
        if (SoundSwitchOn)
        {
            soundAudioSource.clip = getAudioClip;
            soundAudioSource.Play();
        }
    }

    public void PlayGameOverAudio()
    {
        if (SoundSwitchOn)
        {
            soundAudioSource.clip = overAudioClip;
            soundAudioSource.Play();
        }
    }

    public void PlayPlaceBlockAudio()
    {
        if (SoundSwitchOn)
        {
            soundAudioSource.clip = placeBlockAudioClip;
            soundAudioSource.Play();
        }
    }

    public void PlayRemoveLinesAudio()
    {
        if (SoundSwitchOn)
        {
            soundAudioSource.clip = removeLineAudioClip;
            soundAudioSource.Play();
        }
    }
}
