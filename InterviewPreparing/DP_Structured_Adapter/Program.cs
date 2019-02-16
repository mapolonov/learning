using System.Media;

namespace DP_Structured_Adapter
{
    /// <summary>Simple audio player interface.</summary>
    public interface IAudioPlayer
    {
        /// <summary>Loads the audio file.</summary>
        void Load(string file);

        /// <summary>Plays the audio file.</summary>
        void Play();
    }

    /// <summary>Simple audio player interface.</summary>
    public class SoundPlayerAdapter : IAudioPlayer
    {
        /// <summary>Adaptee object.</summary>
        private readonly SoundPlayer _lazyPlayer = new SoundPlayer();

        /// <summary>Loads the audio file.</summary>
        public void Load(string file)
        {
            this._lazyPlayer.SoundLocation = file;
            this._lazyPlayer.Load();
        }

        /// <summary>Plays the audio file.</summary>
        public void Play()
        {
            this._lazyPlayer.Play();
        }
    }


    class AdapterTry
    {
        private IAudioPlayer _player = new SoundPlayerAdapter();

        public void NotifyUser(int messageCode)
        {
            string wavFile = string.Empty;

            /* Skipped */

            // play the audio file
            if (!string.IsNullOrEmpty(wavFile))
            {
                this._player.Load(wavFile);
                this._player.Play();
            }
        }

        static void Main(string[] args)
        {


        }
    }
}
