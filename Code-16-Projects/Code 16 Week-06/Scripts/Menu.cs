using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    AudioSource source;
    public AudioMixer mixer;
    public Slider slider;
    public GameObject[] sections;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        SetMusic();
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void LoadScene(int num)
    {
        SceneManager.LoadScene(num);
    }
    public void OpenMenu(int num)
    {
        for (int i = 0; i < sections.Length; i++)
        {
            sections[i].SetActive(false);
        }

        sections[num].SetActive(true);
    }
    public void Sound(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
    }
    public void SetMusic()
    {
        mixer.SetFloat("Music", Mathf.Log10(slider.value) * 20);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
