using System;

#if MONOMAC
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;
#endif

namespace AsteroidAssault
{
#if WINDOWS || XBOX || LINUX
    static class Program
    {

        static void Main(string[] args)
        {
            using (Game1 game = new Game1())
            {
                game.Run();
            }
        }
    }
#elif MONOMAC
	static class Program
	{

		static void Main (string[] args)
		{
			NSApplication.Init ();
			
			using (var p = new NSAutoreleasePool ()) {
				NSApplication.SharedApplication.Delegate = new AppDelegate();
				NSApplication.Main(args);
			}
		}
	}
	
	class AppDelegate : NSApplicationDelegate
	{
		Game1 game;
		public override void FinishedLaunching (MonoMac.Foundation.NSObject notification)
		{
			game = new Game1();
			game.Run();
		}
		
		public override bool ApplicationShouldTerminateAfterLastWindowClosed (NSApplication sender)
		{
			return true;
		}
	}		
#else
#error Unknown platform
#endif
}