#include <Windows.h>
#include <iostream>
#include <string>
#include <vector>

namespace HydrixWM
{
    using namespace std;

    struct Window
    {
        string name;
        int x;
        int y;
        int width;
        int height;
        int id;
        HWND handle;
        void HShowWindow();
        // Hides the window from scope
        void HHideWindow();
        // Frees the window and handles
        void Free();
    };

    void Window::Free()
    {
		DestroyWindow(handle);
	}
    void Window::HShowWindow()
    {
        ShowWindow(handle, SW_SHOW);
    }
    void Window::HHideWindow()
    {
		ShowWindow(handle, SW_HIDE);
	}
    class WindowMGR
    {
    public:
        Window CreateNewWindow(const string& name, int x, int y, int width, int height);

    private:
        int nextWindowID = 1;
    };

    Window HydrixWM::WindowMGR::CreateNewWindow(const string& name, int x, int y, int width, int height)
    {
        Window newWindow;
        newWindow.name = name;
        newWindow.x = x;
        newWindow.y = y;
        newWindow.width = width;
        newWindow.height = height;
        newWindow.id = nextWindowID++;

        // Code to actually create the window using the Windows API
        HWND hWnd = CreateWindowEx(0, L"STATIC", L"", WS_OVERLAPPEDWINDOW, x, y, width, height, NULL, NULL, GetModuleHandle(NULL), NULL);

        // Store the created window's handle in your data structure
        newWindow.handle = hWnd;

        return newWindow;
    }
}

using namespace HydrixWM;
using namespace std;

int main()
{
    WindowMGR windowManager;

    // Example usage: Creating a new window
    Window newWindow = windowManager.CreateNewWindow("My Window", 100, 100, 800, 600);

    // Main loop
    newWindow.HShowWindow();
    while (true)
    {
		
	}
}
