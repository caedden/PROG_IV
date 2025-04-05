using System.Windows;

namespace ProgramacaoIV.Exercicios.Janelas
{
    /// <summary>
    /// Lógica interna para ExercicioUm.xaml
    /// </summary>
    public partial class ExercicioDois : Window
    {
        public ExercicioDois()
        {
            InitializeComponent();
        }

        private void btnConverterTemperatura(object sender, RoutedEventArgs e)
        {
            try
            {
                var valorUmConvertido = Convert.ToInt32(txtValorUm.Text);
                var valorDoisConvertido =  ((valorUmConvertido * 9 / 5) + 32);

                MessageBox.Show($"O valor da temperetura  {valorUmConvertido}cº equivale a {valorDoisConvertido} Fahrenheit");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }
    }
}
