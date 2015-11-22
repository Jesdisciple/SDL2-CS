using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using SDL2;

namespace ExampleProject
{
	// http://lazyfoo.net/tutorials/SDL/01_hello_SDL/index2.php
	public class Program
	{
		const int SCREEN_WIDTH = 640;
		const int SCREEN_HEIGHT = 480;

		public static int Main()
		{
			//The window we'll be rendering to
			IntPtr window = IntPtr.Zero;

			//The surface contained by the window
			IntPtr screenSurface;

			//Initialize SDL
			if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) < 0)
			{
				Console.WriteLine("SDL could not initialize! SDL_Error: {0}\n", SDL.SDL_GetError());
			}
			else
			{
				//Create window
				window = SDL.SDL_CreateWindow("SDL Tutorial", SDL.SDL_WINDOWPOS_UNDEFINED, SDL.SDL_WINDOWPOS_UNDEFINED, SCREEN_WIDTH, SCREEN_HEIGHT, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
				if (window == IntPtr.Zero)
				{
					Console.WriteLine("Window could not be created! SDL_Error: {0}\n", SDL.SDL_GetError());
				}
				else
				{
					//Get window surface
					screenSurface = SDL.SDL_GetWindowSurface(window);

					//Fill the surface white
					var sur = Marshal.PtrToStructure<SDL.SDL_Surface>(screenSurface);
					var rect = new SDL.SDL_Rect();
					SDL.SDL_FillRect(screenSurface, ref rect, SDL.SDL_MapRGB(sur.format, 0xFF, 0xFF, 0xFF));

					//Update the surface
					SDL.SDL_UpdateWindowSurface(window);

					//Wait two seconds
					SDL.SDL_Delay(2000);
				}
			}

			//Destroy window
			SDL.SDL_DestroyWindow(window);

			//Quit SDL subsystems
			SDL.SDL_Quit();

			return 0;
		}
	}
}
