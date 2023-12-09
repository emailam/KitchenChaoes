using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerSounds : MonoBehaviour
{
    private Player player;
    private float footstepTimer;
    private float footsteptimerMax = .1f;
    private float HurtingTimer;
    private float HurtingTimerMax  = .5f;

    private void Awake()
    {
        player = GetComponent<Player>();
    }
    private void Update()
    {
        footstepTimer -= Time.deltaTime;
        if (footstepTimer < 0f)
        {
            footstepTimer = footsteptimerMax;
            if (player.IsWalking())
            {
                float volume = 1f;
                SoundManager.Instance.PlayFootstepsSound(player.transform.position, volume);
            }
        }
        HurtingTimer -= Time.deltaTime;
        if (HurtingTimer < 0f)
        {
            HurtingTimer = HurtingTimerMax;
            if (player.IsHurted())
            {
                float volume = 1f;
                SoundManager.Instance.PlayHurtingSound(player.transform.position, volume);
            }
        }
    }
}
