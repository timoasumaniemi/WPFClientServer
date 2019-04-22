using Client.UI;
using System;
using System.Windows;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CompositionContainer _container;

        [Import]
        private ExportFactory<IWpfClient> WpfClientFactory { get; set; }

        public MainWindow()
        {
            // Init MEF
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(WpfClient).Assembly));
            _container = new CompositionContainer(catalog);

            try
            {
                this._container.ComposeParts(this);
            }
            catch(CompositionException ex)
            {
                Console.Write($"Composing error: {ex.Message}");
            }

            var wpfClient = WpfClientFactory.CreateExport().Value;

            base.DataContext = wpfClient;
            InitializeComponent();
        }
    }
}
