using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using System.Xml;

namespace WpfArrangement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Базовая ширина окна приложения
        const double widthBase = 800;


        private readonly XmlDocument xmlDocumnet = new XmlDocument();


        // Каталог запуска приложения (текущий каталог)
        // const создать нельзя, а readonly можно
        private readonly string baseDirectory = AppDomain.CurrentDomain.BaseDirectory + "DataBase\\";


        // Базовый размер шрифта названия приложения.
        private readonly double baseFontHeaderMain;


        // Поле в котором будет хранится установленный масштаб текста окна описания.
        private readonly double baseZoomDescription;

        // Базовый размер шрифта элементов списка.
        private readonly double baseFontListLangProg;


        // Базовый размер шрифта элемента примера кода
        // выбранного языка программирования.
        private readonly double baseFontCodeExample;


        public MainWindow()
        {

            InitializeComponent();


            try
            {
                // Загрузка данных из файла в документ.
                xmlDocumnet.Load(baseDirectory + "langprog.xml");

                GetListLanguagesProgamming();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                this.Close();
            }


            ShowSplash();


            // Инициализация базовых размеров шрифтов
            baseZoomDescription = FlowDescription.Zoom;
            baseFontHeaderMain = HeaderMain.FontSize;
            baseFontListLangProg = ListLangProg.FontSize;
            baseFontCodeExample = CodeExample.FontSize;
        }


        #region События

        private void ListBox_MouseUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Получаем выбранный элемент списка языков
            ListBox listBox = sender as ListBox;
            ListBoxItem selectedItem = listBox.SelectedItem as ListBoxItem;


            // Если выделенный элемент есть, 
            // производим дальнейшие действия.
            if (selectedItem != null)
            {
                // Показываем описание выбранного языка.
                ShowDescriptionLang(selectedItem);


                // Скрываем заставку.
                ShowSplash(false);
            }
        }



        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Извлекаем из MainWindow.xaml базовый размер шрифта заголовков.
            // Базовый размер шрифта для базовой ширины окна приложения.
            Style s = (Style)FindResource("TextBlockStyleHeader");
            System.Windows.SetterBaseCollection sc = s.Setters;

            // Получим из всех элементов только элементы типа Setter
            var setters = s.Setters.OfType<Setter>();

            // Поскольку в стиле "TextBlockStyleHeader" размер шрифта в единственном экземпляре
            // выбираем первый элемент с соответствующим названием свойства.
            Setter t = setters.First(x => x.Property.Name == "FontSize");

            // В итоге получаем базовый размер шрифтов заголовков.
            double baseFontSizeHeaders = (double)t.Value;

            // Вычисление коэффициента зумирования шрифтов
            // из соотношения актуальной ширины окна к базовой.
            double k = ActualWidth / widthBase;


            // Масштабирование шрифта заголовков при изменении ширины окна.
            HeaderMain.FontSize = k * baseFontHeaderMain;
            HeaderList.FontSize = k * baseFontSizeHeaders;
            HeaderDescription.FontSize = k * baseFontSizeHeaders;
            HeaderExample.FontSize = k * baseFontSizeHeaders;
            HeaderRating.FontSize = k * baseFontSizeHeaders;


            // Масштабирование шрифтов описания при изменении ширины окна.
            FlowDescription.Zoom = baseZoomDescription * k;
            ListLangProg.FontSize = k * baseFontListLangProg;
            CodeExample.FontSize = k * baseFontCodeExample;


            // Показ в заголовке приложения текущих размеров окна.
            //Title = ActualWidth.ToString() + "x" +  ActualHeight.ToString();
        }


        #endregion


        #region Вспомогательные методы

        // Показать или скрыть декоративную заставку.
        private void ShowSplash(bool show = true)
        {
            if (show == true)
            {
                BorderDescription.Visibility = Visibility.Hidden;
                BorderExample.Visibility = Visibility.Hidden;
                BorderRating.Visibility = Visibility.Hidden;

                SplashScreen.Visibility = Visibility.Visible;
            }
            else
            {
                BorderDescription.Visibility = Visibility.Visible;
                BorderExample.Visibility = Visibility.Visible;
                BorderRating.Visibility = Visibility.Visible;

                SplashScreen.Visibility = Visibility.Collapsed;
            }
        }



        // Получение списка языков.
        private void GetListLanguagesProgamming()
        {
            // Очистка списка от тестовых надписей.
            ListLangProg.Items.Clear();
           

            // Перечисление элементов <lang> в корне дерева xml файла. 
            foreach (XmlNode lang in xmlDocumnet.DocumentElement)
            {
                var lbItem = new ListBoxItem
                {
                    // Элемент списка будет показывать название языка.
                    Content = lang.SelectSingleNode("name").InnerText,

                    // Свяжем с элементом списка идентификатор языка. 
                    // Необходим для однозначного выбора данных
                    // при выделении элемента списка.
                    Tag = lang.Attributes["id"].Value
                };

                ListLangProg.Items.Add(lbItem);
            }

        }


        // Показать описание выбранного языка программирования.
        private void ShowDescriptionLang(ListBoxItem selectedItem)
        {
            // Перечисление элементов <lang> в корне дерева xml файла.
            foreach (XmlNode lang in xmlDocumnet.DocumentElement)
            {
                // Загрузка данных из базы по идентификатору языка.
                if (lang.Attributes["id"].Value == (string)selectedItem.Tag)
                {
                    // Очистка окна описания от предыдущих данных.
                    FlowDescription.Document.Blocks.Clear();

                    // Новое описание.
                    FlowDescription.Document.Blocks.Add(new Paragraph(new Run(lang.SelectSingleNode("description").InnerText.Trim())));

                    // Прокрутка на начало.
                    FlowDescription.Document.BringIntoView();



                    // Корректировка главного заголовка приложения.
                    HeaderMain.Text = "Язык программирования " + lang.SelectSingleNode("name").InnerText;


                    // Загружаем картинку рейтинга языка.
                    var rating = new System.Uri(baseDirectory + lang.SelectSingleNode("rating").InnerText);
                    Rating.Source = new BitmapImage(rating);



                    // --- Вставка TextBlock CodeExample примера кода из xml базы ---

                    // Очистка от предыдущих данных.
                    CodeExample.Inlines.Clear();

                    // Извлекаем код в формате xml.
                    var xml = lang.SelectSingleNode("example").InnerXml;

                    // Создаем корневой элемент плюс полученные данные.
                    var span = (Span)XamlReader.Parse("<Span xml:space=\"preserve\" xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">" + xml + "</Span>");

                    // Непосредственно вставка подготовленных данных в TextBlock CodeExample.
                    // Элементы Inline после добавления в другой элемент управления (в нашем случае TextBlock) удаляются из коллекции Span
                    // Поэтому полное копирование очищает коллекцию InlineCollection полностью.
                    while (span.Inlines.Count > 0)
                    {
                        CodeExample.Inlines.Add(span.Inlines.ElementAt(0));
                    }

                    // ---

                    
                    break;
                }
            }
        }

        #endregion
    }
}
