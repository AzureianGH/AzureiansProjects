#include <gl/GL.h>
#include <gl/GLU.h>
#include <iostream>
#include <Windows.h>
#include <math.h>
#include <string>
int main()
{
	// Create a window
	HWND hWnd = CreateWindowEx(NULL,
				L"STATIC",
				L"OpenGL",
				WS_OVERLAPPEDWINDOW,
				0, 0, 800, 600,
				NULL, NULL, NULL, NULL);
	// Get the device context
	HDC hDC = GetDC(hWnd);
	// create window
	PIXELFORMATDESCRIPTOR pfd;
	ZeroMemory(&pfd, sizeof(pfd));
	pfd.nSize = sizeof(pfd); // size of the pfd
	pfd.nVersion = 1; // always 1
	pfd.dwFlags = PFD_DRAW_TO_WINDOW; // draw to window
	pfd.iPixelType = PFD_TYPE_RGBA; // red, green, blue, alpha for each pixel
	pfd.cColorBits = 24; // 24 bit == 8 bits for red, 8 for green, 8 for blue.
	pfd.cDepthBits = 16; // 16 bits for depth (also known as z buffer)
	int n = ChoosePixelFormat(hDC, &pfd); // choose the closest pixel format available
	SetPixelFormat(hDC, n, &pfd); // set the pixel format for the device context
	// create rendering context
	HGLRC tempOpenGLContext = wglCreateContext(hDC);
	wglMakeCurrent(hDC, tempOpenGLContext);
	//open window
	ShowWindow(hWnd, SW_SHOW);
	// set up perspective projection



}