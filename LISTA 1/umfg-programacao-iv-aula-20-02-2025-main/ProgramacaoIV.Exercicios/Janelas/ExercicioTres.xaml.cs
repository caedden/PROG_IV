using System.Windows;

namespace ProgramacaoIV.Exercicios.Janelas
{
    /// <summary>
    /// Lógica interna para ExercicioUm.xaml
    /// </summary>
    public partial class ExercicioTres : Window
    {
        public ExercicioTres()
        {
            InitializeComponent();
        }

        private void btnExercicioTres_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var data1 = Convert.ToDateTime(txtValorUm.Text);
                var data2 =  new DateTime();
               // var resultado = DateTime.Compare(data1,data2);

                MessageBox.Show($"{resultado}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }
    }
}
