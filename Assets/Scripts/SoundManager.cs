using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    // da rifare fatto all'ultimo momento 

   [SerializeField] private AudioSource audioSource;


    public AudioClip /*DoorOpening,*/ /*PuppetDialogue,*/ WrongPiece, PlacedPiece, PickUpPiece, Buttom;

    //public static Action OnPlayMusicDoorOpening;
    //public static Action OnPlayMusicPuppetDialogue;
    public static Action OnPlayMusicWrongPiece;
    public static Action OnPlayMusicPlacedPiece;
    public static Action OnPlayMusicPickUpPiece;
    public static Action OnPlayMusicButtom;


    private void OnEnable()
    {
        //OnPlayMusicDoorOpening += PlayClipDoorOpening;
        //OnPlayMusicPuppetDialogue += PlayClipPuppetDialogue;
        OnPlayMusicWrongPiece += PlayClipWrongPiece;
        OnPlayMusicPlacedPiece += PlayClipRightPiece;
        OnPlayMusicPickUpPiece += PlayClipPickUpPiece;
        OnPlayMusicButtom += PlayClipButtom;
    }


    //private void PlayClipDoorOpening()
    //{
    //    audioSource.clip = DoorOpening;
    //    audioSource.Play();
    //}

    //private void PlayClipPuppetDialogue()
    //{
    //    audioSource.clip = PuppetDialogue;
    //    audioSource.Play();
    //}

    private void PlayClipWrongPiece()
    {
        audioSource.clip = WrongPiece;
        audioSource.Play();
    }

    private void PlayClipRightPiece()
    {
        audioSource.clip = PlacedPiece;
        audioSource.Play();
    }

    private void PlayClipPickUpPiece()
    {
        audioSource.clip = PickUpPiece;
        audioSource.Play();
    }

    private void PlayClipButtom()
    {
        audioSource.clip = Buttom;
        audioSource.Play();
    }


    private void OnDisable()
    {
        //OnPlayMusicDoorOpening -= PlayClipDoorOpening;
        //OnPlayMusicPuppetDialogue -= PlayClipPuppetDialogue;
        OnPlayMusicWrongPiece -= PlayClipWrongPiece;
        OnPlayMusicPlacedPiece -= PlayClipRightPiece;
        OnPlayMusicPickUpPiece -= PlayClipPickUpPiece;
        OnPlayMusicButtom -= PlayClipButtom;
    }
}
