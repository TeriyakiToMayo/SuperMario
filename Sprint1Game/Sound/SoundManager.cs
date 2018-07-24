using Sprint1Game.Camera;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Sprint1Game.Sound
{
    public class SoundManager
    {

        private SoundEffect marioDyingSound;
        private SoundEffect coinSound;
        private SoundEffect oneUpSound;
        private SoundEffect powerUpAppearsSound;
        private SoundEffect powerUpSound;
        private SoundEffect gameOverSound;
        private SoundEffect brickSmashSound;
        private SoundEffect stageClearSound;
        private SoundEffect flagPoleSound;
        private SoundEffect bumpSound;
        private SoundEffect fireballSound;
        private SoundEffect kickSound;
        private SoundEffect stompSound;
        private SoundEffect pauseSound;
        private SoundEffect pipeSound;
        private SoundEffect smallJumpSound;
        private SoundEffect superJumpSound;
        private SoundEffect warningSound;
        private Song overworldSong;
        private Song underworldSong;
        private Song hurryOverworldSong;
        private Song hurryUnderworldSong;
        private Song starSong;

        private static SoundManager instance = new SoundManager();

        public static SoundManager Instance
        {
            get
            {
                return instance;
            }
        }

        private SoundManager()
        {

        }

        public void LoadAllSounds(ContentManager content)
        {
            marioDyingSound = content.Load<SoundEffect>("smb_mariodie");
            coinSound = content.Load<SoundEffect>("smb_coin");
            oneUpSound = content.Load<SoundEffect>("smb_1-up");
            powerUpAppearsSound = content.Load<SoundEffect>("smb_powerup_appears");
            powerUpSound = content.Load<SoundEffect>("smb_powerup");
            gameOverSound = content.Load<SoundEffect>("smb_gameover");
            brickSmashSound = content.Load<SoundEffect>("smb_breakblock");
            stageClearSound = content.Load<SoundEffect>("smb_stage_clear");
            flagPoleSound = content.Load<SoundEffect>("smb_flagpole");
            bumpSound = content.Load<SoundEffect>("smb_bump");
            fireballSound = content.Load<SoundEffect>("smb_fireball");
            kickSound = content.Load<SoundEffect>("smb_kick");
            stompSound = content.Load<SoundEffect>("smb_stomp");
            pauseSound = content.Load<SoundEffect>("smb_pause");
            pipeSound = content.Load<SoundEffect>("smb_pipe");
            smallJumpSound = content.Load<SoundEffect>("smb_jump-small");
            superJumpSound = content.Load<SoundEffect>("smb_jump-super");
            warningSound = content.Load<SoundEffect>("smb_warning");
            overworldSong = content.Load<Song>("01-main-theme-overworld");
            underworldSong = content.Load<Song>("02-underworld");
            hurryOverworldSong = content.Load<Song>("18-hurry-overworld-");
            hurryUnderworldSong = content.Load<Song>("14-hurry-underground-");
            starSong = content.Load<Song>("05-starman");

        }
        public void PlayMarioDyingSound()
        {
            marioDyingSound.Play();
        }
        public void PlayCoinSound()
        {
            coinSound.Play();
        }
        public void Play1UpSound()
        {
            oneUpSound.Play();
        }
        public void PlayPowerUpAppearsSound()
        {
            powerUpAppearsSound.Play();
        }
        public void PlayPowerUpSound()
        {
            powerUpSound.Play();
        }
        public void PlayGameOverSound()
        {
            gameOverSound.Play();
        }
        public void PlayBrickSmashSound()
        {
            brickSmashSound.Play();
        }
        public void PlayStageClearSound()
        {
            stageClearSound.Play();
        }
        public void PlayFlagPoleSound()
        {
            flagPoleSound.Play();
        }
        public void PlayBumpSound()
        {
            bumpSound.Play();
        }
        public void PlayFireballSound()
        {
            fireballSound.Play();
        }
        public void PlayKickSound()
        {
            kickSound.Play();
        }
        public void PlayStompSound()
        {
            stompSound.Play();
        }
        public void PlayPipeSound()
        {
            pipeSound.Play();
        }
        public void PlaySmallJumpSound()
        {
            smallJumpSound.Play();
        }
        public void PlaySuperJumpSound()
        {
            superJumpSound.Play();
        }
        public void PlayOverWorldSong()
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(overworldSong);
            MediaPlayer.IsRepeating = true;
        }
        public void PauseSound()
        {
            MediaPlayer.Pause();
            pauseSound.Play();
        }
        public void ResumeSound()
        {
            MediaPlayer.Resume();
            this.ToString();
        }
        public void StopAllSound()
        {
            MediaPlayer.Stop();
            this.ToString();
        }
        public void PlayUnderworldSong()
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(underworldSong);
            MediaPlayer.IsRepeating = true;
        }
        public void PlayWarningSound()
        {
            warningSound.Play();
        }
        public void PlayHurryOverworldSong()
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(hurryOverworldSong);
            MediaPlayer.IsRepeating = true;
        }
        public void PlayHurryUnderworldSong()
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(hurryUnderworldSong);
            MediaPlayer.MoveNext();
            MediaPlayer.IsRepeating = true;
        }
        public void PlayStarSong()
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(starSong);
        }
    }
}
