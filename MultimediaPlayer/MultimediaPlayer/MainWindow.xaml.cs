using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace MediaPlayerWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DispatcherTimer tiempo=new DispatcherTimer();
        
        //Declaracion de Formatos A Abrir por OpenFileDialos
        String Faudio="Archivos de Audio(mp3,wma,wav)|*.mp3;*.MP3;*.wma;*.wav";
        String fvideo = "Archivos de Video(MP4,MPG,AVI,WMV,DAT)|*mp4;*,*.mpg,*.MPG,*.MP4;*avi;*.wmv;*.DAT";
        String faudiovideo = "Archivos Multimedia(mp3,mp4,mpg)|*.mp3;*.MP3;*.mpg;*.MPG;*.wma;*.wav;*mp4;*.MP4;*avi;*.wmv;*.DAT";

        private Boolean MediaPausa= false;
        private Boolean multiselect = false;
        private String tipo_Media = "";
        private bool fullscreen = false;
        private bool repetir = false;
        private Boolean Intro = false;

        private String tipo = ""; //tipo de archivos que filtrara OpenFileDialog
        private bool mute = false;

        DispatcherTimer timer;
        bool isDragging; //Si se esta arrastrando el Slider Avance
        ListBoxItem PistaActual; //Pista Actual
        ListBoxItem PistaAnterior; //Pista Anterior
        Brush ColorPistaActual; //Color Pista que esta sonando
        
        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
           
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Tick se dispara cada segundo.
            timer.Tick += new EventHandler(timer_Tick);
            isDragging = false;
            ColorPistaActual = Brushes.Gold; //se asigna color
            btPausa.Visibility= Visibility.Collapsed;
            //Deshabilitar Controles al inicio
            BorderMediaControls.IsEnabled = false;

           //TIMER
            tiempo.Tick+=tiempo_Tick;
            tiempo.Interval = new TimeSpan(0, 0, 1);
          
        }

        int contador = 0;
        private void tiempo_Tick(object sender, EventArgs e)
        {
            contador+=1;
            if(contador==3)
            {
                BorderMediaControls.Visibility = Visibility.Collapsed;
                tiempo.Stop();
            }
        }

        //Metodos
        /// <summary>
        /// Metodo que carga Video por defeault al inciar
        /// </summary>
        private void CargarIntro()
        {
            mediacontrol.Source = new Uri(@"../../Resources/intro.mp4", UriKind.Relative);
            mediacontrol.Play();
        }
        /// <summary>
        /// Metodo para Abrir Archivos y Cargarlos en la Lista
        /// </summary>
        private void AbrirArchivos()
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Filter = tipo;
            dialogo.Multiselect = multiselect;
            dialogo.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            dialogo.Title = "Seleccione Uno o Varios Archivos";
            Nullable<bool> resultado = dialogo.ShowDialog();
            try
            {

                if (resultado == true)
                {
                    
                    Intro = false;
                    multiselect = false;
                    expandmedios.IsExpanded = false;
                    expaudio.IsExpanded = false;
                    expvideo.IsExpanded = false;
                    bordelista.Visibility = Visibility.Visible;
                    Stop();
                    mediacontrol.Source = null;
                    PistaActual = null;
                    lbLista.Items.Clear();
                    string[] selectedFiles = dialogo.FileNames;
                    cargar(selectedFiles);
              
                }
                else
                   multiselect = false;

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
        private void cargar(string[] selecteds)     
        {
            foreach (string file in selecteds)
            {
                if (System.IO.Path.GetExtension(file) == ".mp3" ||
                     System.IO.Path.GetExtension(file) == ".MP3" ||
                     System.IO.Path.GetExtension(file) == ".mpg" ||
                     System.IO.Path.GetExtension(file) == ".MPG" ||
                     System.IO.Path.GetExtension(file) == ".mp4" ||
                     System.IO.Path.GetExtension(file) == ".MP4" ||
                     System.IO.Path.GetExtension(file) == ".wma" ||
                     System.IO.Path.GetExtension(file) == ".wav" ||
                     System.IO.Path.GetExtension(file) == ".wmv" ||
                     System.IO.Path.GetExtension(file) == ".avi" ||
                     System.IO.Path.GetExtension(file) == ".DAT")
                {
                    ListBoxItem listaitem = new ListBoxItem();
                    listaitem.Content = System.IO.Path.GetFileNameWithoutExtension(file);
                    listaitem.Tag = file;
                    lbLista.Items.Add(listaitem);
                    BorderMediaControls.IsEnabled = true;
                   
                }
                else
                    MessageBox.Show("Tipo de Archivo No Soportado", "Informacion");
            }
            if (PistaActual == null)//si no hay medios en la lista
            {
                lbLista.SelectedIndex = 0;
                PlayoPausa();
            }

        }
        //Termina Metodo Abrir_Archivos

        /// <summary>
        /// Metodo TipoMedia() Determina que tipo de medio (audio o video) Se esta reproduciendo
        /// </summary>
        private void TipoMedia()
        {
            if (tipo_Media == ".mp3"||tipo_Media==".MP3"||tipo_Media==".wma" ||tipo_Media==".wav")
            {
                var margin = bordelista.Margin;
                margin.Left = 0;
                margin.Top = 22;
                margin.Right = 0;
                bordelista.Margin = margin;
                bordelista.Width = 1077;
                bordelista.Height = 421;
                tiempo.Stop();
                contador = 0;
                BorderMediaControls.Visibility = Visibility.Visible;
           
            }
            else
            {
                bordelista.Margin = new Thickness(950, 22, 0, 0);
                bordelista.Width = 127;
                bordelista.Height = 486;
            }

        }

        //Termina Metodo TIPO DE MEDIA

        /// <summary>
        /// Metodo PLAY O PAUSA .
        /// </summary>
        private void PlayoPausa()
        {
            //si la lista contiene elementos
            if (lbLista.HasItems)
            {
                if (btPlay.Visibility == Visibility.Visible)
                {
                    Play();
                }

                else if (btPausa.Visibility == Visibility.Visible)
                {
                    Pausa();
                }
            }   
          
        }
        //Termina metodo Play o Pausa

        /// <summary>
        /// Metodo PLAY
        /// </summary>
        private void Play()
        {
            if (lbLista.HasItems)
            {
                if (!MediaPausa) // Nos movimos a otra pista
                {
                    if (PistaActual != null) // Si anteriormente se estaba reproduciendo una pista
                    {
                        PistaAnterior = PistaActual;
                        PistaAnterior.Foreground = lbLista.Foreground; // Le devolvemos su color de fuente original
                    }
                    PistaActual = (ListBoxItem)lbLista.SelectedItem;
                    PistaActual.Foreground = ColorPistaActual;
                    tipo_Media = System.IO.Path.GetExtension(PistaActual.Tag.ToString());
                    mediacontrol.Source = new Uri(PistaActual.Tag.ToString()); // Aqui se hace el cambio de pista.                
                    slideravance.Value = 0;
                }
                TipoMedia();
                mediacontrol.Play();
                MediaPausa = false;
                btPlay.Visibility = Visibility.Collapsed;
                btPausa.Visibility = Visibility.Visible;
            }
          
        }
        private void Pausa()
        {
            btPausa.Visibility = Visibility.Collapsed;
            btPlay.Visibility = Visibility.Visible;
            mediacontrol.Pause();
            MediaPausa = true;       
        }
         //Fin metodo Play

        /// <summary>
        /// Metodo que realiza el Cambio a la Pista Siguiente Verificando la Lista si hay una Sola Repite la Misma
        /// Y llama TipoMedia() Para ver si es video o audio que esta en la siguiente Pista
        /// </summary>
        private void Siguiente()
        {
            if (lbLista.HasItems)
            {

                if (repetir)
                {
                    lbLista.SelectedIndex = lbLista.SelectedIndex;
                    MediaPausa = false;
                    Play();
                }
                else
                {
                    if (lbLista.Items.IndexOf(PistaActual) < lbLista.Items.Count - 1)
                    {
                        lbLista.SelectedIndex = lbLista.Items.IndexOf(PistaActual) + 1;
                        MediaPausa = false;
                        Play();
                        return;
                    }
                    else if (lbLista.Items.IndexOf(PistaActual) == lbLista.Items.Count - 1)
                    {
                        lbLista.SelectedIndex = 0;
                        MediaPausa = false;
                        Play();
                        return;
                    }
                }
            }
            else
                Stop();
          
        }
        /// <summary>
        /// Funcion que realiza el cambio a la Pista Anterior Igual que la Funcion Siguiente()
        /// </summary>
        private void Anterior()
        {

            if (lbLista.Items.IndexOf(PistaActual) > 0)
            {
                lbLista.SelectedIndex = lbLista.Items.IndexOf(PistaActual) - 1;
                MediaPausa = false;
                Play();
            }
            else if (lbLista.Items.IndexOf(PistaActual) == 0)
            {
                lbLista.SelectedIndex = lbLista.Items.Count - 1;
                MediaPausa = false;
                Play();
            }
         
        }

        /// <summary>
        /// Funcion STOP Detiene la reproduccion siempre y cuando la lista no este vacia
        /// </summary>
        private void Stop()
        {


            if (lbLista.HasItems)
            {
                btPlay.Visibility = Visibility.Visible;
                btPausa.Visibility = Visibility.Collapsed;
                mediacontrol.Stop();
                MediaPausa = false;
                mediacontrol.Source = null;
                

            }
        }

        //Termina Funcion STOP

        /// <summary>
        /// Funcion que habilita la Pantalla completa Siempre y cuando que se haya cargado un Video
        /// </summary>
        private void fullpantalla()
        {
            if (lbLista.HasItems)
            {
                    if(tipo_Media!=".mp3"&&tipo_Media!=".MP3"&&tipo_Media!=".wma"&&tipo_Media!=".wav")
                    {

                        if (!fullscreen)
                        {
                            RootGrid.Children.Remove(bordercontroles);
                            RootGrid.Children.Remove(BorderMediaControls);
                            gridmedia.Children.Remove(mediacontrol);
                            RootGrid.Children.Remove(gridmedia);
                            this.Content = mediacontrol;

                            this.WindowStyle = WindowStyle.None;
                            this.WindowState = WindowState.Maximized;

                        }

                        else
                        {
                            this.Content = RootGrid;
                            gridmedia.Children.Add(mediacontrol);
                            RootGrid.Children.Add(gridmedia);
                            RootGrid.Children.Add(bordercontroles);
                            RootGrid.Children.Add(BorderMediaControls);



                            this.WindowStyle = WindowStyle.None;
                            this.WindowState = WindowState.Normal;

                        }

                        fullscreen = !fullscreen;
                   
                    
                    }
                    else
                    {
                        MessageBox.Show("Modo De Reproducción De Audio", "Media Player", MessageBoxButton.OK, MessageBoxImage.Information);
                    }              
            }
            else
                MessageBox.Show("Lista Vacía", "Media Player", MessageBoxButton.OK, MessageBoxImage.Information);
             
        }

        //Fin Funcion Pantalla Completa

        /// <summary>
        /// Funcion Mute Silencia el Audio y Carga la imagen Mute al boton Volumen y Viceversa
        /// </summary>
        private void Mute()
        {

            if (!mute)
            {

               
                btVol.Source = new BitmapImage(new Uri(@"../../Resources/btn_mute_P.png", UriKind.Relative));
                mediacontrol.IsMuted = true;

            }
            else
            {
                mediacontrol.IsMuted = false;
                btVol.Source = new BitmapImage(new Uri(@"../../Resources/btn_volume_P.png", UriKind.Relative));
              
            }

            mute = !mute;
        
        }


        //Fin Funcion MUTE

        private void Repetir()
        {
            repetir = !repetir;

            if(repetir)
            {
                btRepeat.Visibility = Visibility.Collapsed;
                btRepeatActivo.Visibility = Visibility.Visible;
            }
            else
            {
                btRepeatActivo.Visibility = Visibility.Collapsed;
                btRepeat.Visibility = Visibility.Visible;
            }

        }


        private void subsalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void subarchivo_Click(object sender, RoutedEventArgs e)
        {
            tipo = faudiovideo;
            AbrirArchivos();
            
           
        }

        private void subarchivos_Click(object sender, RoutedEventArgs e)
        {
            multiselect = !multiselect;
            tipo = faudiovideo;
            AbrirArchivos(); 
            
        }
   
      
        private void expestado_Expanded(object sender, RoutedEventArgs e)
        {
            expandmedios.IsExpanded = false;
            expvideo.IsExpanded = false;
            expaudio.IsExpanded = false;
           
        }

        private void expandmedios_Expanded(object sender, RoutedEventArgs e)
        {
                expestado.IsExpanded = false;
                expvideo.IsExpanded = false;
                expaudio.IsExpanded = false;

        }

        private void subsubirvol_Click(object sender, RoutedEventArgs e)
        {
            slidervol.Value = slidervol.Value + 0.1;
        }

        private void subbajarvol_Click(object sender, RoutedEventArgs e)
        {
            slidervol.Value = slidervol.Value - 0.1;
        }

        private void expaudio_Expanded(object sender, RoutedEventArgs e)
        {
            expandmedios.IsExpanded = false;
            expestado.IsExpanded = false;
            expvideo.IsExpanded = false;
        }

        private void expvideo_Expanded(object sender, RoutedEventArgs e)
        {
            expandmedios.IsExpanded = false;
            expestado.IsExpanded = false;
            expaudio.IsExpanded = false;
        }

        private void subfullscreen_Click(object sender, RoutedEventArgs e)
        {
            fullpantalla();
        }

       

        private void mediacontrol_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fullpantalla();
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            if (!isDragging) // Si NO hay operación de arrastre en el sliderTimeLine, su posición se actualiza cada segundo.
            {
                slideravance.Value=mediacontrol.Position.TotalSeconds;
                lbtime.Content = mediacontrol.Position.Minutes + ":" + mediacontrol.Position.Seconds;
                
            }
        }

        private void mediacontrol_MediaOpened(object sender, RoutedEventArgs e)
        {
                TimeSpan ts = mediacontrol.NaturalDuration.TimeSpan;
                slideravance.Maximum = ts.TotalSeconds;         
                timer.Start();
        }

        private void slideravance_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mediacontrol.Position = TimeSpan.FromSeconds(slideravance.Value); //posicion de media se actualiza al valor del slider

        }


        void lbLista_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {

            if (lbLista.SelectedItem != null)
            {
                if (lbLista.SelectedItem.ToString() != null)
                {
                    int index = lbLista.SelectedIndex;
                    lbLista.SelectedIndex = index;
                    MediaPausa = false;
                    Play();
                   // PistaActual = (ListBox)lbLista.SelectedItem;

                }

            }
               
        }

        private void mediacontrol_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (Intro)
            {
                mediacontrol.Source = null;
                Intro = !Intro;

            }
               
            else
            Siguiente();
        }

        private void subabriraudio_Click(object sender, RoutedEventArgs e)
        {
            tipo = Faudio;
            AbrirArchivos();
        }

        private void subabriraudios_Click(object sender, RoutedEventArgs e)
        {
            tipo =Faudio;
            multiselect =!multiselect;
            AbrirArchivos();
        }

        private void subabrirvideo_Click(object sender, RoutedEventArgs e)
        {
            tipo = fvideo;
            multiselect = !multiselect;
            AbrirArchivos();
        }

        //Elementos Expanded Estado
        private void subplay_Click(object sender, RoutedEventArgs e)
        {
            Play();
            expestado.IsExpanded = false;
        }

        private void subpausa_Click(object sender, RoutedEventArgs e)
        {
            Pausa();
            expestado.IsExpanded = false;
        }

        private void subanterior_Click(object sender, RoutedEventArgs e)
        {
            Anterior();
            expestado.IsExpanded = false;
        }

        private void subsiguienter_Click(object sender, RoutedEventArgs e)
        {
            Siguiente();
            expestado.IsExpanded = false;
        }

        private void substop_Click(object sender, RoutedEventArgs e)
        {
            Stop();
            expestado.IsExpanded = false;
        }

        private void bordercontroles_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btcerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btminimiza_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

   

        private void RootWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CargarIntro();
            Intro = !Intro;
           
        }

        private void imarepeat_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Repetir();
        }

        private void btStop_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Stop();
        }

        private void btBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Anterior();
        }

        private void btPausa_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Pausa();
        }

        private void btPlay_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Play();
        }

        private void btNext_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Siguiente();
        }

        private void btVol_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Mute();
        }

        private void btScreen_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fullpantalla();
        }

        private void lbLista_Drop(object sender, DragEventArgs e)
        {
            string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            cargar(s);
        }

        private void mediacontrol_MouseMove(object sender, MouseEventArgs e)
        {
            tiempo.Start();
            contador = 0;
            BorderMediaControls.Visibility = Visibility.Visible;
        }
        private void AbrirNavegador(Object sender,RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }


    }
}
