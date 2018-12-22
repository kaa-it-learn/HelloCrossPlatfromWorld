using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using Plugin.TextToSpeech;

namespace HelloCrossPlatformWorld.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.RegisterSingleton(CrossTextToSpeech.Current);

            RegisterAppStart<ViewModels.FirstViewModel>();
        }
    }
}
