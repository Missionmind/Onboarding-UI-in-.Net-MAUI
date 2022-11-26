using System.ComponentModel;
using OnboardingController.Model;
namespace OnboardingController.ViewModel
{
    internal class OnboardingViewModel : INotifyPropertyChanged
    {
        public Command SkipCommand { get; set; }

        public Command NextCommand { get; set; }

        public Command GetStartedCommand { get; set; }

        public List<OnboardingModel> Source { get; set; }

        private bool enableMainPage = false;
        public bool EnableMainPage
        {
            get
            {
                return enableMainPage;
            }
            set
            {
                enableMainPage = value;
                RaisePropertyChange(nameof(EnableMainPage));
            }
        }

        private bool activeSkipPage = true;
        public bool ActiveSkipPage
        {
            get
            {
                return activeSkipPage;
            }
            set
            {
                activeSkipPage = value;
                RaisePropertyChange(nameof(ActiveSkipPage));
            }
        }

        private int position = 0;
        public int Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                RaisePropertyChange(nameof(Position));
            }
        }

        public Color backgroundColor;
        public Color BackgroundColor
        {
            get
            {
                return backgroundColor;
            }
            set
            {
                backgroundColor = value;
                RaisePropertyChange(nameof(BackgroundColor));
            }
        }

        public OnboardingViewModel()
        {
            Source = new List<OnboardingModel>();
            BackgroundColor = Color.FromRgb(215, 206, 255);
            Source.Add(new OnboardingModel
            {
                Title = "Use shapes to decorate your design",
                Description = "Decorate your design products with relevant shapes. Use basic geometric shapes like squares, circles or more complex shapes such as hearts, stars, bubbles to draw attention to your design segments!",
                Color = Color.FromRgb(215, 206, 255),
                Image = "shape1.png"
            });
            Source.Add(new OnboardingModel
            {
                Title = "Combine shapes with other objects",
                Description = "Use arrows, lines and illustrations to make unique visuals every time. Shapes may look simiplistic and even basic, but they're a great addition to your designs. Don't get carried away, thought! Too many shapes can overcomplicate your design.",
                Color = Color.FromRgb(198, 224, 246),
                Image = "shape2.png"
            });

            Source.Add(new OnboardingModel
            {
                Title = "Animate shapes to catch the attention",
                Description = "Geometric makes it very easy to animate any design object. There are animation presents that allow you to make a shape zoom, fade, wobble, shake, spin and more, with just a click of a button.",
                Color = Color.FromRgb(239, 217, 201),
                Image = "shape3.png"
            });

            Position = 0;
            SkipCommand = new Command(Close);
            GetStartedCommand = new Command(NavigateToGetStarted);
            NextCommand = new Command(NextItem);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChange(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        private void Close()
        {
            Application.Current.MainPage = new MainPage();
        }

        private void NavigateToGetStarted()
        {
            Application.Current.MainPage = new MainPage();
        }

        private void NextItem()
        {
            var count = Position + 1;
            if (count <= Source.Count - 1)
            {
                BackgroundColor = Source[count].Color;
                Position = count;
                EnableMainPage = Position == Source.Count - 1;
                ActiveSkipPage = !EnableMainPage;
            }
            else
                Application.Current.MainPage = new MainPage();
        }
    }
}

