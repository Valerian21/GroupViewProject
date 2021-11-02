using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GroupViewProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Main main = new Main();
        public MainWindow()
        {
            InitializeComponent();
            UpdListView();
            lvViewGroup.ItemsSource = main.ReadGroup();
        }

        void UpdListView()
        {
            Main main = new Main();

            lvViewGroup.ItemsSource = main.ReadGroup();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbCurator.Text) || string.IsNullOrWhiteSpace(tbNameGroup.Text) || string.IsNullOrWhiteSpace(tbNumberGroup.Text))
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                Group group = new Group()
                {
                    NameGroup = tbNameGroup.Text,
                    NumberGroup = tbNumberGroup.Text,
                    CuratorGroup = tbCurator.Text
                };

                Main main = new Main();

                main.AddGroup(group);
                UpdListView();
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(TbId.Text))
                {
                    MessageBox.Show("Заполните поле id");
                }
                else
                {
                    main.DelGroup(Convert.ToInt32(TbId.Text));
                    UpdListView();
                    MessageBox.Show("Удаление выполнено!");
                }
            
            }
            catch (Exception)
            {
                MessageBox.Show("Неверный формат id");
            }
        }

        private void lvViewGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvViewGroup.ItemsSource = main.ReadGroup();
        }
    }
}
