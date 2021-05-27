using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;


namespace MWSoundED.Classes
{

    public static class Mci
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendString")]
        public static extern int SendString(
                string command,
                StringBuilder returnValue,
                int returnLength,
                int winHandle);

        [DllImport("winmm.dll", EntryPoint = "mciGetErrorString")]
        public static extern uint GetErrorString(
                int dwError,
                StringBuilder lpstrBuffer,
                uint wLength);

        [DllImport("winmm.dll", EntryPoint = "mciExecute")]
        public static extern int Execute(string command);
    }

    public class MciAudioPlayer
    {
        private string _alias;

        private int _pauseDuration;

        private DateTime _pauseTime;
 
        private bool _isPaused;

        public float Volume { get; set; }

        public async Task PlayAsync(string source, int startPos = 0, int endPos = -1)
        {
            if (_isPaused)
            {
                Resume();
                return;
            }

            Stop();

            _alias = Guid.NewGuid().ToString();

            var mciCommand = string.Format("open \"{0}\" type waveaudio alias {1}", source, _alias);
            Mci.SendString(mciCommand, null, 0, 0);

            mciCommand = string.Format("set {0} time format samples", _alias);
            Mci.SendString(mciCommand, null, 0, 0);

            var durationBuffer = new StringBuilder(255);
            mciCommand = string.Format("status {0} length", _alias);
            Mci.SendString(mciCommand, durationBuffer, 255, 0);
            var duration = int.Parse(durationBuffer.ToString());

            var samplingRateBuffer = new StringBuilder(255);
            mciCommand = string.Format("status {0} samplespersec", _alias);
            Mci.SendString(mciCommand, samplingRateBuffer, 255, 0);
            var samplingRate = int.Parse(samplingRateBuffer.ToString());

            mciCommand = string.Format("play {2} from {0} to {1} notify", startPos, endPos, _alias);
            mciCommand = mciCommand.Replace(" to -1", "");
            Mci.SendString(mciCommand, null, 0, 0);

            var currentAlias = _alias;

            await Task.Delay((int)(duration * 1000.0 / samplingRate));

            while (_isPaused || _pauseDuration > 0)
            {
                if (_isPaused)
                {
                    await Task.Delay(1000);
                }

                if (_pauseDuration > 0)
                {
                    await Task.Delay(_pauseDuration);

                    _pauseDuration = 0;
                }
            }

            if (currentAlias == _alias)
            {
                Stop();
            }
        }

        public void Pause()
        {
            if (_alias == null)
            {
                return;
            }

            var mciCommand = string.Format("pause {0}", _alias);
            Mci.SendString(mciCommand, null, 0, 0);

            _pauseTime = DateTime.Now;
            _isPaused = true;
        }

        public void Resume()
        {
            if (_alias == null || !_isPaused)
            {
                return;
            }

            var mciCommand = string.Format("resume {0}", _alias);
            Mci.SendString(mciCommand, null, 0, 0);

            var pause = DateTime.Now - _pauseTime;

            _pauseDuration += pause.Duration().Seconds * 1000 + pause.Duration().Milliseconds;
            _isPaused = false;
        }

        public void Stop()
        {
            if (_alias == null)
            {
                return;
            }

            if (_isPaused)
            {
                Resume();
            }

            var mciCommand = string.Format("stop {0}", _alias);
            Mci.SendString(mciCommand, null, 0, 0);

            mciCommand = string.Format("close {0}", _alias);
            Mci.SendString(mciCommand, null, 0, 0);

            _alias = null;
        }
    }

}
