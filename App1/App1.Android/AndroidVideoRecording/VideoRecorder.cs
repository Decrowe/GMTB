using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;


namespace App1.Droid.AndroidVideoRecording
{
    class VideoRecorder
    {
        public void startRecord(SurfaceView surfaceView)
        {

            Device.BeginInvokeOnMainThread(() => {

                string path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/test.mp4";
                var recorder = new MediaRecorder();

                //If you want to rotate the video screen, you can use following code
                //Camera camera = Camera.Open();
                //Camera.Parameters parameters = camera.GetParameters();

                //parameters.SetPreviewSize(640, 480);
                //parameters.SetPictureSize(640, 480);
                //camera.SetParameters(parameters);
                //camera.SetDisplayOrientation(90);
                //camera.Unlock();
                //recorder.SetCamera(camera); 

                recorder.SetVideoSource(VideoSource.Camera);
                recorder.SetAudioSource(AudioSource.Mic);
                recorder.SetOutputFormat(OutputFormat.Default);
                recorder.SetVideoEncoder(VideoEncoder.Default);
                recorder.SetAudioEncoder(AudioEncoder.Default);
                recorder.SetOutputFile(path);
                recorder.SetPreviewDisplay(surfaceView.Holder.Surface);
                recorder.Prepare();
                recorder.Start();

            });

        }
    }
}       