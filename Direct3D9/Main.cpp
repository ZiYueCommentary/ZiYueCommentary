#include <Windows.h>
#include <d3d.h>
#include <boost/algorithm/string.hpp>
#pragma comment(lib, "d3d7.lib")
IDirect3DDevice7* device;

LRESULT CALLBACK WndProc(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam) {
    switch (msg) {
    case WM_DESTROY: device->Release();
        PostQuitMessage(0);
        ExitProcess(0);
        break;
    default:
        return DefWindowProc(hwnd, msg, wParam, lParam);
    }
    return 0;
}

int WINAPI WinMain(HINSTANCE hinstance, HINSTANCE, LPSTR, int show) {
    WNDCLASS wc = {};
    wc.style = CS_HREDRAW | CS_VREDRAW;
    wc.lpszClassName = "DirectX";
    wc.cbClsExtra = 0;
    wc.cbWndExtra = 0;
    wc.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH);
    wc.hCursor = nullptr;
    wc.hIcon = nullptr;
    wc.hInstance = hinstance;
    wc.lpfnWndProc = WndProc;
    wc.lpszMenuName = nullptr;
    wc.style = show;

    RegisterClass(&wc);

    HWND hwnd = CreateWindow("DirectX", "D3D9", WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_MINIMIZEBOX, CW_USEDEFAULT, CW_USEDEFAULT, 1020, 720, nullptr, nullptr, hinstance, nullptr);
    SetWindowPos(hwnd, HWND_TOP, 0, 0, 1020, 720, SWP_SHOWWINDOW);
    ShowWindow(hwnd, show);
    UpdateWindow(hwnd);
    IDirect3D7* d3d9 = Direct3DCreate7(D3D_SDK_VERSION);
    D3DPRESENT_PARAMETERS params = {};
    params.BackBufferWidth = 1020;
    params.BackBufferHeight = 720;
    params.BackBufferFormat = D3DFMT_A8R8G8B8;
    params.BackBufferCount = 1;
    params.MultiSampleType = D3DMULTISAMPLE_NONE;
    params.MultiSampleQuality = 0;
    params.SwapEffect = D3DSWAPEFFECT_DISCARD;
    params.hDeviceWindow = hwnd;
    params.Windowed = true;
    params.EnableAutoDepthStencil = true;
    params.AutoDepthStencilFormat = D3DFMT_D24S8;
    params.Flags = NULL;
    params.FullScreen_RefreshRateInHz = D3DPRESENT_RATE_DEFAULT;
    params.PresentationInterval = D3DPRESENT_INTERVAL_DEFAULT;
    d3d9->CreateDevice(D3DADAPTER_DEFAULT, D3DDEVTYPE_HAL, hwnd, D3DCREATE_HARDWARE_VERTEXPROCESSING, &params, &device);

    MSG msg;
    while (GetMessage(&msg, hwnd, 0, 0)) {
        TranslateMessage(&msg);
        DispatchMessage(&msg);
        device->Clear(0, 0, D3DCLEAR_TARGET | D3DCLEAR_ZBUFFER, D3DCOLOR_ARGB(0, 255, 255, 255), 1, 0);
        device->Present(0, 0, 0, 0);
    }

    return msg.wParam;
}