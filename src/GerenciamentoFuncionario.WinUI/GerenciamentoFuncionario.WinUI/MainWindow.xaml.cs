﻿using GerenciamentoFuncionario.AcessoDados;
using GerenciamentoFuncionario.ViewModel;
using Microsoft.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace GerenciamentoFuncionario.WinUI
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            ViewModel = new MainWindowViewModel(new FuncionarioProvedorDados(), new CargoProvedorDados());
            this.Activated += MainWindow_Activated;
        }

        private void MainWindow_Activated(object sender, WindowActivatedEventArgs args)
        {
            if (ViewModel.Funcionarios.Count == 0)
                ViewModel.Carregar();
        }

        public MainWindowViewModel ViewModel { get; }
    }
}
