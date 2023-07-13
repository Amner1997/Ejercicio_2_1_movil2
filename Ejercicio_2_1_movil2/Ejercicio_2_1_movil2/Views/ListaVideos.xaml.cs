
using Ejercicio_2_1_movil2.Models;
using System.Collections.Generic;
using System.IO;
using Xam.Forms.VideoPlayer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio_2_1_movil2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaVideos : ContentPage
    {
        private string videoPath;
        private List<VideoItem> videoList;

        public ListaVideos()
        {
            InitializeComponent();
            videoList = new List<VideoItem>();
            // Carga los videos guardados en la lista
            LoadVideoList();
        }

        private void LoadVideoList()
        {
            // Obtén los archivos de video guardados en la ubicación deseada
            var videoFiles = Directory.GetFiles("/data/user/0/com.companyname.ejercicio_2_1_movil2/cache", "*.mp4");

            // Crea un objeto VideoItem para cada archivo de video y agrégalo a la lista
            foreach (var videoFile in videoFiles)
            {
                var videoItem = new VideoItem
                {
                    Title = Path.GetFileNameWithoutExtension(videoFile),
                    FilePath = videoFile
                };
                videoList.Add(videoItem);
            }

            // Asigna la lista al ListView
            listView.ItemsSource = videoList;
        }

        private void OnVideoSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // Obtén el video seleccionado de la lista
            var selectedVideo = (VideoItem)e.SelectedItem;

            // Reproduce el video seleccionado en el reproductor de video
            videoPlayer.Source = VideoSource.FromFile(selectedVideo.FilePath);
            videoPlayer.Play();
        }
    }
}