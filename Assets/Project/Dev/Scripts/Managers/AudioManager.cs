using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Singleton, permite acessar de qualquer script usando:
    // AudioManager.Instance
    public static AudioManager Instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Ambience")]
    // Todos os sons de ambiente da gameplay
    [SerializeField] private AudioSource[] ambienceSources;

    // Alarme da nave
    [SerializeField] private AudioSource alarmSource;

    [Header("Playlists")]
    // Músicas menu
    [SerializeField] private AudioClip[] menuTracks;

    // Músicas gameplay
    [SerializeField] private AudioClip[] gameplayTracks;

    // Playlist goonis
    private AudioClip[] currentPlaylist;

    // a musica que tá tocando agr
    private int currentTrackIndex;

    [Header("Voiced")]
    public AudioClip[] voicedTracks;

    private void Awake()
    {
        // evitando de duplicar o audiogoon
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        // Segurança caso nenhuma playlist tenha sido definida
        if (currentPlaylist == null || currentPlaylist.Length == 0)
            return;

        // termina uma e já começa a próxima
        if (!musicSource.isPlaying)
        {
            PlayNextTrack();
        }
    }

    // ========================== MENU MUSIC ==========================

    // Ativa a playlist do menu
    public void PlayMenuMusic()
    {
        SetPlaylist(menuTracks);
    }

    // ========================== GAMEPLAY MUSIC ==========================

    // Ativa a playlist da gameplay
    public void PlayGameplayMusic()
    {
        SetPlaylist(gameplayTracks);
    }

    // ========================== PLAYLIST ==========================

    // Recebe uma playlist e começa ela do início
    private void SetPlaylist(AudioClip[] playlist)
    {
        if (playlist == null || playlist.Length == 0)
            return;

        currentPlaylist = playlist;

        currentTrackIndex = 0;

        PlayTrack(currentTrackIndex);
    }

    // Toca uma música específica da playlist
    private void PlayTrack(int index)
    {
        musicSource.Stop();

        musicSource.clip = currentPlaylist[index];

        musicSource.Play();
    }

    // Vai para a próxima música da playlist
    private void PlayNextTrack()
    {
        currentTrackIndex++;

        if (currentTrackIndex >= currentPlaylist.Length)
        {
            currentTrackIndex = 0;
        }

        PlayTrack(currentTrackIndex);
    }

    // ========================== AMBIENCE ==========================

    // Liga todos os sons de ambiente
    public void PlayAmbience()
    {
        foreach (AudioSource source in ambienceSources)
        {
            if (source != null)
                source.Play();
        }
    }

    // Para todos os sons de ambiente
    public void StopAmbience()
    {
        foreach (AudioSource source in ambienceSources)
        {
            if (source != null)
                source.Stop();
        }
    }

    // ========================== ALARM ==========================

    // Liga o alarme
    public void StartAlarm()
    {
        if (alarmSource != null)
            alarmSource.Play();
    }

    // Desliga o alarme
    public void StopAlarm()
    {
        if (alarmSource != null)
            alarmSource.Stop();
    }

    // ========================== SFX ==========================

    // Toca um efeito sonoro no volume padrão
    public void PlaySFX(AudioClip clip)
    {
        if (clip == null)
            return;

        sfxSource.PlayOneShot(clip);
    }

    // Toca um efeito sonoro com volume personalizado
    public void PlaySFX(AudioClip clip, float volume)
    {
        if (clip == null)
            return;

        sfxSource.PlayOneShot(clip, volume);
    }

    public void PlayVoice(AudioClip clip)
    {
        if (clip == null)
            return;

        sfxSource.PlayOneShot(clip);
    }
}