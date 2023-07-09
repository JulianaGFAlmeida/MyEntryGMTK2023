using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStatusManager : MonoBehaviour
{
    [SerializeField]
    private Text winner;
    [SerializeField]
    private GameObject  restartButton;
    [SerializeField]
    private AudioClip gameTheme;
    [SerializeField]
    private AudioClip transformationTheme;
    [SerializeField]
    private AudioSource bgsSource;
    [SerializeField]
    private AudioSource sfxSource;
    [SerializeField]
    private AudioClip victoryAudio;

    public void StateWinner(int player){
        if( winner.text  == ""){
            winner.text =  (player == 0) ?  "BEAST WINS" : "HUNTER WINS";
            bgsSource.Stop();
            playSFX(victoryAudio);
        restartButton.SetActive(true);
        }
    }

    public void RestartGame(){
        Debug.Log("Eu rodo");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void trocarAudio(int audio){
        bgsSource.clip = (audio > 0) ? transformationTheme : gameTheme;
        bgsSource.Play();
    }

    public void playSFX(AudioClip audioClip, float time=0){
        StopAllCoroutines();
        time = (time <= 0) ? audioClip.length : time;
        StartCoroutine(sfxCoroutine(audioClip,time));
    }

    IEnumerator sfxCoroutine(AudioClip audioClip, float time){
        sfxSource.clip = audioClip;
        sfxSource.Play();
        yield return new WaitForSeconds(time);
        sfxSource.Stop();

    }
}
