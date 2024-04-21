using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource m_BonusAudioSource;
    [SerializeField] private AudioSource m_CompAudioSource;
    [SerializeField] private AudioSource m_ElectricAudioSource;
    [SerializeField] private AudioSource m_HitAudioSource;
    [SerializeField] private AudioSource m_LevelAudioSource;
    [SerializeField] private AudioSource m_LoseAudioSource;
    [SerializeField] private AudioSource m_RepairAudioSource;
    [SerializeField] private AudioSource m_ScoreAudioSource;
    [SerializeField] private AudioSource m_TransformerAudioSource;
    [SerializeField] private AudioSource m_WinAudioSource;

    public void PlayBonusSound()
    {
        if (m_BonusAudioSource != null)
        {
            m_BonusAudioSource.Play();
        }
    }

    public void PlayCompSound()
    {
        if (m_CompAudioSource != null)
        {
            m_CompAudioSource.Play();
        }
    }

    public void PlayElectricSound()
    {
        if (m_ElectricAudioSource != null)
        {
            m_ElectricAudioSource.Play();
        }
    }

    public void PlayHitSound()
    {
        if (m_HitAudioSource != null)
        {
            m_HitAudioSource.Play();
        }
    }

    public void PlayLevelSound()
    {
        if (m_LevelAudioSource != null)
        {
            m_LevelAudioSource.Play();
        }
    }

    public void PlayLoseSound()
    {
        if (m_LoseAudioSource != null)
        {
            m_LoseAudioSource.Play();
        }
    }

    public void PlayRepairSound()
    {
        if (m_RepairAudioSource != null)
        {
            m_RepairAudioSource.Play();
        }
    }

    public void PlayScoreSound()
    {
        if (m_ScoreAudioSource != null)
        {
            m_ScoreAudioSource.Play();
        }
    }

    public void PlayTransformerSound()
    {
        if (m_TransformerAudioSource != null)
        {
            m_TransformerAudioSource.Play();
        }
    }

    public void PlayWinSound()
    {
        if (m_WinAudioSource != null)
        {
            m_WinAudioSource.Play();
        }
    }
}
