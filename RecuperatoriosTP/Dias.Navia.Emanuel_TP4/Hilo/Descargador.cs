using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        private string _html;
        private Uri _direccion;

        public delegate void EventProgress(int estado);
        public event EventProgress evProgress;
        public delegate void EventCompleted(string web);
        public event EventCompleted evFinalizado;

        /// <summary>
        /// Recibe la direccion web
        /// </summary>
        /// <param name="direccion"></param>
        public Descargador(Uri direccion)
        {
            this._html = "";
            this._direccion = direccion;
        }

        /// <summary>
        /// inicia la descarga de la pagina web
        /// </summary>
        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;

                cliente.DownloadStringAsync(this._direccion);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Progreso de descarga
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.evProgress(e.ProgressPercentage);
        }
        /// <summary>
        /// progreso de la descarga finalizada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                this._html = e.Result;
            }
            catch (Exception exception)
            {
                this._html = exception.Message;
            }
            finally
            {
                this.evFinalizado(this._html);
            }
        }
    }
}
