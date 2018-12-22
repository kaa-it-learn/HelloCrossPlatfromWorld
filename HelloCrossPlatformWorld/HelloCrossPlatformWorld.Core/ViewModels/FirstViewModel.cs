using MvvmCross.Core.ViewModels;
using Plugin.TextToSpeech.Abstractions;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HelloCrossPlatformWorld.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        readonly ITextToSpeech textToSpeech;

        public FirstViewModel(ITextToSpeech textToSpeech)
        {
            this.textToSpeech = textToSpeech;
            SayHelloCommand = new MvxCommand(SayHello);
        }

        public ICommand SayHelloCommand { get; private set; }

        void SayHello()
        {
            var task = new Task(() => MakeLongWebServiceCall());
            task.Start();

            textToSpeech.Speak($"Hello {Name}");
        }

        void MakeLongWebServiceCall()
        {
            Task.Delay(TimeSpan.FromSeconds(5)).Wait();
        }

        string name = "";
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
    }
}
