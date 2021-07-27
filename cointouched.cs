using UnityEngine;

public class touchscript : MonoBehaviour
{
    const int MAXSCORE = 200;
    private int score;
    private ParticleSystem _ps;
    private AudioSource _audioSource;
    private AudioClip _coinTouchedClip;

    void Start()
    {
        if(!_ps)
            _ps = GetComponent<ParticleSystem>();
        
        if(!_audioSource)
            _audioSource = FindObjectOfType<AudioSource>();
        
        if(!_coinTouchedClip)
            _coinTouchedClip = (AudioClip)Resources.Load("...", typeof(AudioClip));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("touch"))
        {
            CoinTouched();
        }
    }

    private void CoinTouched()
    {
        IncreaseScore(10);
        EnableEffectsCoinTouched();
    }

    private void IncreaseScore(int points)
    {
        score += points;
        score = score > MAXSCORE ? MAXSCORE : score;
    }

    private void EnableEffectsCoinTouched()
    {
        if (_ps)
            _ps.Play();

        if (_audioSource && _coinTouchedClip)
        {
            _audioSource.clip = _coinTouchedClip;
            _audioSource.Play();
        }
    }
}
