using System;
using Xamarin.Forms;
using Plugin.Media.Abstractions;
using Plugin.Media;
using Xam.Forms.VideoPlayer;
using Xamarin.Essentials;
using System.IO;

namespace Ejercicio_2_1_movil2
{
    
    public partial class MainPage : ContentPage
    {
        string videoPath;
        Plugin.Media.Abstractions.MediaFile photo = null;

        public MainPage()
        {
            InitializeComponent();

        }

          private async void OnRecordButtonClicked(object sender, EventArgs e)
          {
              if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakeVideoSupported)
              {
                  await DisplayAlert("Error", "No se puede acceder a la cámara", "OK");
                  return;
              }

              var mediaOptions = new StoreVideoOptions
              {
                  SaveToAlbum = false,
                  Quality = VideoQuality.Medium
              };

              var videoFile = await CrossMedia.Current.TakeVideoAsync(mediaOptions);

              if (videoFile == null)
                  return;

              videoPath = videoFile.Path;
              videoPlayer.Source = new FileVideoSource { File = videoPath };
              videoPlayer.Play();
          }

       /* private async void btnVideo_Clicked(object sender, EventArgs e)
        {
            var videoOptions = new StoreVideoOptions
            {
                Directory = "MYAPP",
                Name = "Video.mp4",
                SaveToAlbum = true
            };

            var video = await CrossMedia.Current.TakeVideoAsync(videoOptions);

            if (video != null)
            {
                videoPlayer.Source = VideoSource.FromFile(video.Path);
                videoPlayer.Play();
            }
        }*/

       

          private async void OnSaveButtonClicked(object sender, EventArgs e)
          {
              if (string.IsNullOrEmpty(videoPath))
              {
                  await DisplayAlert("Error", "No se ha grabado ningún video", "OK");
                  return;
              }

              try
              {
                  // Generar un nuevo nombre de archivo único basado en la fecha y hora actual
                  var newVideoFileName = "video_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".mp4";

                  // Obtener una ruta de archivo para guardar el video en el almacenamiento
                  var saveVideoPath = Path.Combine(FileSystem.CacheDirectory, newVideoFileName);

                  // Copiar el archivo de video a la nueva ubicación de almacenamiento
                  File.Copy(videoPath, saveVideoPath);

                  await DisplayAlert("Éxito", "Video guardado correctamente", "OK");
                 await DisplayAlert("Éxito", "Se guardo en la siguiente ruta" +saveVideoPath, "OK");
            }
              catch (Exception ex)
              {
                  await DisplayAlert("Error", "No se pudo guardar el video: " + ex.Message, "OK");
              }
          }

        


        /* private void OnStopButtonClicked(object sender, EventArgs e)
         {
             if (!string.IsNullOrEmpty(videoPath))
             {
                 videoPlayer.Stop();
                 videoPath = string.Empty;
             }
         }*/
    }
}
